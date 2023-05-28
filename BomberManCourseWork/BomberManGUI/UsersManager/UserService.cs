using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberManGUI.UsersManager
{
    public class UserService
    {
        private UserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }
        
        public void RegisterUser(User user)
        {
            if(user != null)
            {
                user.Id = Guid.NewGuid();
                _userRepository.Add(user);
            }

        }

        public bool AuthoriseUser(string name, string password)
        {
            var user = _userRepository.GetByPredicate(u => u.Name == name && u.Password == password);

            return user != null;
        }

        public bool CheckUserNameAvailability(string userName)
        {
            var user = _userRepository.GetByPredicate(u => u.Name == userName);

            if(user == null)
            {
                return true;
            }

            return false;
        }
    }
}
