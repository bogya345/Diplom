using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.DAL;
using hod_back.DAL.Models.Auth;
using hod_back.DAL.Models.Dictionaries;
using hod_back.DAL.Models.ToSend;
using hod_back.DAL.Models.ToRecieve;
using hod_back.DAL.Models.Views;
using hod_back.DAL.Models;
using hod_back.DAL.Models.Auth;

namespace hod_back.DAL
{

    public static class LocalStorage
    {
        #region AuthData
        // тестовые данные вместо использования базы данных
        public static List<Roles> roles = new List<Roles>
        {
            new Roles { role_id = 1, role_name = "Преподаватель" },
            new Roles { role_id = 2, role_name = "Заведующий" },
            new Roles { role_id = 3, role_name = "Уму" },
            new Roles { role_id = 4, role_name = "Админ" },
            //new Roles { id_role = , name_role = "" },
        };
        public static List<Users> users = new List<Users>
        {
            new Users { user_id = 1, employee_id = 1, role_id = 1},
            new Users { user_id = 1, employee_id = 1, role_id = 2},
            new Users { user_id = 2, employee_id = 2, role_id = 1},
            new Users { user_id = 3, employee_id = 3, role_id = 1},
            new Users { user_id = 3, employee_id = 3, role_id = 2},
            new Users { user_id = 4, employee_id = 4, role_id = 3},
        };
        public static List<AuthUsers> authusers = new List<AuthUsers>
        {
            new AuthUsers { id_employee = 1, email="teach1@ugtu.net", password="qwer", id_department = 1,
                name_department = "втисит", id_role_actual = 2, name_role_actual = "Заведующий"},

            new AuthUsers { id_employee = 4, email="teach4@ugtu.net", password="qwer", id_department = 2,
                name_department = "пэмг", id_role_actual = 2, name_role_actual = "Заведующий"},

            new AuthUsers { id_employee = 9, email="emp9@ugtu.net", password="qwer", id_department = 5,
                name_department = "Уму", id_role_actual = 3, name_role_actual = "Уму"},

            new AuthUsers { id_employee = 10, email="emp10@ugtu.net", password="qwer", id_department = 6,
                name_department = "ИВЦ", id_role_actual = 4, name_role_actual = "Админ"},

        };

        #endregion

        public static List<Departments> deps = new List<Departments>
        {
            new Departments{dep_id = 1, dep_name = "втисист", dateCreated = DateTime.Now, dateEnd = null},
            new Departments{dep_id = 2, dep_name = "втисист2", dateCreated = DateTime.Now, dateEnd = DateTime.Now},
            new Departments{dep_id = 3, dep_name = "втисист3", dateCreated = DateTime.Now, dateEnd = null},
        };

        //public static List<Employees> emps = new List<Employees>
        //{
        //    new Employees{}
        //}

        public static List<ApplyTypes> applytypes = new List<ApplyTypes>
        {
            new ApplyTypes{ID = 1, NAME = "Основная"},
            new ApplyTypes{ID = 2, NAME = "Совмест"},
        };

