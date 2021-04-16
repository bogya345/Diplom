using hod_back.Dto;
using hod_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Extentions
{
    /// <summary>
    /// Костыль на подобии mapper (почему так лучше лично спроси, т.к. писать устану)
    /// </summary>
    public static class Transformation
    {
        public static IEnumerable<AttachedAcPlan> TransformToAttAcPlan(this BlockRec blockRec, IEnumerable<Group> groups, IEnumerable<SubjectType> subTs = null)
        {
            List<AttachedAcPlan> tmp = new List<AttachedAcPlan>();

            foreach (var group in groups)
            {
                if (blockRec.Les != 0) { tmp.Add(new AttachedAcPlan { BlockRecId = blockRec.BlockRecId, GroupId = group.GroupId, HourValue = blockRec.Les, SubTId = 1 }); }
                if (blockRec.Lab != 0) { tmp.Add(new AttachedAcPlan { BlockRecId = blockRec.BlockRecId, GroupId = group.GroupId, HourValue = blockRec.Lab, SubTId = 2 }); }
                if (blockRec.Pr != 0) { tmp.Add(new AttachedAcPlan { BlockRecId = blockRec.BlockRecId, GroupId = group.GroupId, HourValue = blockRec.Pr, SubTId = 3 }); }
                if (blockRec.Iz != 0) { tmp.Add(new AttachedAcPlan { BlockRecId = blockRec.BlockRecId, GroupId = group.GroupId, HourValue = blockRec.Iz, SubTId = 4 }); }
                if (blockRec.Ak != 0) { tmp.Add(new AttachedAcPlan { BlockRecId = blockRec.BlockRecId, GroupId = group.GroupId, HourValue = blockRec.Ak, SubTId = 5 }); }
                if (blockRec.Kpr != 0) { tmp.Add(new AttachedAcPlan { BlockRecId = blockRec.BlockRecId, GroupId = group.GroupId, HourValue = blockRec.Kpr, SubTId = 6 }); }
                if (blockRec.Sr != 0) { tmp.Add(new AttachedAcPlan { BlockRecId = blockRec.BlockRecId, GroupId = group.GroupId, HourValue = blockRec.Sr, SubTId = 7 }); }
                if (blockRec.Controll != 0) { tmp.Add(new AttachedAcPlan { BlockRecId = blockRec.BlockRecId, GroupId = group.GroupId, HourValue = blockRec.Controll, SubTId = 8 }); }
            }

            return tmp;
        }

        public static LoadDto TransformToLoadDto(this AttachedAcPlan item, int? SemNum)
        {
            LoadDto res = new LoadDto()
            {
                atAcPlId = item.AttAcPlId,
                FshId = item.FshId,
                LoadValue = (double)item.HourValue,
                SemNum = SemNum,
                SubTypeName = item.SubT.SubTName,
            };
            return res;
        }

        public static DepsDto TransformToDepsDto(this Department item)
        {
            if (item == null) { return null; }
            var res = new DepsDto()
            {
                dep_id = item.DepId,
                dep_name = item.DepName,
                dirs = null
            };
            return res;
        }

        public static SubjectDto[] TransformToSubjectDtoArray(this ICollection<BlockRec> items, int acPl_id, int group_id)
        {
            items = items.Where(x => x.AcPlId == acPl_id).ToList();

            List<SubjectDto> res = new List<SubjectDto>();

            foreach (var i in items)
            {
                if (i.Total != 0)
                {
                    res.Add(new SubjectDto()
                    {
                        SubjectName = i.Sub.SubName,
                        CorrespDep = i.Sub.AcPlDep.Dep.TransformToDepsDto(),
                        SemestrNum = i.SemestrNum,
                        Loads = i.AttachedAcPlans.TransformToLoadDtoArray(group_id)
                    });
                }
            }

            return res.ToArray();
        }
        public static LoadDto[] TransformToLoadDtoArray(this IEnumerable<AttachedAcPlan> items, int group_id)
        {
            items = items.Where(x => x.GroupId == group_id).ToList();

            List<LoadDto> res = new List<LoadDto>();

            foreach (var item in items)
            {
                res.Add(new LoadDto()
                {
                    atAcPlId = item.AttAcPlId,
                    FshId = item.FshId,
                    LoadValue = (double)item.HourValue,
                    SemNum = item.BlockRec.SemestrNum,
                    SubTypeName = item.SubT.SubTName,
                });
            }

            return res.ToArray();
        }

        //public static LoadDto TransformToLoadDto(this AttachedAcPlan item, int? SemNum)
        //{
        //    LoadDto res = new LoadDto()
        //    {
        //        atAcPlId = item.AttAcPlId,
        //        FshId = item.FshId,
        //        LoadValue = (double)item.HourValue,
        //        SemNum = SemNum,
        //        SubTypeName = item.SubT.SubTName,
        //    };
        //    return res;
        //}

        public static IEnumerable<LoadDto> TransformToLoadDto(this BlockRec blockRec, IEnumerable<AttachedAcPlan> attAcPls)
        {
            List<LoadDto> tmp = new List<LoadDto>();



            if (blockRec.Les != 0)
            {
                var lul = attAcPls.FirstOrDefault(x => x.BlockRecId == blockRec.BlockRecId && x.SubTId == 1);
                tmp.Add(new LoadDto
                {
                    FshId = lul.FshId,
                    LoadValue = (double)blockRec.Les,
                    SubTypeName = lul.SubT.SubTName,
                    SubTypeId = lul.SubT.SubTId,
                    SemNum = blockRec.SemestrNum
                });
            }
            if (blockRec.Lab != 0)
            {
                var lul = attAcPls.FirstOrDefault(x => x.BlockRecId == blockRec.BlockRecId && x.SubTId == 1);
                tmp.Add(new LoadDto
                {
                    FshId = lul.FshId,
                    LoadValue = (double)blockRec.Les,
                    SubTypeName = lul.SubT.SubTName,
                    SubTypeId = lul.SubT.SubTId,
                    SemNum = blockRec.SemestrNum
                });
            }
            //if (blockRec.Lab != 0) { tmp.Add(new LoadDto { BlockRecId = blockRec.BlockRecId, GroupId = group.GroupId, HourValue = blockRec.Lab, SubTId = 2 }); }
            //if (blockRec.Pr != 0) { tmp.Add(new LoadDto { BlockRecId = blockRec.BlockRecId, GroupId = group.GroupId, HourValue = blockRec.Pr, SubTId = 3 }); }
            //if (blockRec.Iz != 0) { tmp.Add(new AttachedAcPlan { BlockRecId = blockRec.BlockRecId, GroupId = group.GroupId, HourValue = blockRec.Iz, SubTId = 4 }); }
            //if (blockRec.Ak != 0) { tmp.Add(new AttachedAcPlan { BlockRecId = blockRec.BlockRecId, GroupId = group.GroupId, HourValue = blockRec.Ak, SubTId = 5 }); }
            //if (blockRec.Kpr != 0) { tmp.Add(new AttachedAcPlan { BlockRecId = blockRec.BlockRecId, GroupId = group.GroupId, HourValue = blockRec.Kpr, SubTId = 6 }); }
            //if (blockRec.Sr != 0) { tmp.Add(new AttachedAcPlan { BlockRecId = blockRec.BlockRecId, GroupId = group.GroupId, HourValue = blockRec.Sr, SubTId = 7 }); }
            //if (blockRec.Controll != 0) { tmp.Add(new AttachedAcPlan { BlockRecId = blockRec.BlockRecId, GroupId = group.GroupId, HourValue = blockRec.Controll, SubTId = 8 }); }

            return tmp;
        }
    }
}
