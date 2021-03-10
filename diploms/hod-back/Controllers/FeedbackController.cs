using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Headers;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

using hod_back.DAL.Models;
using hod_back.DAL.Models.Views;
using hod_back.DAL.Models.ToRecieve;
using hod_back.DAL.Models.ToSend;
using hod_back.DAL.Models.ToParse;

using hod_back.DAL;
using hod_back.DAL.Contexts;

using hod_back.Services.Excel;


namespace hod_back.Controllers
{
    [ApiController]
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        private UnitOfWork unit = new UnitOfWork();

        public FeedbackController()
        {

        }

        /// <summary>
        /// Таблица с отчетами
        /// </summary>
        /// <returns></returns>
        [HttpGet("feedbacktable")]
        public IEnumerable<int> FeedbackResponse()
        {
            throw new Exception();
        }

        /// <summary>
        /// Получение отправленного отчета(ошибка или пожелание)
        /// </summary>
        /// <returns></returns>
        [HttpPost("sendfeedback")]
        public bool FeedbackReceive()
        {
            return true;
        }

        /// <summary>
        /// Получение действий (maybe) -- можно и на самом сервере сразу писать что и кто сделал
        /// </summary>
        /// <returns></returns>
        [HttpPost("logs")]
        public bool LogsRecieve()
        {
            return true;
        }

        /// <summary>
        /// Отправка событий по пользователю
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> LogsResponse()
        {
            throw new Exception();
        }

    }
}
