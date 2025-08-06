using My_new_API.Data;
using My_new_API.DTO_s;
using My_new_API.Repositories.Interfaces;

namespace My_new_API.Repositories
{
    public class SqlUserRepository:IUserRepository
    {
        public readonly DataContext _dataContext;
        public SqlUserRepository() { }
        //public IEnumerable<UserDTO> GetAllUsers()
        //{
        //    return _dataContext.Users.Select(user => new UserDTO
        //    {
        //        Id = user.Id,
        //        Name = user.Name,
        //        Email = user.Email,
        //        CreatedAt = user.CreatedAt
        //    }).ToList();
        //}
    }
}
