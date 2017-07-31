using JoS.Models;
using System;

namespace JoS.Repository
{
    public interface IStartStudyRepository
    {
        StartStudy GetStudyDateByUserInfoId(int id);
        DateTime GetCurrentDateByUserId(int id);
        void Add(StartStudy startStudy);
        void Update(StartStudy entity);
        void Save();
    }
}
