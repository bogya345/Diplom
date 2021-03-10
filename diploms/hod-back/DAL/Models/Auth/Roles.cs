using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.DAL.Models.Auth
{
    /// <summary>
    /// Роли системы
    /// </summary>
    public class Roles
    {
        [Key]
        public int role_id { get; set; }    // generated (NOT AUTO-INCREMENT)

        public string role_name { get; set; }
    }

    /// Определенные роли на этапе разработки:
    /// 1) Администратор
    /// 2) УМУ отдел
    /// 3) Заведующий кафедрой
    /// 4) Преподаватель
    /// 
}
