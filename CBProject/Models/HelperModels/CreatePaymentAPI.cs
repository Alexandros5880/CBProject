namespace CBProject.Models.HelperModels
{
    public class CreatePaymentAPI
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public decimal Price { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }
    }
}