namespace tech_shop.Models
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<Order> Orders { get; set; }
    }
}
