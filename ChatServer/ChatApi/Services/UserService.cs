
using ChatApi.Models;
using ChatApi.Services;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace ChatServer.Services
{
    public class UserService : AbstractUserService
    {
        private static List<User> _context = _users;
        public override List<User> GetAll()
        {
            return _context;
        }

        public override User Get(string id)
        {
            if (_context is null)
            {
                return null;
            }
            User r =  _context.Find(x => x.Username.Equals(id));
            return r;
        }
        public override User GetDetails(string id)
        {

            foreach (var u in _users)
            {
                if (u.Username.Equals(id))
                {
                    return u;
                }
            }

            return null;
        }
        public override string GetNickname(string id)
        {
            if (_context is null)
            {
                return null;
            }
            User r =  _context.Find(x => x.Username.Equals(id));
            return r.Name;
        }

        public override void Edit(User curr, User update)
        {
            if (curr is null || update is null)
            {
                return;
            }

            curr.Friends = update.Friends;
            curr.Name = update.Name;
            curr.Username = update.Username;
            curr.Password = update.Username;
        }

        public override void Delete(string id)
        {
            User u = _context.Find(x => x.Username.Equals(id));
            if (u is null)
            {
                return;
            }
            _context.Remove(u);
        }

        public override int Count()
        {
            return _context.Count;
        }

        public override void Add(User user)
        {
            if (user is null) {return;}
            User u = _context.Find(x => x.Username.Equals(user.Username));
            if (u is null)
            {
                _context.Add(user);
            }
        }



        public override void Friend(User u1, User u2)
        {
            if (u1 is null || u2 is null)
            {
                return;
            }
            if(Get(u2.Username) is null || Get(u1.Username) is null)
            {
                return;
            }
            u1.AddFriend(u2);
            u2.AddFriend(u1);
        }

        public override void Unfriend(User u1, User u2)
        {
            u1.Unfriend(u2);
            u2.Unfriend(u1);
        }

        public override void Edit(string id, string name, string server)
        {
            User u = _context.Find(x => x.Username.Equals(id));
            if (u is null)
            {
                return;
            }

            u.Name = name;
            u.Server = server;
        }

        public override List<UserApiResponse> Get(User u)
        { 
            List<UserApiResponse> res = new List<UserApiResponse>();
            foreach (var friend in u.Friends)
            {
                Message m = GetLastMessage(u.Username, friend.Username);
                UserApiResponse uar;
                if (m is null)
                {
                    uar = new UserApiResponse(friend.Username, friend.Name, friend.Server, "", DateTime.Now);
                }
                else
                {
                    uar = new UserApiResponse(friend.Username, friend.Name, friend.Server, m.Text, m.When);
                }
                res.Add(uar);
            }

            return res;
        }

        private Message GetLastMessage(string un1, string un2)
        {
            string key = un1 + "|" + un2;
            if (_chats.ContainsKey(key))
            {
                return _chats[key].getLastMessage();
            } 
            key = un2 + "|" + un1;
            if (_chats.ContainsKey(key))
            {
                return _chats[key].getLastMessage();
            }

            return null;
        }

        public override Boolean IsNameValid(string username)
        {
            if (username is null || username.Equals("ADMIN") || username.Contains("|"))
            {
                return false;
            }

            foreach (var user in _context)
            {
                if (user.Username.Equals(username))
                {
                    return false;
                }
            }

            return true;
        }
        
        public override Boolean IsPasswordValid(string password)
        {
            return !(password is null || password.Length < 4);
        }

        public override void AddNewUser(User u)
        {
            _context.Add(u);
        }
    }
}