using firstWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace firstWeb.Repositories
{
    public class SchoolRepository
    {
        private SchoolContext db;

        public SchoolRepository(SchoolContext context)
        {
            db = context;
        }

        public ICollection<StudentBasic> getAllStudenten()
        {
            return db.Studenten.Select(s => new StudentBasic()
            {
                Id = s.Studnr,
                FirstName = s.Voornaam,
                LastName = s.Familienaam

            }).OrderBy(s => s.Id).ToList();
        }

        public StudentBasic getStudentById(int id)
        {
            return db.Studenten.Select(s => new StudentBasic()
            {
                Id = s.Studnr,
                FirstName = s.Voornaam,
                LastName = s.Familienaam
            }).Where(s => s.Id == id).FirstOrDefault();
        }

        public void addStudent(StudentBasic student)
        {
            db.Studenten.Add(new Studenten()
            {
                Studnr = student.Id,
                Voornaam = student.FirstName,
                Familienaam = student.LastName
            });

            db.SaveChanges();
        }

    }
}
