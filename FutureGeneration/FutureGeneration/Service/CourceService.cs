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
                var Relations = db.StudentCources.Where(sc => sc.CourceId == id).ToList();
                if (Relations == null || Relations.Count == 0)
                {
                    db.Cources.Remove(cource);
                    int raws = db.SaveChanges();
                    return raws;
                }

                else
                {
                    int RelationRaws = 0;
                    foreach (var relation in Relations)
                    {
                        db.StudentCources.Remove(relation);
                        RelationRaws++;
                    }
                    if (RelationRaws == Relations.Count)
                    {
                        db.Cources.Remove(cource);
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
                if (!string.IsNullOrEmpty(crs.CourseSyllabus))
                {
                    oldCource.CourseSyllabus = crs.CourseSyllabus;
                }
                else
                {
                    oldCource.CourseSyllabus = oldCource.CourseSyllabus;
                }
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
