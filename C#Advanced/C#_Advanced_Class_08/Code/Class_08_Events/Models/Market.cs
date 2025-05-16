
using Class_08_Events.Enums;

namespace Class_08_Events.Models
{
    public class Market
    {

        public delegate void PromotionHandler(ProductType productType);

        public event PromotionHandler OnPromotionSent;

        public int Id { get; set; }
        public string Name { get; set; }
        public ProductType ProductTypeOnPromotion { get; set; }
        public List<string> SubscriberEmails { get; set; } = new List<string>();
        public List<string> Complaints { get; set; } = new List<string>();

        public void SubscribeForPromotion(PromotionHandler promotionHandler, string email)
        {
            OnPromotionSent += promotionHandler;
            SubscriberEmails.Add(email);
        }

        public void SendPromotion()
        {
            Console.WriteLine("======================================================");
            Console.WriteLine($"{Name} is sending promotions for {ProductTypeOnPromotion}");
            Console.WriteLine("........Sending............");
            OnPromotionSent?.Invoke(ProductTypeOnPromotion);
        }

    }
}
