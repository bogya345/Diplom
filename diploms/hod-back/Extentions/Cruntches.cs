using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.DAL;
using hod_back.Dto;
using hod_back.Model;

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

        public static Status GetDirStatus(this DepDirFac value, int? DirId, UnitOfWork unit)
        {
            if (DirId == null) { return null; }

            var groups = unit.Groups.GetManyAsync(x => x.DirId == DirId)
                .Result.Select(x => x.GroupId);
            var tmp = unit.AttAcPlans.GetManyAsync(x => groups.Contains(x.GroupId.Value)).Result;
            var res = new Status();
            res.Status_up = tmp.Count(x => x.FshId != null);
            res.Status_down = tmp.Count();
            return res;
        }
    }
}
