using DocumentFormat.OpenXml.InkML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
    public class PersonsRepo : IRepository<Person>
    {
        public PersonsRepo(MyContext context) : base(context) { }


        public override void Create(Person item)
        {
            db.Persons.Add(item);
        }

        public override void Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public override void Delete(string itemName)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Person item)
        {
            throw new NotImplementedException();
        }

        public Person Get(int id)
        {
            return db.Persons.FirstOrDefault(p=>p.IdPerson == id);
        }
        public override Person Get(Func<Person, bool> func)
        {
            return db.Persons.FirstOrDefault(func);
        }

        public IEnumerable<Person> GetAll()
        {
            //throw new NotImplementedException();
            IEnumerable<Person> tmp = db.Persons;

            return db.Persons.ToList();

        }
        public override IEnumerable<Person> GetAll(Func<Person, bool> func)
        {
            return db.Persons.Where(func);
        }

        public override Person OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Person item)
        {
            throw new NotImplementedException();
        }
    }
}
