using eManager.Domain;
using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eManager.Web.Infrastructure
{
    public class DepartmentDb :DbContext, IDepartmentDataSource
    {
        public DepartmentDb()
            : base("DefaultConnection")
       {

        }

        public DbSet<Employee> Employes { get; set; }
        public DbSet<Department> Departments {get;set;}
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Video> videos { get; set; }
         
        
        void IDepartmentDataSource.Save()
        {
            SaveChanges();
        }

        IQueryable<Employee> IDepartmentDataSource.Employees
        {
            get { return Employes; }
        }

        IQueryable<Department> IDepartmentDataSource.Departments
        {
            get { return Departments; }
        }


        bool IDepartmentDataSource.ProxyCreationEnable
        {
           set {Configuration.ProxyCreationEnabled = value;} 
        }


        IQueryable<Video> IDepartmentDataSource.Videos
        {
            get { return videos; }
        }


        IQueryable<T> IDepartmentDataSource.Query<T>()
        {
            return Set<T>();
        }

        void IDepartmentDataSource.Update<T>(T entity)
        {
            Entry(entity).State = System.Data.EntityState.Modified;
        }


        void IDepartmentDataSource.Add<T>(T entity)
        {
            Set<T>().Add(entity);
        }


        void IDepartmentDataSource.Delete<T>(T entity)
        {
            Set<T>().Remove(entity);
        }
    }
}