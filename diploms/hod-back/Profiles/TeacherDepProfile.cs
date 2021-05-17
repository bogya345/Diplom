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
    public class TeacherDepProfile : Profile
    {
        public TeacherDepProfile()
        {
            CreateMap<TeacherDep, TeacherDepDto>()
                .ForMember(m => m.Emp_id, opt => opt.MapFrom(m => m.EmpId))
                .ForMember(m => m.LastName, opt => opt.MapFrom(m => m.LastName))
                .ForMember(m => m.FirstName, opt => opt.MapFrom(m => m.FirstName))
                .ForMember(m => m.MiddleName, opt => opt.MapFrom(m => m.MiddleName))
                .ForMember(m => m.FullName, opt => opt.MapFrom(m => $"{m.LastName} {m.FirstName} {m.MiddleName}"))
                .ForMember(m => m.WorkT_name, opt => opt.MapFrom(m => m.WorkTName))
                .ForMember(m => m.Dep_id, opt => opt.MapFrom(m => m.DepId))
                //.ForMember(m => m.post_name, opt => opt.MapFrom(m => m.PostId))
                .ForMember(m => m.Fsh_id, opt => opt.MapFrom(m => m.FshId))
                .ForMember(m => m.StaffCount, opt => opt.MapFrom(m => m.StaffCount))
                .ForMember(m => m.DateBegin, opt => opt.MapFrom(m => m.DateBegin))
                .ForAllOtherMembers(m => m.Ignore())
                ;

            //CreateMap<AcPlanDep, DepDepDto>()
            //    .ForMember(m => m.acPlDep_id, opt => opt.MapFrom(m => m.AcPlDepId))
            //    .ForMember(m => m.acPlDep_name, opt => opt.MapFrom(m => m.AcPlDepName))

            //    .ForMember(m => m.dep_id, opt => opt.MapFrom(m => m.DepId))
            //    //.ForMember(m => m.dep_name, opt => opt.MapFrom(m => m.Dep.DepName))

            //    .ForAllOtherMembers(m => m.Ignore())
            //    ;

            //CreateMap<DepDepModel, AcPlanDep>()
            //    .ForMember(m => m.AcPlDepId, opt => opt.MapFrom(m => m.acPlDep_id))
            //    .ForMember(m => m.DepId, opt => opt.MapFrom(m => m.dep_id))
            //    .ForAllOtherMembers(m => m.Ignore())
            //    ;

        }
    }
}
