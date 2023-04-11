
using Account.DTOs;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Account.Repositories
{
    public class UserRepositoryMongoDB : UserRepository
    {


    private readonly IMongoCollection<UserDTO> usersCollection;

    public UserRepositoryMongoDB() {
        MongoClient client = new MongoClient("mongodb://mongodb:27017");
        IMongoDatabase database = client.GetDatabase("Account");
        usersCollection = database.GetCollection<UserDTO>("Users");
        Console.WriteLine(">>>>>>>>>>>>>>>>>>\n\n\n\n>>>>>>>>>>>>>>>>>>>>>> " + usersCollection is null);
    }
        public async Task<UserDTO> Create(UserDTO user)
        {
            await this.usersCollection.InsertOneAsync(user);
            return user;
        }

        public async Task<UserDTO> Update(string guid, UserDTO user)
        {
            UserDTO oldUser = await this.Get(guid);
            if (oldUser is null) throw new Exception("a user not exist");

            oldUser.FirstName = user.FirstName;
            oldUser.LastName = user.LastName;
            oldUser.Status = user.Status;
            await this.usersCollection.ReplaceOneAsync(b=> b.Guid == oldUser.Guid, oldUser);
            return oldUser;
        }

        public async Task<UserDTO> Get(string guid)
        {
            var users = await this.usersCollection.Find(_ => true).ToListAsync();
            return users.Where(u => u.Guid == guid).SingleOrDefault();
            // FilterDefinition<UserDTO> filter = Builders<UserDTO>.Filter.Eq("Id", guid);
            // var user = await this.usersCollection.FindAsync(filter);
            // return user.First();
        }

        public async Task<List<UserDTO>> GetAll()
        {
            return await this.usersCollection.Find(_ => true).ToListAsync();
        }

        private async Task Delete(UserDTO userDTO)
        {
            FilterDefinition<UserDTO> filter = Builders<UserDTO>.Filter.Eq("Id", userDTO.Guid);
            await this.usersCollection.DeleteOneAsync(filter);
        }
    }
}
