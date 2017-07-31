using JoS.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace JoS.Repository
{
    public class StartStudyRepository : IStartStudyRepository
    {
        private readonly ApplicationDbContext _ctx;

        public StartStudyRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public StartStudy GetStudyDateByUserInfoId(int id)
        {
            return _ctx.StartStudies.SingleOrDefault(s => s.Id == id);
        }

        public DateTime GetCurrentDateByUserId(int id)
        {
            return _ctx.StartStudies.Where(w => w.Id == id)
                                    .Select(s => s.StudyDate)
                                    .FirstOrDefault();
        }

        public void Add(StartStudy model)
        {
            _ctx.StartStudies.Add(model);
        }

        public void Update(StartStudy entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}