using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.Entities;
using AnkietyUW.DataLayer.Repository.AnswerRepository;
using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;
using AutoMapper;
using System.Collections.ObjectModel;
using AnkietyUW.Contracts.ExtractTestDto.DataTransferObjects;

namespace AnkietyUW.Services.Controllers.AdminControllers
{

    [Route("ExtractAnswers")]
    public class ExtractTestController : BaseAdminController
    {
        public ExtractTestController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        // Wyciąga odpowiedzi z ankiety dla danego testu i zamienia w csv
        [HttpPost]
        [Route("Extract")]
        public async Task<IActionResult> ExtractAnswersForTest([FromBody]ExtractTestDto extractTestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                //ExtTest extTest = Mapper.Map<ExtractTestDto, ExtTest>(extractTestDto);
                ICollection<Answer> ansList = await UnitOfWork.AnswerRepository.GetAnswerForTest(extractTestDto.TestId);

                System.Text.StringBuilder strcsv = new System.Text.StringBuilder();
                strcsv.Append("id_obserwacji,");
                strcsv.Append("kod_osoby,");
                strcsv.Append("pomiar,");
                strcsv.Append("dzień,");
                strcsv.Append("pomiar_w_dniu,");
                strcsv.Append("godz_pomiaru\r");
                foreach (Answer ans in ansList)
                {
                    strcsv.Append(ans.Id.ToString());
                    strcsv.Append(",");
                    strcsv.Append(ans.UserId);
                    strcsv.Append(",");
                    strcsv.Append(ans.SeriesNumber);
                    strcsv.Append(",");
                    strcsv.Append(ans.DateTime.Date.ToString());
                    strcsv.Append(",");
                    strcsv.Append((ans.SeriesNumber % 4 + 1).ToString());
                    strcsv.Append(",");
                    strcsv.Append(ans.DateTime.TimeOfDay.ToString());
                    strcsv.Append(",");

                    foreach (int? an in ans.Answers)
                    {
                        strcsv.Append(an.ToString());
                        strcsv.Append(",");
                    }
                    strcsv.Append("\r");
                }
                return new JsonResult(strcsv);
            }
            catch (Exception e)
            {
                return new JsonResult(e.ToString());
            }
        }
    }
}
