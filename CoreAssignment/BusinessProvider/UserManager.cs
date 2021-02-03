using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAssignment
{
    public class UserManager : IDataRepository<User>
    {
        readonly ApplicationContext _userContext;
        public UserManager(ApplicationContext context)
        {
            _userContext = context;
        }
        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return _userContext.Users.ToList();
        }

        public void Update(User dbEntity, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
