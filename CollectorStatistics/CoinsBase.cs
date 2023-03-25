namespace CollectorStatistics
{
    public abstract class CoinsBase : ICoins
    {
        public delegate void PricingAddedDelegate(object sender, EventArgs args);
        public abstract event PricingAddedDelegate PricingAdded;

        public CoinsBase(string id, string name, int denomination, string currency, int yearofrelease, int diameter, int weight, string material)
        {
            this.ID = id;
            this.Name = name;
            this.Denomination = denomination;
            this.Currency = currency;
            this.YearOfRelease = yearofrelease;
            this.Diameter = diameter;
            this.Weight = weight;
            this.Material = material;
        }

        public string ID { get; }
        public string Name { get; }
        public int Denomination { get; }
        public string Currency { get; }
        public int YearOfRelease { get; }
        public int Diameter { get; }
        public int Weight { get; }
        public string Material { get; }

        public abstract void AddPricing(float price);
        public abstract void AddPricing(string price);
        public abstract void AddPricing(double price);
        public abstract void AddPricing(long price);
        public abstract void AddPricing(decimal price);
        public abstract void AddPricing(int price);

        public abstract Statistics GetStatistics();
    }
}
