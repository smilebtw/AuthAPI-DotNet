using AuthAPI.Models.Entities;
using AuthAPI.Models;


namespace AuthAPI.Repositories
{ 
    public interface IUserRepository
    {
        public bool Register(PostRegisterUser user);
        public bool Login(PostLoginUser user);
        public bool Delete(DeleteLoginUser user);
        public bool Update(PutLoginUser user);
        public User Read(Guid id);
    }
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;

        public UserRepository(DataContext _context)
        {
            context = _context;
        }
        public bool Register(PostRegisterUser user)
        {
            try
            {
                var userDb = new User()
                {
                    Cpf = user.Cpf,
                    Email = user.Email,
                    Name = user.Name,
                    Password = user.Password,
                    Status = user.Status,
                    CodigoRh = user.CodigoRh,
                    Group = user.Group

                };
                context.usuarios.Add(userDb);
                context.SaveChanges();

                return true;
            }
            catch 
            {

                return false;
            }
        }
        public bool Login(PostLoginUser user)
        {
            try
            {
                var test = context.usuarios.Single(p => p.Email == user.Email);
                if (test.Status != 1)
                {
                    return false;
                }
                if (user.Password == test.Password && user.Email == test.Email)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(DeleteLoginUser user)
        {
            var test = context.usuarios.Find(user.Id);
            if (test == null)
            {
                return false;
            }
            context.usuarios.Remove(test);
            context.SaveChangesAsync();
            return true;
        }

        public bool Update(PutLoginUser user)
        {
            var test = context.usuarios.Find(user.Id);
            if (test == null)
            {
                return false;
            }
            test.Id = user.Id;
            test.Group = user.Group;
            test.Cpf = user.Cpf;
            test.Email = user.Email;
            test.Password = user.Password;
            test.Status = user.Status;
            test.CodigoRh = user.CodigoRh;
            test.Name = user.Name;

            context.SaveChangesAsync();

            return true;
        }

        public User Read(Guid id)
        {
            try
            {
                var user = context.usuarios.Find(id);
                return user;
            }
            catch
            {
                return new User();
                
            }
        }
    }
}
