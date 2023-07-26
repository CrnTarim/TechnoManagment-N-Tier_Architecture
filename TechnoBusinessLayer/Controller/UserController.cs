using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechnoDataBase.Interface;
using TechnoEntity.Entities;

namespace TechnoBusinessLayer.Controller
{
    public class UserController
    {
        private readonly IRepository<User> _userRepo;
        public UserController(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }
        public int AddUser(User user)
        {
            return _userRepo.Add(user);
        }
        public int UpdateUser(User user, Guid id)
        {
            return _userRepo.Update(user, id);
        }
        public int DeleteUser(Guid id)
        {
            return _userRepo.Delete(id);
        }
        public List<User> GetAllUsers()
        {
            return _userRepo.GetAll();
        }
        public List<User> DeleteAllProducts()
        {
            return _userRepo.DeleteAll();
        }
        public List<User> FindProducts(Expression<Func<User, bool>> where)
        {
            return _userRepo.Find(where);
        }
    }
}
