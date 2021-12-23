namespace CBProject.Models.EntityModels
{

    public enum Methods
    {
        BankTransfer,
        Paypal,
        DebitCard,
        CreaditCard
    }

    public class Auth
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class TransactionDetails
    {
        public string OrderId { get; set; }
        public string GrossAmount { get; set; }
    }

    public class MyPayment
    {
        public Auth Auth { get; set; }
        public TransactionDetails TransactionDetails { get; set; }
        public ApplicationUser User { get; set; }
        public Methods Method { get; set; }
        public bool Secure { get; set; }
    }
}