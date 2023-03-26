namespace CollectorStatistics
{
    public class CoinsInMemory : CoinsBase
    {
        public override event PricingAddedDelegate PricingAdded;

        private List<float> pricing = new ();

        public CoinsInMemory(string id,
                             string name,
                             int denomination,
                             string currency,
                             int yearofrelease,
                             int diameter,
                             int weight,
                             string material)
            : base (id, name, denomination, currency, yearofrelease, diameter, weight, material)
        { 
        }

        public override void AddPricing(float price)
        {
            if (price > 0)
            {
                this.pricing.Add(price);

                if (PricingAdded != null)
                {
                    PricingAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Wprowadzona cena nie może mieć wartośści równej lub mniejszej od zera (0).\n");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var price in this.pricing)
            {
                statistics.AddPricing(price);
            }

            return statistics;
        }
    }
}
