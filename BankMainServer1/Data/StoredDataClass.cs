namespace BankMainServer1.Data
{
    public class StoredDataClass
    {
        private List<string> province = new() { "Central", "Eastern", "North Central", "Northen", "North Western", "Sabaragamuwa", "Southern", "Uva", "Western" };
        private List<string[]> district = new();

        public StoredDataClass()
        {
            district.Add(new[] { "Kandy", "Matale", "Nuwara Eliya" });
            district.Add(new[] { "Ampara", "Batticaloa", "Trincomalee" });
            district.Add(new[] { "Anuradhapura", "Polonnaruwa" });
            district.Add(new[] { "Jaffna", "Kilinochchi", "Mannar", "Mullaitivu", "Vavuniya" });
            district.Add(new[] { "Kurunegala", "Puttalam" });
            district.Add(new[] { "Kegalle", "Ratnapura" });
            district.Add(new[] { "Galle", "Hambantota", "Matara" });
            district.Add(new[] { "Badulla", "Monaragala" });
            district.Add(new[] { "Colombo", "Gampaha", "Kalutara" });
        }

        public List<string> GetProvince()
        { return province; }

        public List<string[]> GetDistrict()
        { return district; }
    }
}
