using FutureGeneration.Data;
using FutureGeneration.Models;
using FutureGeneration.Repository;

namespace FutureGeneration.Service
{
    public class StudentService : IRepository<Student>,IRepositoryAssignStudent<StudentCource>
    {
        Entites db;
        public StudentService(Entites _db)
        {
            db = _db;
        }

        public int Create(Student std)
        {
            db.Add(std);
            try
            {
                int raws = db.SaveChanges();
                return raws;
            }
            catch (Exception ex)
            {
                return -1;
            }
         
        }

        public int Delete(int id)
        {
            try
            {
                var student = db.Students.FirstOrDefault(c => c.ID == id);
                if (student == null)
                    return -2;
                var Relations = db.StudentCources.Where(sc => sc.StudentId == id).ToList();
                if (Relations == null || Relations.Count == 0)
                {
                    db.Students.Remove(student);
                    int raws = db.SaveChanges();
                    return raws;
                }

                else
                {
                    int RelationRaws = 0;
                    foreach(var relation in Relations)
                    {
                        db.StudentCources.Remove(relation);
                        RelationRaws ++;
                    }
                    if (RelationRaws == Relations.Count)
                    {
                        db.Students.Remove(student);
                        int raws = db.SaveChanges();
                        return raws;
                    }
                    return -3;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int Edit(int id, Student std)
        {
            try
            {
                var oldStudent = db.Students.FirstOrDefault(s => s.ID == id);
                if (oldStudent == null)
                    return -2;
                oldStudent.Name = std.Name;
                oldStudent.Email = std.Email;
                oldStudent.Address = std.Address;
                oldStudent.phone = std.phone;
                int raw = db.SaveChanges();
                return raw;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        public ICollection<Student> getAll()
        {
            return db.Students.ToList();
        }

        public Student getById(int id)
        {
            return db.Students.FirstOrDefault(s => s.ID == id);
        }
        public int Create(StudentCource StudentCource)
        {
            db.Add(StudentCource);
            try
            {
                int raws = db.SaveChanges();
                return raws;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
