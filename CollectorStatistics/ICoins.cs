using static CollectorStatistics.CoinsBase;

namespace CollectorStatistics
{
    public interface ICoins
    {
        public string ID { get; }
        public string Name { get; }
        public int Denomination { get; }
        public string Currency { get; }
        public int YearOfRelease { get; }
        public int Diameter { get; }
        public int Weight { get; }
        public string Material { get; }

        void AddPricing(float price);
        void AddPricing(string price);
        void AddPricing(double price);
        void AddPricing(long price);
        void AddPricing(decimal price);
        void AddPricing(int price);



        event PricingAddedDelegate PricingAdded;

        Statistics GetStatistics();
    }
}