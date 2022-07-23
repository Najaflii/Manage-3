using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositeries.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class StudentRepositories : IRepositories<Student>
    {
        private static int id;
        public Student Create(Student entity)
        {
            id++;
            entity.Id = id; 
            DbContext.Students.Add(entity);
            return entity;
        }

        public void Delete(Student entity)
        {
            DbContext.Students.Remove(entity);
        }

        public Student Get(Predicate<Student> filter = null)
        {
            if (filter == null)
            {
                return DbContext.Students[0];
            }
            else
            {
                return DbContext.Students.Find(filter);
            }
         
        }

        public List<Student> GetAll(Predicate<Student> filter = null)
        {
            if (filter==null)
            {
                return DbContext.Students;
            }
            else
            {
                return DbContext.Students.FindAll(filter);  
            }
        }





        public void Update(Student entity)
        {
            var student = DbContext.Students.Find(g => g.Id == entity.Id);

            if (entity !=null)
            {
                student.Name = entity.Name;
                student.Surname = entity.Surname;
                student.Age = entity.Age;
            }
        }
    }
}
