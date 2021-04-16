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
    public class BlockNumProfile : Profile
    {
        public BlockNumProfile()
        {
            CreateMap<BlockNumDto, BlockNum>()
                .ForMember(m => m.BlockNumName, opt => opt.MapFrom(m => m.BlockName))
                .ForMember(m => m.BlockNumId, opt => opt.MapFrom(m => m.BlockNumId))
                ;

            //CreateMap<BlockRec, SubjectDto>()
            //    .ForMember(m => m.SubjectName, opt => opt.MapFrom(m => m.BlockRec.Sub.SubName))

            //    .ForMember(m => m.Loads, opt => opt.MapFrom(m => m.BlockRec.TransformToLoadDto(m.))
            //    ;
        }
    }
}
