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
    public class BlockRecsProfile : Profile
    {
        public BlockRecsProfile()
        {

            CreateMap<DepsInfo, DepsInfoDto>()
                .ForMember(dest => dest.dep_id, opts => opts.MapFrom(src => src.DepId))
                .ForMember(dest => dest.dep_name, opts => opts.MapFrom(src => src.DepName))
                .ForMember(dest => dest.headTeach_name, opts => opts.MapFrom(src => src.LastName + " " + src.FirstName + " " + src.MiddleName))
                //.ForMember(dest => dest., opts => opts.MapFrom(src => src.))
                //.ForMember(dest => dest.dir)
                .ForMember(dest => dest.count_groups, opts => opts.MapFrom(src => src.CountGroups))
                .ForAllOtherMembers(m => m.Ignore())
                ;

            CreateMap<BlockRec, BlockRec>()
                //.ForMember(dst => dst.InPlan, opt =>
                //{
                //    opt.Condition((s, d) => d.InPlan != s.InPlan);
                //    opt.MapFrom(s => s.InPlan);
                //})
                //.ForMember(dst => dst.Ze, opt =>
                //{
                //    opt.Condition((s, d) => d.Ze != s.Ze);
                //    opt.MapFrom(s => s.Ze);
                //})
                //.ForMember(dst => dst.Total, opt =>
                //{
                //    opt.Condition((s, d) => d.Total != s.Total);
                //    opt.MapFrom(s => s.Total);
                //})
                //.ForMember(dst => dst.Les, opt =>
                //{
                //    opt.Condition((s, d) => d.Les != s.Les);
                //    opt.MapFrom(s => s.Les);
                //})
                //.ForMember(dst => dst.InPlan, opt =>
                //{
                //    opt.Condition((s, d) => d.InPlan != s.InPlan);
                //    opt.MapFrom(s => s.InPlan);
                //})
                //.ForAllOtherMembers(m => m.Ignore())
                ;

        }
    }
}
