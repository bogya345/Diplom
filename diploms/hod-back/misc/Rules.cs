using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.misc
{
    /// <summary>
    /// Тут те вещи, которые по идее надо организовать в бд
    /// я бы сделал сам, но у меня меньше месяца до защиты, так что извини
    /// сам понимаешь, я не волшебник чтобы все успеть
    /// </summary>
    public static class Rules
    {

        /// <summary>
        /// Требование ФГОС 7.2.2
        /// </summary>
        /// <param name="DegId">ID ученной степени (Degrees)</param>
        /// <param name="RankId">ID звания (Ranks)</param>
        /// <returns></returns>
        public static bool isFgos_7_2_2_Partial(int? DegId, int? RankId)
        {
            Random rdm = new Random();
            return (rdm.Next(0, 100) > 50);

            List<int> degs_needed = new List<int>() { 2, 3 };   // 2-д-р наук, 3-кандидат наук
            List<int> ranks_needed = new List<int>() { 4 }; // 4-доцент

            //return (degs_needed.Contains(DegId)) || (ranks_needed.Contains(RankId));
            return (DegId.HasValue && degs_needed.Contains(DegId.Value))
                || (!RankId.HasValue && ranks_needed.Contains(RankId.Value));
        }

        /// <summary>
        /// Требование ФГОС 7.2.3
        /// </summary>
        /// <param name="DegId">ID ученной степени (Degrees)</param>
        /// <param name="RankId">ID звания (Ranks)</param>
        /// <returns></returns>
        public static bool isFgos_7_2_3_Partial(int? DegId, int? RankId)
        {
            List<int> degs_needed = new List<int>() { 2, 3 };   // 2-д-р наук, 3-кандидат наук
            List<int> ranks_needed = new List<int>() { 4 }; // 4-доцент

            //return (degs_needed.Contains(DegId)) || (ranks_needed.Contains(RankId));
            return (DegId.HasValue && degs_needed.Contains(DegId.Value))
                || (RankId.HasValue && ranks_needed.Contains(RankId.Value));
        }

        /// <summary>
        /// Требование ФГОС 7.2.4
        /// </summary>
        /// <param name="DegId">ID ученной степени (Degrees)</param>
        /// <param name="RankId">ID звания (Ranks)</param>
        /// <returns></returns>
        public static bool isFgos_7_2_4_Partial(int? WorkTId)
        {

            List<int> workT_needed = new List<int>() { 2, 3 };   // 

            return (WorkTId.HasValue && workT_needed.Contains(WorkTId.Value));
        }

        ///// <summary>
        ///// Требование ФГОС 7.2.2
        ///// </summary>
        ///// <param name="DegId">ID ученной степени (Degrees)</param>
        ///// <param name="RankId">ID звания (Ranks)</param>
        ///// <returns></returns>
        //public static bool isFgos_7_2_2_Full(int? DegId, int? RankId)
        //{
        //    Random rdm = new Random();
        //    return (rdm.Next(0, 100) > 50);

        //    List<int> degs_needed = new List<int>() { 2, 3 };   // 2-д-р наук, 3-кандидат наук
        //    List<int> ranks_needed = new List<int>() { 4 }; // 4-доцент

        //    //return (degs_needed.Contains(DegId)) || (ranks_needed.Contains(RankId));
        //    return (DegId.HasValue && degs_needed.Contains(DegId.Value))
        //        || (!RankId.HasValue && ranks_needed.Contains(RankId.Value));
        //}

        ///// <summary>
        ///// Требование ФГОС 7.2.3
        ///// </summary>
        ///// <param name="DegId">ID ученной степени (Degrees)</param>
        ///// <param name="RankId">ID звания (Ranks)</param>
        ///// <returns></returns>
        //public static bool isFgos_7_2_3_Full(int? DegId, int? RankId)
        //{
        //    List<int> degs_needed = new List<int>() { 2, 3 };   // 2-д-р наук, 3-кандидат наук
        //    List<int> ranks_needed = new List<int>() { 4 }; // 4-доцент

        //    //return (degs_needed.Contains(DegId)) || (ranks_needed.Contains(RankId));
        //    return (DegId.HasValue && degs_needed.Contains(DegId.Value))
        //        || (RankId.HasValue && ranks_needed.Contains(RankId.Value));
        //}

        ///// <summary>
        ///// Требование ФГОС 7.2.4
        ///// </summary>
        ///// <param name="DegId">ID ученной степени (Degrees)</param>
        ///// <param name="RankId">ID звания (Ranks)</param>
        ///// <returns></returns>
        //public static bool isFgos_7_2_4_Full(int? WorkTId)
        //{

        //    List<int> workT_needed = new List<int>() { 2, 3 };   // 

        //    return (WorkTId.HasValue && workT_needed.Contains(WorkTId.Value));
        //}
    }
}
