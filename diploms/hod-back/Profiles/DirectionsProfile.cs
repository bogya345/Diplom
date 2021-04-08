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
    public class DirectionsProfile : Profile
    {
        public DirectionsProfile()
        {
            CreateMap<Direction, Direction>()
                .ForMember(dst => dst.AcPl, opt =>
                {
                    opt.Condition((s, d) => d.AcPl != s.AcPl && s.AcPl != null);
                    opt.MapFrom(s => s.AcPl);
                })
                .ForMember(dst => dst.DepId, opt =>
                {
                    opt.Condition((s, d) => d.DepId != s.DepId && s.DepId != null);
                    opt.MapFrom(s => s.DepId);
                })
                .ForMember(dst => dst.EBrId, opt =>
                {
                    opt.Condition((s, d) => d.EBrId != s.EBrId && s.EBrId != null);
                    opt.MapFrom(s => s.EBrId);
                })
                .ForMember(dst => dst.EFormId, opt =>
                {
                    opt.Condition((s, d) => d.EFormId != s.EFormId && s.EFormId != null);
                    opt.MapFrom(s => s.EFormId);
                })
                .ForMember(dst => dst.FacId, opt =>
                {
                    opt.Condition((s, d) => d.FacId != s.FacId && s.FacId != null);
                    opt.MapFrom(s => s.FacId);
                })
                .ForMember(dst => dst.KZavId, opt =>
                {
                    opt.Condition((s, d) => d.KZavId != s.KZavId && s.KZavId != null);
                    opt.MapFrom(s => s.KZavId);
                })
                .ForMember(dst => dst.YearObuch, opt =>
                {
                    opt.Condition((s, d) => d.YearObuch != s.YearObuch && s.YearObuch != null);
                    opt.MapFrom(s => s.YearObuch);
                })
                .ForMember(dst => dst.MonthObuch, opt =>
                {
                    opt.Condition((s, d) => d.MonthObuch != s.MonthObuch && s.MonthObuch != null);
                    opt.MapFrom(s => s.MonthObuch);
                })
                .ForMember(dst => dst.IsOld, opt =>
                {
                    opt.Condition((s, d) => d.IsOld != s.IsOld && s.IsOld != null);
                    opt.MapFrom(s => s.IsOld);
                })
                ;
        }
    }
}
