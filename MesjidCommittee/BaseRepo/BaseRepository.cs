using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MesjidCommittee.DAL;
using System.Data;
using System.Data.Entity;


namespace MesjidCommittee.BaseRepo
{
    public class BaseRepository
    {
        private MesjidDbContext db;

        public BaseRepository()
        {
            db = new MesjidDbContext();
        }
        public BaseRepository(MesjidDbContext dbContext) {
            db = dbContext;
        }

        public MesjidDbContext getDb()
        {
            return db;
        }

        public void Add<T>(T newItem) where T : class
        {
            db.Set<T>().Add(newItem);
            db.SaveChanges();
        }
        public void Update<T>(T item) where T : class
        {
            db.Set<T>().Attach(item);
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Remove<T>(T newItem) where T : class
        {
            db.Set<T>().Remove(newItem);
            db.SaveChanges();
        }
    }
}