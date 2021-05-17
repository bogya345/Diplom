using AutoMapper;
using hod_back.Model;
using hod_back.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hod_back.DAL;

namespace hod_back.Profiles
{
    public class DepartmentsProfile : Profile
    {
        public DepartmentsProfile()
        {
            //UnitOfWork unit = new UnitOfWork();

            CreateMap<DepsInfo, DepsInfoDto>()
                .ForMember(dest => dest.Dep_id, opts => opts.MapFrom(src => src.DepId))
                .ForMember(dest => dest.Dep_name, opts => opts.MapFrom(src => src.DepName))
                .ForMember(dest => dest.HeadTeach_name, opts => opts.MapFrom(src => src.LastName + " " + src.FirstName + " " + src.MiddleName))
                //.ForMember(dest => dest., opts => opts.MapFrom(src => src.))
                //.ForMember(dest => dest.dir)
                .ForMember(dest => dest.Count_groups, opts => opts.MapFrom(src => src.CountGroups))
                .ForAllOtherMembers(m => m.Ignore())
                ;

            CreateMap<Department, DepsDto>()
                .ForMember(dest => dest.Dep_id, opts => opts.MapFrom(src => src.DepId))
                .ForMember(dest => dest.Dep_name, opts => opts.MapFrom(src => src.DepShortname))
                //.ForMember(dest => dest.dirs, opts => opts.MapFrom(src => src.Directions)) // useless at least for now
                .ForAllOtherMembers(m => m.Ignore())
                ;

            //CreateMap<DepDirFac, DepsDto>()
            //    .ForMember(dest => dest.dep_id, opts => opts.MapFrom(src => src.DepId))
            //    //.ForMember(dest => dest.dep_guid, opts => opts.MapFrom(src => src.DepGuid))
            //    .ForMember(dest => dest.dep_name, opts => opts.MapFrom(src => src.DepName))
            //    .ForMember(dest => dest.dirs, opts => opts.MapFrom(src =>
            //        unit.DirGroups.GetMany(x => x.DepId == src.DepId).ToList().ForEach(x => _mapper
            //    ))
            //    .ForAllOtherMembers(m => m.Ignore())
            //    ;
            //CreateMap<Dir>

        }
    }
}
