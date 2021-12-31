namespace CBProject.Models.HelperModels
{
    public class CreatePaymentAPI
    {
        public int ID { get; set; }
        public string UserEmail { get; set; }
        public decimal Price { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }
    }
}