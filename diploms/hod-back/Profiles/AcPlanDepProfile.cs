using AutoMapper;
using hod_back.Dto;
using hod_back.Model;
using hod_back.Models;
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
            CreateMap<SubDepModel, AcPlanDep>()
                .ForMember(m => m.AcPlDepId, opt => opt.MapFrom(m => m.acPlDep_id))
                .ForMember(m => m.DepId, opt => opt.MapFrom(m => m.dep_id))
                .ForAllOtherMembers(m => m.Ignore())
                ;


            CreateMap<AcPlanDep, DepDepDto>()
                .ForMember(m => m.acPlDep_id, opt => opt.MapFrom(m => m.AcPlDepId))
                .ForMember(m => m.acPlDep_name, opt => opt.MapFrom(m => m.AcPlDepName))

                .ForMember(m => m.dep_id, opt => opt.MapFrom(m => m.DepId))
                //.ForMember(m => m.dep_name, opt => opt.MapFrom(m => m.Dep.DepName))

                .ForAllOtherMembers(m => m.Ignore())
                ;
            CreateMap<DepDepModel, AcPlanDep>()
                .ForMember(m => m.AcPlDepId, opt => opt.MapFrom(m => m.acPlDep_id))
                .ForMember(m => m.DepId, opt => opt.MapFrom(m => m.dep_id))
                .ForAllOtherMembers(m => m.Ignore())
                ;
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
