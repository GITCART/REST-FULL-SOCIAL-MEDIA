using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    //class is no longer used
    public class UserRepository: IUserRepository
    {

        private readonly SocialMediaApiContext _socialMediaApiContext;

        public UserRepository(SocialMediaApiContext socialMediaApiContext)
        {
            _socialMediaApiContext = socialMediaApiContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _socialMediaApiContext.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetUser(int idUser)
        {
            var user = await _socialMediaApiContext.Users.FirstOrDefaultAsync(
                    user => user.Id == idUser
                );

            return user;
        }

       

        /*
        public async Task InsertUser(User user)
        {
            _socialMediaApiContext.Users.Add(user);
            await _socialMediaApiContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateUser(User user)
        {
            var currentUser = await GetUser(user.UserId);
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.Telephone = user.Telephone;

            int rows = await _socialMediaApiContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteUser(int idUser)
        {
            var currentUser = await GetUser(idUser);
            _socialMediaApiContext.Users.Remove(currentUser);

            int rows = await _socialMediaApiContext.SaveChangesAsync();
            return rows > 0;
        }*/
    }
}
