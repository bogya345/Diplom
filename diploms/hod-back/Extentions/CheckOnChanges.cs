using hod_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Extentions
{
    public static class CheckOnChanges
    {
        /// <summary>
        /// Проверяет объект с множеством других по дисциплине
        /// </summary>
        /// <param name="blockRec">Проверяемый предмет</param>
        /// <param name="items">Множество проверяющих</param>
        /// <returns>Индекс совпавшего элемента (либо -1)</returns>
        public static int IsSameSubject(this BlockRec blockRec, List<BlockRec> items)
        {
            for (int i = 0; i < items.Count(); i++)
            {
                bool fl = (blockRec.SubId == items[i].SubId) && (blockRec.SemestrNum == items[i].SemestrNum);
                if (fl)
                {
                    return i;
                }
            }
            return -1;
        }

        public static void RewriteValues(this BlockRec blockRec, BlockRec item)
        {
            blockRec.Ze = item.Ze;
            blockRec.Total = item.Total;
            blockRec.Les = item.Les;
            blockRec.Lab = item.Lab;
            blockRec.Pr = item.Pr;
            blockRec.Iz = item.Iz;
            blockRec.Ak = item.Ak;
            blockRec.Kpr = item.Kpr;
            blockRec.Sr = item.Sr;
            blockRec.Controll = item.Controll;
        }
    }


    class BlockRecCompareSubId : IEqualityComparer<BlockRec>
    {
        public bool Equals(BlockRec b1, BlockRec b2)
        {
            bool tmp = b1.SubId == b2.SubId;
            return tmp;
        }

        public int GetHashCode(BlockRec bx)
        {
            int hCode = bx.SubId == null ? (int)bx.SubId : -1;
            return hCode.GetHashCode();
        }
    }
}
