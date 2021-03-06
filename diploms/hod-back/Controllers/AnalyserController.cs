using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using hod_back.Services.Auth;
using Microsoft.IdentityModel.Tokens;

using hod_back.DAL;
using hod_back.Dto.Analyser;
using hod_back.Dto.Analyser.FgosRequirs;
using System.Threading.Tasks;
using hod_back.Services.Analyse;
using hod_back.Dto;

namespace hod_back.Controllers
{
    [Route("analyser")]
    public class AnalyserController : Controller
    {
        private UnitOfWork _unit;
        private Strategy_7_2_ accum;

        public AnalyserController(UnitOfWork unit)
        {
            this._unit = unit;
            this.accum = new Strategy_7_2_();
        }

        [HttpGet("test")]
        public async Task<Requir> Test()
        {
            int dir_id = 151;
            string requir_num = "7-2-2";

            string requir_code = requir_num.Replace("-", ".");

            Strategy strategy = null;
            if (requir_code == "7.2.1") { strategy = new Strategy_7_2_1(); }
            if (requir_code == "7.2.2") { strategy = new Strategy_7_2_2(); }
            //if (fgos_num == "7.2.3") { strategy = new Strategy_7_2_3(); }
            //if (fgos_num == "7.2.4") { strategy = new Strategy_7_2_4(); }
            // others fgos requirs

            if (strategy == null) { return null; }

            //var requir = _unit.DirRequirs.GetOrDefault(x => x.DirId == dir_id && x.FgosNum == requir_code);
            var load = _unit.TeacherLoadSuitabilities.GetMany(x => x.DirId == dir_id);

            Requir res = strategy.Execute(_unit, dir_id);
            var groups = _unit.DirGroups.GetMany(x => x.DirId == dir_id).Select(x => x.GroupId).ToList();
            res.NumberAll = _unit.AttAcPlans.GetMany(x => groups.Contains(x.GroupId.Value)).Count();

            return res;
        }

        [HttpGet("get/groups/{group_id}")]
        public async Task<GroupStatusDto> GetGroupStatus([FromRoute] int group_id)
        {
            var res = new GroupStatusDto() { message = "hello, its me" };
            return res;
        }

        //[HttpGet("get/dirs/{dir_id}")]
        //public async Task<DirInfoDto[]> GetDirInfo([FromRoute] int dir_id)
        //{
        //    var requirs = _unit.Dir
        //}

        [HttpGet("get/dir-groups/{dir_id}")]
        public async Task<GroupAnalyserDto[]> GetGroupAnalys([FromRoute] int dir_id)
        {
            var groups = await _unit.Groups.GetManyAsync(x => x.DirId == dir_id);

            List<GroupAnalyserDto> res = new List<GroupAnalyserDto>();

            foreach (var group in groups)
            {
                var info = await _unit.AttAcPlans.GetManyAsync(x => x.GroupId == group.GroupId);
                int numberA = info.Count();
                int numberS = info.Where(x => x.FshId != null).Count();
                float value = -1;
                if (numberA == numberS)
                {
                    var teachInfo = await _unit.TeacherLoadSuitabilities.GetManyAsync(x => x.DirId == dir_id);
                    //numberA2 = teachInfo.Count();
                    Strategy strategy = new Strategy_7_2_3();
                    var temp = strategy.Execute(_unit, dir_id);
                    value = temp.Value;
                }

                var tmp = new GroupAnalyserDto()
                {
                    Group_id = group.GroupId,
                    NumberAll = numberA,
                    NumberSubmitted = numberS,
                    //NumberAll2 = numberA,
                    //NumberSubmitted2 = numberS2,
                    Value = value
                    //Mark = mark
                };

                res.Add(tmp);
            }

            return res.ToArray();
        }

