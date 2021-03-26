using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.DAL;

namespace hod_back.DAL.Models.ToParse
{
    public class Blocks
    {
        public string Name { get; set; }
        public List<BlockRecs> recs { get; set; }
    }
}
