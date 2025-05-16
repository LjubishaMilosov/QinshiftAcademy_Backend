

using Class_08_Events.Enums;

namespace Class_08_Events.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public ProductType FavoriteProductType { get; set; }

        public User (int id, string name, string email, int age, ProductType favoriteProductType)
        {
            Id = id;
            Name = name;
            Email = email;
            Age = age;
            FavoriteProductType = favoriteProductType;
        }

        public void ReadPromotion(ProductType productType)
        {
            Console.WriteLine($"Mr/Mrs: {Name}, the products of type {productType} are on promotion");
            if(productType == FavoriteProductType)
            {
                Console.WriteLine($"Mr/Mrs: {Name}, the products of type {productType} are on promotion and you are interested in them");
            }
            else
            {
                Console.WriteLine($"Mr/Mrs: {Name}, the products of type {productType} are on promotion but you are not interested in them");
            }
        }

    }
}
