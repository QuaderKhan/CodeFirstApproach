using Somee.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Somee.Data
{
    public class UserDataAccess
    {
        public void Save(User userModel)
        {
            using (var db = new UserDBContext())
            {
                db.Users.Add(userModel);
                db.SaveChanges();
            }
        }

        public User GetUser(int Id)
        {
            using (var db = new UserDBContext())
            {
                return (from u in db.Users
                        where u.ID == Id
                        select u).FirstOrDefault();
            }
        }

        public IList<User> GetUsers()
        {
            using (var db = new UserDBContext())
            {
                return (from u in db.Users
                        select u).ToList<User>();
            }

        }

        public void Update(User user)
        {
            using (var db = new UserDBContext())
            {
                db.Entry(user).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
                    {
                        throw;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        public bool Delete(int id)
        {
            using (var db = new UserDBContext())
            {
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return false;
                }

                db.Users.Remove(user);
                db.SaveChanges();

                return true;
            }
        }

        public bool UserExists(int id)
        {
            using (var db = new UserDBContext())
            {
                return db.Users.Count(e => e.ID == id) > 0;
            }
        }
    }
}