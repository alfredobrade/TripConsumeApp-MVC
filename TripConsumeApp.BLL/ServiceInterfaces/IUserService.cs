using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripConsumeApp.Entities;

namespace TripConsumeApp.BLL.ServiceInterfaces
{
    public interface IUserService
    {
        Task<User> Create(User user);
        Task<User> Edit(User user);
        Task<bool> Delete(int id);
        Task<User> GetByEmail(string email);
        Task<User> ValidateUser(string email, string password);
        Task<int> UsersQtity();
    }
}
