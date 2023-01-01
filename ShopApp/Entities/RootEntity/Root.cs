using ShopApp.Entities.UserEntity;

namespace ShopApp.Entities.RootEntity
{
    public class Root
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<User> Users { get; set; } = new List<User>();
    }
}
