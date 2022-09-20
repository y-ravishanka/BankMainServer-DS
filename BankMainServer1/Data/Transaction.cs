namespace BankMainServer1.Data
{
    public class Transaction
    {
        public string? Id { get; set; }
        public string? date { get; set; }
        public string? type { get; set; }
        public int account { get; set; }
        public float amount { get; set; }
        public string? depositor { get; set; }
    }
}
