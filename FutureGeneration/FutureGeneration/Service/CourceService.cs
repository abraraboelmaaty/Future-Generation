using FutureGeneration.Data;
using FutureGeneration.Models;
using FutureGeneration.Repository;

namespace FutureGeneration.Service
{
    public class CourceService:IRepository<Cource>
    {
        Entites db;
        public CourceService(Entites _db)
        {
            db = _db;
        }

        public int Create(Cource crs)
        {
            try
            {
                db.Add(crs);
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
                var cource = db.Cources.FirstOrDefault(c => c.ID == id);
                if (cource == null)
                    return -2;
                db.Cources.Remove(cource);
                int raws = db.SaveChanges();
                return raws;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        public int Edit(int id, Cource crs)
        {
            try
            {
                Cource oldCource = db.Cources.FirstOrDefault(c => c.ID == id);
                if (oldCource == null)
                    return -2;
                oldCource.Status = crs.Status;
                oldCource.StartDate = crs.StartDate;
                oldCource.Capacity = crs.Capacity;
                oldCource.Cost = crs.Cost;
                oldCource.EndDate = crs.EndDate;
                oldCource.CourseSyllabus = crs.CourseSyllabus;
                int raws = db.SaveChanges();
                return raws;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        public ICollection<Cource> getAll()
        {
            return db.Cources.ToList();
        }

        public Cource getById(int id)
        {
            return db.Cources.FirstOrDefault(c => c.ID == id);
        }
    }
}
