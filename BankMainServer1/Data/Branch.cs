namespace BankMainServer1.Data
{
    public class Branch
    {
        public int id { get; set; }
		public string? name { get; set; }
        public string? saddress { get; set; }
        public string? city { get; set; }
        public string? distric { get; set; }
        public string? province { get; set; }
        public string? zip { get; set; }
        public string? phone1 { get; set; }
        public string? phone2 { get; set; }
        public string? email { get; set; }
        public int managerid { get; set; }
    }
}
