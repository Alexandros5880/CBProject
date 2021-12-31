namespace CBProject.Models.HelperModels
{
    public class OrderApiModel
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public int SubscriptionId { get; set; }
        public bool IsClose { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsCanceledByError { get; set; }
        public decimal Price { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }
    }
}