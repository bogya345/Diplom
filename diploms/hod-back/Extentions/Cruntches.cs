using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.DAL;
using hod_back.Dto;
using hod_back.Dto.Analyser.FgosRequirs;
using hod_back.Model;
using hod_back.Services.Analyse;

namespace hod_back.Extentions
{
    public static class Cruntches
    {
        public static string NewFgos(this string value)
        {
            if (value.Contains("2.2")) { return "4.4.3"; }
            if (value.Contains("2.4")) { return "4.4.4"; }
            if (value.Contains("2.3")) { return "4.4.5"; }
            return value;
        }

        public static int HighlightNum(this Direction item, UnitOfWork unit)
        {
            Strategy_7_2_ accum = new Strategy_7_2_();

            if (!accum.StoreIt(unit, item.DirId)) 
            { return -1; }

            // 4.4.3
            Strategy strategy1 = new Strategy_7_2_2();
            Requir tmp722 = strategy1.Execute_Partial(unit, accum.Dir, accum.items, accum.exList);

            // 4.4.5 - 7.2.3
            Strategy strategy2 = new Strategy_7_2_3();
            Requir tmp723 = strategy2.Execute_Partial(unit, accum.Dir, accum.items, accum.exList);

            // 4.4.4
            Strategy strategy3 = new Strategy_7_2_4();
            Requir tmp724 = strategy3.Execute_Partial(unit, accum.Dir, accum.items, accum.exList);

            if(tmp722.isDone && tmp723.isDone && tmp724.isDone) { return 2; }
            if(tmp722.isDone || tmp723.isDone || tmp724.isDone) { return 1; }
            return 0;
        }

        public static Status GetDirStatus(this DepDirFac value, int? DirId, UnitOfWork unit)
        {
            if (DirId == null) { return null; }

            var groups = unit.Groups.GetManyAsync(x => x.DirId == DirId)
                .Result.Select(x => x.GroupId);
            var tmp = unit.AttAcPlans.GetManyAsync(x => groups.Contains(x.GroupId.Value)).Result;
            var res = new Status();
            res.Status_up = tmp.Count(x => x.FshId1 != null);
            res.Status_down = tmp.Count();
            return res;
        }
        public static Status GetDirStatus(this Direction value, int? DirId, UnitOfWork unit)
        {
            var groups = unit.Groups.GetManyAsync(x => x.DirId == DirId)
                .Result.Select(x => x.GroupId);
            var tmp = unit.AttAcPlans.GetManyAsync(x => groups.Contains(x.GroupId.Value)).Result;
            var res = new Status();
            res.Status_up = tmp.Count(x => x.FshId1 != null);
            res.Status_down = tmp.Count();
            return res;
        }

        public static Status GetDirStatus(this Direction value, int? DirId, UnitOfWork unit, int? dep_id)
        {
            var groups = unit.Groups.GetManyAsync(x => x.DirId == DirId)
                .Result.Select(x => x.GroupId);

            var tmp = unit.AttAcPlans.GetManyAsync(
                x => groups.Contains(x.GroupId.Value)
                ).Result;

            var tmp2 = tmp.GroupBy(x => x.BlockRec.Sub);

            var res = new Status();
            res.Status_up = tmp2.Count(x => x.ToList()[0].FshId1 != null);
            res.Status_down = tmp2.Count();
            return res;
        }
        public static Status GetDirStatusPPS(this Direction value, int? DirId, UnitOfWork unit, int? dep_id)
        {
            var groups = unit.Groups.GetManyAsync(x => x.DirId == DirId)
                .Result.Select(x => x.GroupId);

            var tmp = unit.AttAcPlans.GetManyAsync(
                x => groups.Contains(x.GroupId.Value) &&
                x.BlockRec.Sub.AcPlDep.DepId == dep_id
                ).Result;

            var tmp2 = tmp.GroupBy(x => x.BlockRec.Sub);

            var res = new Status();
            res.Status_up = tmp2.Count(x => x.ToList()[0].FshId1 != null);
            res.Status_down = tmp2.Count();
            return res;
        }
    }
}
