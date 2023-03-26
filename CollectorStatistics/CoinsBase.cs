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

        public void AddPricing(string price)
        {
            if (float.TryParse(price, out float result))
            {
                this.AddPricing(result);
            }
            else
            {
                throw new Exception("Wprowadzona cena nie jest liczbą.\n");
            };
        }
        public void AddPricing(double price)
        {
            float priceDouble = (float)price;
            this.AddPricing(priceDouble);
        }
        public void AddPricing(long price)
        {
            float priceLong = (float)price;
            this.AddPricing(priceLong);
        }
        public void AddPricing(decimal price)
        {
            float priceDecimal = (float)price;
            this.AddPricing(priceDecimal);
        }
        public void AddPricing(int price)
        {
            float priceInt = price;
            this.AddPricing(priceInt);
        }

        public abstract Statistics GetStatistics();
    }
}
