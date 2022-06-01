
using ChatApi.Models;

namespace ChatApi.Services
{
    public abstract class AbstractUserService : ChatService
    {

        public new abstract List<User> GetAll();

        public new abstract User Get(string id);

        public abstract void Edit(User curr, User update);

        public abstract void Delete(string id);
        
        public abstract int Count();

        public abstract void Add(User user);

        public abstract void Friend(User u1, User u2);
        
        public abstract void Unfriend(User u1, User u2);
        
        public abstract void Edit(string id, string name, string server);
        
        public abstract List<UserApiResponse> Get(User u);
        public abstract Boolean IsPasswordValid(string password);
        public abstract Boolean IsNameValid(string username);
        public abstract void AddNewUser(User u);
        public abstract string GetNickname(string id);
        public abstract User GetDetails(string id);
    }
}