        public static List<BlockRecs> blockrecs = new List<BlockRecs>
        {
            new BlockRecs{id_blockRec = 1, id_group = 1, semestrNum = 1, InPlan = 1, id_subject = 1, blockNum = "1 block", ze = 1, total = 1, les = 1, lab = 0, pr = 0, iz = 0, ak = 0, kpr = 0, sr = 0, controll = 0},
            new BlockRecs{id_blockRec = 2, id_group = 1, semestrNum = 1, InPlan = 1, id_subject = 1, blockNum = "1 block", ze = 1, total = 1, les = 1, lab = 0, pr = 0, iz = 0, ak = 0, kpr = 0, sr = 0, controll = 0},
            new BlockRecs{id_blockRec = 3, id_group = 1, semestrNum = 1, InPlan = 1, id_subject = 1, blockNum = "2 block", ze = 1, total = 1, les = 1, lab = 0, pr = 0, iz = 0, ak = 0, kpr = 0, sr = 0, controll = 0},
            new BlockRecs{id_blockRec = 4, id_group = 1, semestrNum = 1, InPlan = 1, id_subject = 1, blockNum = "3 block", ze = 1, total = 1, les = 1, lab = 0, pr = 0, iz = 0, ak = 0, kpr = 0, sr = 0, controll = 0},

            new BlockRecs{id_blockRec = 5, id_group = 2, semestrNum = 1, InPlan = 1, id_subject = 2, blockNum = "1 block", ze = 1, total = 2, les = 1, lab = 1, pr = 0, iz = 0, ak = 0, kpr = 0, sr = 0, controll = 0},
            new BlockRecs{id_blockRec = 6, id_group = 2, semestrNum = 1, InPlan = 1, id_subject = 2, blockNum = "2 block", ze = 1, total = 2, les = 1, lab = 1, pr = 0, iz = 0, ak = 0, kpr = 0, sr = 0, controll = 0},
            new BlockRecs{id_blockRec = 7, id_group = 2, semestrNum = 1, InPlan = 1, id_subject = 2, blockNum = "3 block", ze = 1, total = 2, les = 1, lab = 1, pr = 0, iz = 0, ak = 0, kpr = 0, sr = 0, controll = 0},

            //new BlockRecs{id_blockRec = 8, id_group = 2, semestrNum = 1, InPlan = 1, id_subject = 2, blockNum = "1 block", ze = 1, total = 3, les = 1, lab = 1, pr = 1, iz = 0, ak = 0, kpr = 0, sr = 0, controll = 0},
            //new BlockRecs{id_blockRec = 9, id_group = 2, semestrNum = 1, InPlan = 1, id_subject = 2, blockNum = "2 block", ze = 1, total = 3, les = 1, lab = 1, pr = 1, iz = 0, ak = 0, kpr = 0, sr = 0, controll = 0},
            //new BlockRecs{id_blockRec = 10, id_group = 2, semestrNum = 1, InPlan = 1, id_subject = 2, blockNum = "3 block", ze = 1, total = 3, les = 1, lab = 1, pr = 1, iz = 0, ak = 0, kpr = 0, sr = 0, controll = 0},
        };

        public static List<EducForms> educforms = new List<EducForms>
        {
            new EducForms{ID = 1, NAME = "Очно"},
            new EducForms{ID = 2, NAME = "Заочно"},
            new EducForms{ID = 3, NAME = "Очно-заочно"},
        };


        public static List<Groups> groups = new List<Groups>
        {
            new Groups{id_group = 1, name_group = "local_group1", startYear = new DateTime(2020,9,1), id_qualification = 1, id_educForm = 1, id_department = 1},
            new Groups{id_group = 2, name_group = "local_group2", startYear = new DateTime(2020,9,1), id_qualification = 1, id_educForm = 1, id_department = 1},
            new Groups{id_group = 3, name_group = "local_group3", startYear = new DateTime(2020,9,1), id_qualification = 1, id_educForm = 1, id_department = 2},
            new Groups{id_group = 4, name_group = "local_group4", startYear = new DateTime(2020,9,1), id_qualification = 1, id_educForm = 1, id_department = 3},
        };

        public static List<Qualifications> quals = new List<Qualifications>
        {
            new Qualifications{ID = 1, NAME = "Бакалавриат"},
            new Qualifications{ID = 2, NAME = "Магистратура"},
            new Qualifications{ID = 3, NAME = "Специалитет"},
        };

        public static List<Subjects> subs = new List<Subjects>
        {
            new Subjects{ID = 1, NAME = "local_sub1"},
            new Subjects{ID = 2, NAME = "local_sub2"},
            new Subjects{ID = 3, NAME = "local_sub3"},
            new Subjects{ID = 4, NAME = "local_sub4"},
            new Subjects{ID = 5, NAME = "local_sub5"},
        };

        //public static List<TeacherCathedra> teachcath = new List<TeacherCathedra>
        //{
        //    new TeacherCathedra{id_teacherCath = 1, id_teacher = 1, id_cathedra = 1, dateIn = new DateTime(2020,9,1), dateOut = null, id_applyType = 1},
        //    new TeacherCathedra{id_teacherCath = 2, id_teacher = 2, id_cathedra = 1, dateIn = new DateTime(2020,9,1), dateOut = null, id_applyType = 1},
        //    new TeacherCathedra{id_teacherCath = 3, id_teacher = 3, id_cathedra = 2, dateIn = new DateTime(2020,9,1), dateOut = null, id_applyType = 1},
        //    new TeacherCathedra{id_teacherCath = 4, id_teacher = 4, id_cathedra = 2, dateIn = new DateTime(2020,9,1), dateOut = null, id_applyType = 1},
        //    new TeacherCathedra{id_teacherCath = 5, id_teacher = 5, id_cathedra = 3, dateIn = new DateTime(2020,9,1), dateOut = null, id_applyType = 1},
        //};

