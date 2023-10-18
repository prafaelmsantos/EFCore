using EFCore.API.Context;
using EFCore.API.Interfaces;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EFCoreContext _context;
        public UserRepository(EFCoreContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users
                .Include(a => a.Contact)
                .OrderBy(a => a.Id)
                .ToList();
        }
        public User GetById(int id)
        {
            //EFCore = 1; Dapper = +20; ADO.NET = +40;
            return _context.Users
                .Include(a => a.Contact)
                .Include(a => a.DeliveryAddress)
                .Include(a => a.Departments)
                .FirstOrDefault(a => a.Id == id)!;
        }
        public void Add(User user)
        {
            /*
             * Unit of Works
             */
            SetDepartments(user);

            _context.Users.Add(user);
            _context.SaveChanges();
        }


        public void Update(User user)
        {
            //EF Core - Tracking
            DeleteDepartaments(user);

            SetDepartments(user);

            _context.Users.Update(user);
            _context.SaveChanges();
        }


        public void Delete(int id)
        {
            _context.Users.Remove(GetById(id));
            _context.SaveChanges();
        }


        private void SetDepartments(User user)
        {
            if (user.Departments != null)
            {

                foreach (var departament in user.Departments)
                {
                    if (departament.Id > 0)
                    {
                        //Ref. Registro do Banco de dados
                        user.Departments.Add(_context.Departments.Find(departament.Id)!);
                    }
                    else
                    {
                        //Ref. Objeto novo, que não existe no SGDB. (Novo registro de Departamento)
                        user.Departments.Add(departament);
                    }
                }
            }
        }

        private void DeleteDepartaments(User user)
        {
            var userDB = _context.Users.Include(a => a.Departments).FirstOrDefault(a => a.Id == user.Id);
            foreach (var departament in userDB!.Departments!)
            {
                userDB.Departments.Remove(departament);
            }
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }
}
