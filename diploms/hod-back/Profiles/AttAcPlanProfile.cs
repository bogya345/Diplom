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
    public class AttAcPlanProfile : Profile
    {
        public AttAcPlanProfile()
        {
            CreateMap<AttachedAcPlan, AttAcPlanDto>()
                .ForMember(m => m.fsh_id1, opt => opt.MapFrom(m => m.FshId1))
                .ForMember(m => m.fsh_id2, opt => opt.MapFrom(m => m.FshId2))
                .ForAllOtherMembers(m => m.Ignore())
                ;

        }
    }
}
