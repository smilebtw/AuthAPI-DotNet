using AuthAPI.Models;
using AuthAPI.Models.Entities;

namespace AuthAPI.Repositories
{
    public interface IGroupRepository
    {
        public Group Read(Guid id);
        public bool Create(PostCreateGroup group);
        public bool Update(PutUpdateGroup group);
        public bool Delete(DeleteGroup group);
    }

    public class GroupRepository : IGroupRepository
    {
        private readonly DataContext context;

        public GroupRepository(DataContext _context)
        {
            context = _context;
        }

        public Group Read(Guid id)
        {
            try
            {
                var group = context.grupos.Find(id);
                return group;
            }
            catch
            {
                return new Group();

            }
        }

        public bool Create(PostCreateGroup group)
        {
            try
            {
                var groupDb = new Group()
                {
                    Grupos = group.Grupos
                };
                context.grupos.Add(groupDb);
                context.SaveChanges();

                return true;
            }
            catch
            {

                return false;
            }
        }
        
        public bool Update(PutUpdateGroup group)
        {
            var test = context.grupos.Find(group.Id);
            if (test == null)
            {
                return false;
            }
            test.Id = group.Id;
            test.Grupos = group.Grupos;


            context.SaveChangesAsync();

            return true;
        }

        public bool Delete(DeleteGroup group)
        {
            var test = context.grupos.Find(group.Id);
            if (test == null)
            {
                return false;
            }
            context.grupos.Remove(test);
            context.SaveChangesAsync();
            return true;
        }

    }
}
