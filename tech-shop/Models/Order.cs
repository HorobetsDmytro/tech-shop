namespace tech_shop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
