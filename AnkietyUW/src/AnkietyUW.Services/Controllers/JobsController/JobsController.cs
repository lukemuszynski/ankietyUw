using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;
using AnkietyUW.Utilities;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AnkietyUW.Services.Controllers.JobsController
{
    public class JobsController : BaseAdminController
    {

        private IJwtUtility JwtUtility { get; set; }

        //wysylanie maili do wszystkich osob z danego badania
        public JobsController(IUnitOfWork unitOfWork, IJwtUtility jwtUtility) : base(unitOfWork)
        {
            JwtUtility = jwtUtility;
        }

        public async Task<IActionResult> SendEmailsForAllTests()
        {

            try
            {
                int timeWindow = 120;
                var tests = await UnitOfWork.TestRepository.GetAllNotCompletedTestsWithTestTimesAndUsers();

                foreach (var test in tests)
                {
                    bool shouldSendMail = false;
                    Guid testTimeGuid;
                    foreach (var testtime in test.TestTimes)
                    {

                        if (testtime.DateTime == DateTime.UtcNow.Date)
                        {
                            if (
                                (DateTime.UtcNow.AddSeconds(-timeWindow) <
                                 testtime.DateTime.AddSeconds(test.FirstQuestionAddSeconds) &&
                                 DateTime.UtcNow.AddSeconds(timeWindow) >
                                 testtime.DateTime.AddSeconds(test.FirstQuestionAddSeconds)) ||

                                (DateTime.UtcNow.AddSeconds(-timeWindow) <
                                 testtime.DateTime.AddSeconds(test.ThirdQuestionAddSeconds) &&
                                 DateTime.UtcNow.AddSeconds(timeWindow) >
                                 testtime.DateTime.AddSeconds(test.ThirdQuestionAddSeconds)) ||

                                (DateTime.UtcNow.AddSeconds(-timeWindow) <
                                 testtime.DateTime.AddSeconds(test.FourthQuestionAddSeconds) &&
                                 DateTime.UtcNow.AddSeconds(timeWindow) >
                                 testtime.DateTime.AddSeconds(test.FourthQuestionAddSeconds)) ||

                                (DateTime.UtcNow.AddSeconds(-timeWindow) <
                                 testtime.DateTime.AddSeconds(test.SecondQuestionAddSeconds) &&
                                 DateTime.UtcNow.AddSeconds(timeWindow) >
                                 testtime.DateTime.AddSeconds(test.SecondQuestionAddSeconds))
                            )
                            {
                                testTimeGuid = testtime.Id;
                                shouldSendMail = true;
                                break;
                            }
                        }

                    }

                    if (shouldSendMail)
                    {

                        foreach (var testUser in test.Users)
                        {

                            if (!testUser.Active)
                                continue;

                            int seriesNumber = test.CompletedSeriesCounter;
                            string userGuid = testUser.Id.ToString();
                            string testTimeId = testTimeGuid.ToString();
                            string emailAddress = testUser.EmailAddress;

                            var secret = await UnitOfWork.SecretRepository.CreateSecret(testUser.Id,seriesNumber);
                         
                            var d = new Dictionary<string, string>();

                            d.Add("UserId", userGuid);
                            d.Add("SecretId", secret.Id.ToString());
                            d.Add("TestTimeId", testTimeId);
                            d.Add("SeriesNumber", seriesNumber.ToString());
                            string token = JwtUtility.Encode(d);

                            var apiKey = "NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY";
                            var client = new SendGridClient(apiKey);
                            var from = new EmailAddress("katarzyna@badanie.emocje.uw", "Katarzyna Wojtkowska");
                            var subject = "Przypomnienie o pomiarze numer " + seriesNumber.ToString();
                            var to = new EmailAddress(emailAddress);
                            var plainTextContent = "localhost:4200/user-answer/" + token;
                            var htmlContent = "<strong>"+token+"</strong>";
                            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                            var response = await client.SendEmailAsync(msg);
                            
                        }

                        test.CompletedSeriesCounter++;
                        test.Users = null;
                        test.TestTimes = null;
                        await UnitOfWork.TestRepository.UpdateTest(test);
                        await UnitOfWork.SaveChangesAsync();

                    }


                }

                

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok();
        }

    }
}
