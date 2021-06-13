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
            List<int> c = new List<int>() { 31020, 31026, 31024, 31025 };
            if(c.Contains(item.DirId))
            {
                return 0;
            }

            List<int> c2 = new List<int>() { 21017 };
            if (c2.Contains(item.DirId))
            {
                return 2;
            }

            Strategy_7_2_ accum = new Strategy_7_2_();

            if (!accum.StoreIt(unit, item.DirId))
            { return -1; }

            // 4.4.3 (60)
            Strategy strategy1 = new Strategy_7_2_2();
            Requir tmp722 = strategy1.Execute_Partial(unit, accum.Dir, accum.items, accum.exList);

            // 4.4.5 - 7.2.3 (50)
            Strategy strategy2 = new Strategy_7_2_3();
            Requir tmp723 = strategy2.Execute_Partial(unit, accum.Dir, accum.items, accum.exList);

            // 4.4.4 (5)
            Strategy strategy3 = new Strategy_7_2_4();
            Requir tmp724 = strategy3.Execute_Partial(unit, accum.Dir, accum.items, accum.exList);

            if (tmp722.isDone && tmp723.isDone && tmp724.isDone) { return 2; }
            if (tmp722.isDone || tmp723.isDone || tmp724.isDone) { return 1; }
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
            List<int> c = new List<int>() { 31020, 31026, 31024, 31025 };
            if (c.Contains(DirId.Value))
            {
                var kek = Cruntches.ClutchHandlerPps(DirId.Value, dep_id.Value);
                if (kek != null) { return kek; }
            }

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

        public static Status ClutchHandlerPps(int DirId, int userDepId)
        {
            var res = new Status();

            switch (userDepId)
            {
                case 1:
                    {
                        res.Status_down = 3;
                        switch (DirId)
                        {
                            case 31020:
                                {
                                    res.Status_up = 3;
                                    return res;
                                }
                            case 31026:
                                {
                                    res.Status_up = 0;
                                    return res;
                                }
                            case 31024:
                                {
                                    res.Status_up = 1;
                                    return res;
                                }
                            case 31025:
                                {
                                    res.Status_up = 0;
                                    return res;
                                }
                        }
                        break;
                    }
                case 2:
                    {
                        res.Status_down = 2;
                        switch (DirId)
                        {
                            case 31020:
                                {
                                    res.Status_up = 2;
                                    return res;
                                }
                            case 31026:
                                {
                                    res.Status_up = 1;
                                    return res;
                                }
                            case 31024:
                                {
                                    res.Status_up = 0;
                                    return res;
                                }
                            case 31025:
                                {
                                    res.Status_up = 0;
                                    return res;
                                }
                        }
                        break;
                    }
            }

            return null;
        }

    }
}
