using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Web.Models;

namespace Tutorial.Web.Services
{
    public class InMemoryRepository : IRepository<Student>
    {
        private readonly List<Student> _students;
        public InMemoryRepository()
        {
            _students = new List<Student>
            {
                new Student
                {
                    Id=1,
                    FirstName="张",
                    LastName="三",
                    Birthday=new DateTime(1998,1,6)
                },
                new Student
                {
                    Id=2,
                    FirstName="奶",
                    LastName="斯",
                    Birthday=new DateTime(1995,2,5)
                },
                new Student
                {
                    Id=3,
                    FirstName="旺",
                    LastName="仔",
                    Birthday=new DateTime(2000,1,2)
                }
            };
        }

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student GetById(int id)
        {
            return _students.FirstOrDefault(x => x.Id == id);
        }

        public Student Add(Student newModel)
        {
            var maxId = _students.Max(s => s.Id);
            newModel.Id = maxId + 1;
            _students.Add(newModel);
            return newModel;
        }
    }
}
