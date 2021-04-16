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
                .ForMember(dst => dst.BlockRecId, opt =>
                {
                    //opt.Condition((s, d) => d.BlockRecId != s.BlockRecId);
                    opt.Condition((s, d) => true);
                    opt.MapFrom(s => s.BlockNumId);
                })
                .ForAllMembers(m => m.Ignore())
                ;

            //CreateMap<BlockRec, BlockRec>()
            //    .ForMember(dst => dst.BlockRecId, opt =>
            //    {
            //        //opt.Condition((s, d) => d.BlockRecId != s.BlockRecId);
            //        opt.Condition((s, d) => true);
            //        opt.MapFrom((s, d) => d.BlockNumId);
            //    })
            //    .ForMember(dst => dst.AcPlId, opt =>
            //    {
            //        //opt.Condition((s, d) => d.AcPlId != s.AcPlId);
            //        opt.Condition((s, d) => true);
            //        opt.MapFrom(s => s.AcPlId);
            //    })
            //    .ForMember(dst => dst.BlockNumId, opt =>
            //    {
            //        //opt.Condition((s, d) => d.BlockNumId != s.BlockNumId);
            //        opt.Condition((s, d) => true);
            //        opt.MapFrom(s => s.BlockNumId);
            //    })
            //    .ForMember(dst => dst.SemestrNum, opt =>
            //    {
            //        //opt.Condition((s, d) => d.SemestrNum != s.SemestrNum);
            //        opt.Condition((s, d) => true);
            //        opt.MapFrom(s => s.SemestrNum);
            //    })
            //    .ForMember(dst => dst.SubId, opt =>
            //    {
            //        //opt.Condition((s, d) => d.SubId != s.SubId);
            //        opt.Condition((s, d) => true);
            //        opt.MapFrom(s => s.SubId);
            //    })
            //    .ForMember(dst => dst.InPlan, opt =>
            //    {
            //        //opt.Condition((s, d) => d.InPlan != s.InPlan);
            //        opt.Condition((s, d) => true);
            //        opt.MapFrom(s => s.InPlan);
            //    })
            //    .ForMember(dst => dst.Ze, opt =>
            //    {
            //        opt.Condition((s, d) => d.Ze != s.Ze);
            //        opt.MapFrom(s => s.Ze);
            //    })
            //    .ForMember(dst => dst.Total, opt =>
            //    {
            //        //opt.Condition((s, d) => d.Total != s.Total);
            //        opt.Condition((s, d) => true);
            //        opt.MapFrom(s => s.Total);
            //    })
            //    .ForMember(dst => dst.Les, opt =>
            //    {
            //        //opt.Condition((s, d) => d.Les != s.Les);
            //        opt.Condition((s, d) => true);
            //        opt.MapFrom(s => s.Les);
            //    })
            //    .ForMember(dst => dst.Lab, opt =>
            //    {
            //        //opt.Condition((s, d) => d.Lab != s.Lab);
            //        opt.Condition((s, d) => true);
            //        opt.MapFrom(s => s.Lab);
            //    })
            //    .ForMember(dst => dst.Pr, opt =>
            //    {
            //        //opt.Condition((s, d) => d.Pr != s.Pr);
            //        opt.Condition((s, d) => true);
            //        opt.MapFrom(s => s.Pr);
            //    })
            //    .ForMember(dst => dst.Iz, opt =>
            //    {
            //        //opt.Condition((s, d) => d.Iz != s.Iz);
            //        opt.Condition((s, d) => true);
            //        opt.MapFrom(s => s.Iz);
            //    })
            //    .ForMember(dst => dst.Ak, opt =>
            //    {
            //        //opt.Condition((s, d) => d.Ak != s.Ak);
            //        opt.Condition((s, d) => true);
            //        opt.MapFrom(s => s.Ak);
            //    })
            //    .ForMember(dst => dst.Kpr, opt =>
            //    {
            //        //opt.Condition((s, d) => d.Kpr != s.Kpr);
            //        opt.Condition((s, d) => true);
            //        opt.MapFrom(s => s.Kpr);
            //    })
            //    .ForMember(dst => dst.Sr, opt =>
            //    {
            //        //opt.Condition((s, d) => d.Sr != s.Sr);
            //        opt.Condition((s, d) => true);
            //        opt.MapFrom(s => s.Sr);
            //    })
            //    .ForMember(dst => dst.Controll, opt =>
            //    {
            //        //opt.Condition((s, d) => d.Controll != s.Controll);
            //        opt.Condition((s, d) => true);
            //        opt.MapFrom(s => s.Controll);
            //    })
            //    //.ForMember(dst => dst.BlockRecId, opt => opt.Ignore())
            //    .ForAllOtherMembers(m => m.Ignore())
            //    ;

        }
    }
}
