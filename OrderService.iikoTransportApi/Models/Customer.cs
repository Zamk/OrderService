namespace OrderService.iikoTransportApi.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Comment { get; set; }
        public string Birthdate { get; set; }
        public string Email { get; set; }

        //todo: ENUM Gender
        public string Gender { get; set; }

    }
}
