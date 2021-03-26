﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class SubjectsRepository : IRepository<Subject>
    {
        public SubjectsRepository(Context context) : base(context) { }


        public override void Create(Subject item)
        {
            db.Subjects.Add(item);
        }

        public IEnumerable<Subject> GetAll()
        {
            return db.Subjects;
        }

        public override IEnumerable<Subject> GetMany(Func<Subject, bool> func)
        {
            return db.Subjects.Where(func);
        }

        public override Subject OnExist(string name)
        {
            return db.Subjects.Where(x => x.SubName == name).FirstOrDefault();
        }

    }
}