        public static List<TeacherLoad> teachload = new List<TeacherLoad>
        {
            new TeacherLoad{id_blockRec = 1, typeSubject = "лек", hours = 1, id_employee = null},
            new TeacherLoad{id_blockRec = 1, typeSubject = "лаб", hours = 1, id_employee = null},
            new TeacherLoad{id_blockRec = 2, typeSubject = "лек", hours = 1, id_employee = null},
            new TeacherLoad{id_blockRec = 2, typeSubject = "лаб", hours = 1, id_employee = null},
            new TeacherLoad{id_blockRec = 3, typeSubject = "лек", hours = 1, id_employee = null},
            new TeacherLoad{id_blockRec = 3, typeSubject = "лаб", hours = 1, id_employee = null},
            new TeacherLoad{id_blockRec = 4, typeSubject = "лек", hours = 1, id_employee = null},
            new TeacherLoad{id_blockRec = 4, typeSubject = "лаб", hours = 1, id_employee = null},
        };

        public static List<Employees> teaches = new List<Employees>
        {
            new Employees{id_employee = 1, name_employee = "local_teacher1", rate = 1, dateApply = new DateTime(2020,9,1), dateFired = null, email = "local_email", id_department = 1},
            new Employees{id_employee = 2, name_employee = "local_teacher2", rate = 1, dateApply = new DateTime(2020,9,1), dateFired = null, email = "local_email", id_department = 2},
            new Employees{id_employee = 3, name_employee = "local_teacher3", rate = 1, dateApply = new DateTime(2020,9,1), dateFired = null, email = "local_email", id_department = 3},
            new Employees{id_employee = 4, name_employee = "local_teacher4", rate = 1, dateApply = new DateTime(2020,9,1), dateFired = null, email = "local_email", id_department = 1},
            new Employees{id_employee = 5, name_employee = "local_teacher5", rate = 1, dateApply = new DateTime(2020,9,1), dateFired = null, email = "local_email", id_department = 2},
        };

        #region Views

        public static List<CathInfo> cathinfo = new List<CathInfo>
        {
            new CathInfo{id_cathedra = 1, name_cathedra = "втисист", Head_id_teacher = 1, Head_name_teacher = "testteacher 1", count_groups = 111},
            new CathInfo{id_cathedra = 2, name_cathedra = "втисист1", Head_id_teacher = 2, Head_name_teacher = "testteacher 2", count_groups = 222},
            new CathInfo{id_cathedra = 3, name_cathedra = "втисист2", Head_id_teacher = 3, Head_name_teacher = "testteacher 3", count_groups = 333},
        };



        public static List<ViewTeacherLoad> viewsteachload = new List<ViewTeacherLoad>
        {
            new ViewTeacherLoad{blockrecs_id_blockRec = 1, id_group = 1, semestrNum = 1, InPlan = 1, blockNum = "1 block", id_subject = 1, subject = "local_sub1", teacherload_id_blockRec = 1, typeSubject = "les", hours = 1, id_employee = 1, name_employee = "local_teacher1"},
            new ViewTeacherLoad{blockrecs_id_blockRec = 1, id_group = 1, semestrNum = 1, InPlan = 1, blockNum = "1 block", id_subject = 1, subject = "local_sub1", teacherload_id_blockRec = 1, typeSubject = "lab", hours = 1, id_employee = 2, name_employee = "local_teacher2"},
            new ViewTeacherLoad{blockrecs_id_blockRec = 2, id_group = 1, semestrNum = 1, InPlan = 1, blockNum = "1 block", id_subject = 1, subject = "local_sub1", teacherload_id_blockRec = 1, typeSubject = "les", hours = 1, id_employee = 3, name_employee = "local_teacher3"},
            new ViewTeacherLoad{blockrecs_id_blockRec = 2, id_group = 1, semestrNum = 1, InPlan = 1, blockNum = "1 block", id_subject = 1, subject = "local_sub1", teacherload_id_blockRec = 1, typeSubject = "lab", hours = 1, id_employee = 4, name_employee = "local_teacher4"},
            new ViewTeacherLoad{blockrecs_id_blockRec = 3, id_group = 1, semestrNum = 1, InPlan = 1, blockNum = "1 block", id_subject = 1, subject = "local_sub1", teacherload_id_blockRec = 1, typeSubject = "les", hours = 1, id_employee = 5, name_employee = "local_teacher5"},
            new ViewTeacherLoad{blockrecs_id_blockRec = 3, id_group = 1, semestrNum = 1, InPlan = 1, blockNum = "1 block", id_subject = 1, subject = "local_sub1", teacherload_id_blockRec = 1, typeSubject = "lab", hours = 1, id_employee = 1, name_employee = "local_teacher1"},
        };


        #endregion

    }
}
