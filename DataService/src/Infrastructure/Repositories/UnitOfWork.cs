using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Infrastructure.Db;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private DataContext context;
        private GenericRepository<JobUrl> jobUrlRepository;
        private GenericRepository<JobInfo> jobInfoRepository;
        private GenericRepository<JobPortal> jobPortalRepository;
        private GenericRepository<Tag> tagRepository;
        private GenericRepository<TagCategory> tagCategoryRepository;
        private GenericRepository<Salary> salaryRepository;

        public UnitOfWork(DataContext context)
        {
            this.context = context; 
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public GenericRepository<JobUrl> JobUrlRepository
        {
            get
            {
                if (this.jobUrlRepository == null)
                {
                    this.jobUrlRepository = new GenericRepository<JobUrl>(context);
                }
                return jobUrlRepository;
            }
        }

        public GenericRepository<JobInfo> JobInfoRepository
        {
            get
            {
                if (this.jobInfoRepository == null)
                {
                    this.jobInfoRepository = new GenericRepository<JobInfo>(context);
                }
                return jobInfoRepository;
            }
        }

        public GenericRepository<JobPortal> JobPortalRepository
        {
            get
            {
                if (this.jobPortalRepository == null)
                {
                    this.jobPortalRepository = new GenericRepository<JobPortal>(context);
                }
                return jobPortalRepository;
            }
        }

        public GenericRepository<Tag> TagRepository
        {
            get
            {
                if (this.tagRepository == null)
                {
                    this.tagRepository = new GenericRepository<Tag>(context);
                }
                return tagRepository;
            }
        }

        public GenericRepository<TagCategory> TagCategoryRepository
        {
            get
            {
                if (this.tagCategoryRepository == null)
                {
                    this.tagCategoryRepository = new GenericRepository<TagCategory>(context);
                }
                return tagCategoryRepository;
            }
        }

        public GenericRepository<Salary> SalaryRepository
        {
            get
            {
                if (this.salaryRepository == null)
                {
                    this.salaryRepository = new GenericRepository<Salary>(context);
                }
                return salaryRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
