using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.Contracts.EmailDto.DataTransferObjects;
using AnkietyUW.DataLayer.Entities;
using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;
using AnkietyUW.Utilities;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AnkietyUW.Services.Controllers.JobsController
{
    [Route("Emails")]
    public class JobsController : BaseAdminController
    {

        private IJwtUtility JwtUtility { get; set; }

        //wysylanie maili do wszystkich osob z danego badania
        public JobsController(IUnitOfWork unitOfWork, IJwtUtility jwtUtility) : base(unitOfWork)
        {
            JwtUtility = jwtUtility;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> SendEmailsForAllTests()
        {

            try
            {
                int timeWindow = 120;
                var tests = await UnitOfWork.TestRepository.GetAllNotCompletedTestsWithTestTimesAndUsers();
                var dateTimeNow = DateTime.UtcNow;

                foreach (var test in tests)
                {
                    bool shouldSendMail = false;
                    Guid testTimeGuid;
                    foreach (var testtime in test.TestTimes)
                    {

                        if (testtime.DateTime == DateTime.UtcNow.Date)
                        {


                            var firstQuestionDateTime = testtime.DateTime.AddSeconds(test.FirstQuestionAddSeconds);
                            var secondQuestionDateTime = testtime.DateTime.AddSeconds(test.SecondQuestionAddSeconds);
                            var thirdQuestionDateTime = testtime.DateTime.AddSeconds(test.ThirdQuestionAddSeconds);
                            var fourthQuestionDateTime = testtime.DateTime.AddSeconds(test.FourthQuestionAddSeconds);


                            bool firstInBound = firstQuestionDateTime.AddSeconds(-timeWindow) < dateTimeNow &&
                                                firstQuestionDateTime.AddSeconds(timeWindow) > dateTimeNow;

                            bool secondInBound = secondQuestionDateTime.AddSeconds(-timeWindow) < dateTimeNow &&
                                          secondQuestionDateTime.AddSeconds(timeWindow) > dateTimeNow;

                            bool thirdInBound = thirdQuestionDateTime.AddSeconds(-timeWindow) < dateTimeNow &&
                                        thirdQuestionDateTime.AddSeconds(timeWindow) > dateTimeNow;

                            bool fourthInBound = fourthQuestionDateTime.AddSeconds(-timeWindow) < dateTimeNow &&
                                                   fourthQuestionDateTime.AddSeconds(timeWindow) > dateTimeNow;


                            if (firstInBound || secondInBound || thirdInBound || fourthInBound)
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

                            var secret = await UnitOfWork.SecretRepository.CreateSecret(testUser.Id, seriesNumber);

                            var d = new Dictionary<string, string>();

                            d.Add("UserId", userGuid);
                            d.Add("SecretId", secret.Id.ToString());
                            d.Add("TestTimeId", testTimeId);
                            d.Add("SeriesNumber", seriesNumber.ToString());
                            string token = JwtUtility.Encode(d);

                            var apiKey = "APIKEYHERE";
                            var client = new SendGridClient(apiKey);
                            var from = new EmailAddress("katarzyna@badanie.emocje.uw", "Katarzyna Wojtkowska");
                            var subject = "Przypomnienie o pomiarze numer " + seriesNumber.ToString();
                            var to = new EmailAddress(emailAddress);
                            var plainTextContent = "localhost:4200/user-answer/" + token;
                            var htmlContent = "<strong>" + token + "</strong>";
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


        /// <summary>
        /// Sending email message to one User specified by Guid
        /// Example request:
        /// 
        /// Method: POST
        /// Route: http://localhost:53980/Emails/SendSingle/
        /// Body:
        /// {
        ///    "UserGuid": "e657896a-0095-476f-a4bc-5596e8d228cd",
        ///    "Title": "Hey man! There's a problem",
        ///    "Content": "Please, consider opening this website: http://somewebsite.org (casual content)",
        ///    "HtmlContent": "Please, consider opening this website: http://somewebsite.org (html content)"
        /// }
        /// Headers: "Content-Type": "application/json"
        /// </summary>
        /// <param name="sendEmailDto"></param>
        /// <returns></returns>
        [HttpPost("SendSingle")]
        public async Task<IActionResult> SendSigleEmail([FromBody] SendEmailDto sendEmailDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                User user = UnitOfWork.UserRepository.GetUserByGuid(sendEmailDto.UserGuid).Result;

                if (user == null)
                    return new ObjectResult("Error: Given user does not exit");
                if (user.EmailAddress == null)
                    return new ObjectResult("Error: Given user does not have any email adrress");

                var apiKey = "APIKEYHERE";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("katarzyna@badanie.emocje.uw", "Katarzyna Wojtkowska");
                var subject = sendEmailDto.Title;
                var to = new EmailAddress(user.EmailAddress);
                var plainTextContent = sendEmailDto.Content;
                var htmlContent = sendEmailDto.HtmlContent;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
                return new ObjectResult("Message sent.\nuserGuid: " + sendEmailDto.UserGuid
                                            + "\nTitle: " + sendEmailDto.Title
                                            + "\nContent: " + sendEmailDto.Content
                                            + "\nContentHtml: " + sendEmailDto.HtmlContent
                                            + "\nAddress: " + user.EmailAddress);
            }
            catch (Exception e)
            {
                return new ObjectResult(e);
            }
        }
    }
}