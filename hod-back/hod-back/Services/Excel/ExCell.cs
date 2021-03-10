using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Services.Excel
{
    public class ExCell
    {
        public int Column { get; set; }
        public string ColumnName { get; set; }
        public int Row { get; set; }

        public ExCell(int c, int r, string cn)
        {
            Column = c;
            Row = r;
            ColumnName = cn;
        }

        public override string ToString()
        {
            return $"R = {Row.ToString()} | CN = {ColumnName}({Column})";
        }
    }
}
