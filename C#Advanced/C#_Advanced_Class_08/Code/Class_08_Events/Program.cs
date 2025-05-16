using Class_08_Events.Models;
using Class_08_Events.Enums;

Market market = new Market
{
    Id = 1,
    Name = "Supermarket",
    ProductTypeOnPromotion = ProductType.Electronics
};

User user1 = new User(1, "Bob Bobsky", "bob@mail.com", 34, ProductType.Electronics);
User user2 = new User(1, "John Doe", "bob@mail.com", 34, ProductType.Electronics);
User user3 = new User(1, "Jane Doe", "bob@mail.com", 34, ProductType.Electronics);

market.SubscribeForPromotion(user1.ReadPromotion, user1.Email);
market.SubscribeForPromotion(user2.ReadPromotion, user2.Email);
market.SubscribeForPromotion(user3.ReadPromotion, user3.Email);

market.SendPromotion();