using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

//using hod_back.DAL.Models;
//using hod_back.Model;
//using hod_back.DAL.Models.Dictionaries;
//using hod_back.DAL.Models.ToSend;
//using hod_back.DAL.Models.ToRecieve;
//using hod_back.DAL.Models.Views;
//using hod_back.DAL;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using hod_back.Services.Auth;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

using hod_back.Model;
using hod_back.DAL;
using AutoMapper;
using hod_back.Dto;
using hod_back.Extentions;

namespace hod_back.Controllers
{
    [ApiController]
    [Route("fgos")]
    public class FgosController : Controller
    {
        private UnitOfWork _unit;
        private IMapper _mapper;

        public FgosController(UnitOfWork unit, IMapper mapper)
        {
            this._unit = unit;
            this._mapper = mapper;
        }

        [HttpGet("get/dirs/{dep_id}")]
        public async Task<DirFgosDto[]> GetDirFgos([FromRoute] int dep_id)
        {
            List<DirFgosDto> res = new List<DirFgosDto>();

            var tmp = _unit.DirRequirs.GetManyAsync(x => x.DepId.Value == dep_id).Result;
            var kek = tmp.GroupBy(x => new { x.DirId });

            foreach (var i in kek)
            {
                var res1 = new DirFgosDto()
                {
                    DirName = i.ToList()[0].EBrName,
                    StartYear = i.ToList()[0].StartYear,
                    Fgos443 = i.ToList().FirstOrDefault(x => x.FgosNum.NewFgos().Contains("4.4.3")).SettedValue.ToString(),
                    Fgos444 = i.ToList().FirstOrDefault(x => x.FgosNum.NewFgos().Contains("4.4.4")).SettedValue.ToString(),
                    Fgos445 = i.ToList().FirstOrDefault(x => x.FgosNum.NewFgos().Contains("4.4.5")).SettedValue.ToString()
                };
                res.Add(res1);
            }

            return res.ToArray();
        }

    }
}
