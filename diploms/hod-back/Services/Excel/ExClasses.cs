using hod_back.misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Services.Excel
{
    public class exTeacher
    {
        public int RowIndex { get; set; }
        //public string Column { get; set; }

        public string Fullname { get; set; }
        public int? DegId { get; set; }
        public int? RankId { get; set; }
        public bool IsInner { get; set; }

        public List<exSubject> Subs { get; set; }

        public float TotalHours { get { float tmp = Subs.Sum(x => (float)x.Rate); return tmp; } }
        public float TotalRate { get { float tmp = Subs.Sum(x => (float)x.Rate); return tmp; } }

        public bool is722 { get { return Rules.isFgos_7_2_2(DegId, RankId); } } //
        public bool is723 { get { return Rules.isFgos_7_2_3(DegId, RankId); } }
        public bool is724 { get { return IsInner; } }
    }
    public class exSubject
    {
        public string SubName { get; set; }
        public double Les { get; set; }
        public double LabPr { get; set; }
        public double Iz { get; set; }
        public double Ak { get; set; }
        public double Total { get { return (Les + LabPr + Iz + Ak); } }
        public double Rate { get { return Math.Round((Total / 900), 2); } }
    }
}
