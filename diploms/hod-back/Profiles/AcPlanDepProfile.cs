using AutoMapper;
using hod_back.Dto;
using hod_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.Extentions;

namespace hod_back.Profiles
{
    public class AcPlanDepProfile : Profile
    {
        public AcPlanDepProfile()
        {
            //CreateMap<AcPlanDep, SubDepDto>()

            //    .ForMember(m => m.acPlDep_id, opt => opt.MapFrom(m => m.AcPlDepId))
            //    .ForMember(m => m.acPlDep_name, opt => opt.MapFrom(m => m.AcPlDepName))

            //    .ForMember(m => m.dep_id, opt => opt.MapFrom(m => m.DepId))
            //    .ForMember(m => m.dep_name, opt => opt.MapFrom(m => m.Dep.DepName))

            //    //.ForMember(m => m.sub_id, opt => opt.MapFrom(m => m.Su))
            //    .ForMember(m => m.acPlDep_id, opt => opt.MapFrom(m => m.AcPlDepId))

            //    .ForAllOtherMembers(m => m.Ignore())
            //    ;

        }
    }
}
