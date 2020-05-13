using Core.Entities;

namespace Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        GenericRepository<JobInfo> JobInfoRepository { get; }
        GenericRepository<JobPortal> JobPortalRepository { get; }
        GenericRepository<JobUrl> JobUrlRepository { get; }
        GenericRepository<Salary> SalaryRepository { get; }
        GenericRepository<TagCategory> TagCategoryRepository { get; }
        GenericRepository<Tag> TagRepository { get; }

        void SaveChanges();

        void Dispose();
    }
}