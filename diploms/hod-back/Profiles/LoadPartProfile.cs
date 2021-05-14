using AutoMapper;
using hod_back.Dto;
using hod_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.Extentions;
using hod_back.Models;

namespace hod_back.Profiles
{
    public class LoadPartProfile : Profile
    {
        public LoadPartProfile()
        {
            //CreateMap<AttachedAcPlan, LoadPartDto>()
            //    .ForMember(m => m.fsh_id, opt => opt.MapFrom(m => m.AttAcPlId))
            //    .ForMember(m => m.teacherName, opt => opt.MapFrom(m => m.Fsh))
            //    .ForAllOtherMembers(m => m.Ignore())
            //    ;

        }
    }
}
