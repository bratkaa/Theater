using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater.Model.DB
{
    class UserDbWorker
    {
        static ApplicationContext db = new ApplicationContext();

        public UserModel[] GetAllWorkers() 
        {
            return db.Users.ToArray();
        }
        public void CreateNewUser(UserModel model) 
        {
            bool userExist = db.Users.Any(u => u.Id == model.Id);
            if (!userExist)
            {
                db.Users.Add(model);
                db.SaveChanges();
            }
        }
        public void DeleteUser(UserModel model) 
        {
            bool userExist = db.Users.Any(u => u.Id == model.Id);
            if (userExist) 
            {
                db.Users.Remove(model);
                db.SaveChanges();
            }
        }
        public bool AutorizeUser(string login, string password, ref UserModel model)
        {
            bool userExist = db.Users.Any(u => u.Login== login && u.Password == password);
            if (userExist) 
            {
                model = db.Users
                    .Where(u => u.Login== login && u.Password == password)
                    .First();
                return true;
            }
            else return false;
        }
    }
}