        [HttpGet("get/fgos-requirs/{dir_id}/7-2")]
        public async Task<Requirs_7_2Dto> GetRequirs7_2([FromRoute] int dir_id, [FromRoute] string requir_num)
        {
            if (!this.accum.StoreIt(_unit, dir_id)) { return new Requirs_7_2Dto() { Message = "Ни один преподаватель не назначен для получения сведений о показателей требований ФГОС." }; }

            Requirs_7_2Dto res = new Requirs_7_2Dto();
            res.Dir_id = dir_id;

            Strategy strategy = new Strategy_7_2_2();

            #region Partial
            // 4.4.3
            Requir tmp722_Part = strategy.Execute_Partial(_unit, this.accum.Dir, this.accum.items, this.accum.exList);
            res.Partial.NumberAll722 = tmp722_Part.NumberAll;
            res.Partial.NumberSubmitted722 = tmp722_Part.NumberSuitable;
            res.Partial.Mark722 = tmp722_Part.isDone ? "+" : "-";

            // 4.4.5
            strategy = new Strategy_7_2_3();
            Requir tmp723_Part = strategy.Execute_Partial(_unit, this.accum.Dir, this.accum.items, this.accum.exList);
            res.Partial.NumberAll723 = tmp723_Part.NumberAll;
            res.Partial.NumberSubmitted723 = tmp723_Part.NumberSuitable;
            res.Partial.Mark723 = tmp723_Part.isDone ? "+" : "-";

            // 4.4.4
            strategy = new Strategy_7_2_4();
            Requir tmp724_Part = strategy.Execute_Partial(_unit, this.accum.Dir, this.accum.items, this.accum.exList);
            res.Partial.NumberAll724 = tmp724_Part.NumberAll;
            res.Partial.NumberSubmitted724 = tmp724_Part.NumberSuitable;
            res.Partial.Mark724 = tmp724_Part.isDone ? "+" : "-";
            #endregion

            #region Full
            // 4.4.3
            Requir tmp722 = strategy.Execute_Full(_unit, this.accum.Dir, this.accum.items, this.accum.exList, this.accum.TotalCount);
            res.Full.NumberAll722 = tmp722.NumberAll;
            res.Full.NumberSubmitted722 = tmp722.NumberSuitable;
            res.Full.Mark722 = tmp722.isDone ? "+" : "-";

            // 4.4.5
            strategy = new Strategy_7_2_3();
            Requir tmp723 = strategy.Execute_Full(_unit, this.accum.Dir, this.accum.items, this.accum.exList, this.accum.TotalCount);
            res.Full.NumberAll723 = tmp723.NumberAll;
            res.Full.NumberSubmitted723 = tmp723.NumberSuitable;
            res.Full.Mark723 = tmp723.isDone ? "+" : "-";

            // 4.4.4
            strategy = new Strategy_7_2_4();
            Requir tmp724 = strategy.Execute_Full(_unit, this.accum.Dir, this.accum.items, this.accum.exList, this.accum.TotalCount);
            res.Full.NumberAll724 = tmp724.NumberAll;
            res.Full.NumberSubmitted724 = tmp724.NumberSuitable;
            res.Full.Mark724 = tmp724.isDone ? "+" : "-";
            #endregion

            return res;
        }

        [HttpGet("get/fgos-requirs/{dir_id}/{requir_num}")]
        public async Task<Requir> GetRequir([FromRoute] int dir_id, [FromRoute] string requir_num)
        {
            string requir_code = requir_num.Replace("-", ".");

            Strategy strategy = null;
            //if (requir_code == "7.2.1") { strategy = new Strategy_7_2_1(); }
            if (requir_code == "7.2.2") { strategy = new Strategy_7_2_2(); }
            if (requir_code == "7.2.3") { strategy = new Strategy_7_2_3(); }
            //if (fgos_num == "7.2.4") { strategy = new Strategy_7_2_4(); }
            // others fgos requirs

            if (strategy == null) { return null; }

            var requir = _unit.DirRequirs.GetOrDefault(x => x.DirId == dir_id && x.FgosNum == requir_code);

            Requir res = strategy.Execute(_unit, dir_id);

            return res;
        }

    }
}
