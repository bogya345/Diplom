using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
using hod_back.Models;

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
            List<int> list = new List<int>() { 11016, 21017, 21020, 21021, 31020, 31021, 31022, 31023, 31024, 31025, 31026 };

            List<DirFgosDto> res = new List<DirFgosDto>();

            var tmp = _unit.DirRequirs.GetManyAsync(x => x.DepId.Value == dep_id && list.Contains(x.DirId)).Result;
            var kek = tmp.GroupBy(x => new { x.DirId });

            foreach (var i in kek)
            {
                var res1 = new DirFgosDto()
                {
                    DirId = i.ToList()[0].DirId,
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

        [HttpPost("change")]
        public CommonResponseDto PostChangeFgos([FromBody] ChangesFgosModel model)
        {
            CommonResponseDto res = new CommonResponseDto();
            var answer = this._unit.DirRequirs.UpdateRangeAsync(model);
            if (answer)
            {
                return new CommonResponseDto("Изменения сохранены");
            }
            return new CommonResponseDto("Ошибка при сохранении");
        }

    }
}
