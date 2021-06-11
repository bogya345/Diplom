using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class PackageRequirsDto
    {
        public bool Done { get; set; }
        public string Msg_text { get; set; }

        public RequirInfoDto[] Requirs { get; set; }

        public double NumA722 { get; set; }
        public double NumA723 { get; set; }
        public double NumA724 { get; set; }


        public double NumS722 { get; set; }
        public double NumS723 { get; set; }
        public double NumS724 { get; set; }

        public bool Mark722 { get; set; }
        public bool Mark723 { get; set; }
        public bool Mark724 { get; set; }
    }
}
