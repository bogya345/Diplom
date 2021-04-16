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
    public class SubDepProfile : Profile
    {
        public SubDepProfile()
        {
            CreateMap<Subject, SubDepDto>()

                .ForMember(m => m.sub_id, opt => opt.MapFrom(m => m.SubId))
                .ForMember(m => m.sub_name, opt => opt.MapFrom(m => m.SubName))

                .ForMember(m => m.acPlDep_id, opt => opt.MapFrom(m => m.AcPlDepId))
                .ForMember(m => m.acPlDep_name, opt => opt.MapFrom(m => m.AcPlDep.AcPlDepName))

                .ForMember(m => m.dep_id, opt => opt.MapFrom(m => m.AcPlDep.DepId))
                .ForMember(m => m.dep_name, opt => opt.MapFrom(m => m.AcPlDep.Dep.DepName))

                //.ForAllOtherMembers(m => m.Ignore())
                ;

        }
    }
}
