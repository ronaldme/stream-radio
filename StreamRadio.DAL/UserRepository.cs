using StreamRadio.DAL.Infrastructure;

namespace StreamRadio.DAL
{
    public class UserRepository : RepositoryBase<User>
    {
        public User GetUser(long chatId)
        {
            using var db = Create();
            return Collection(db).FindOne(c => c.ChatId == chatId);
        }

        public void CreateUser(string name, long chatId)
        {
            using var db = Create();
            Collection(db).Insert(new User
            {
                Name = name,
                ChatId = chatId,
            });
        }
    }
}