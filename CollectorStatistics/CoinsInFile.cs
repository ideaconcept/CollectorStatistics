using System.Diagnostics;

namespace CollectorStatistics
{
    public class CoinsInFile : CoinsBase
    {
        public override event PricingAddedDelegate PricingAdded;

        private const string fileName = "pricing.txt";

        public CoinsInFile(string id,
                           string name,
                           int denomination,
                           string currency,
                           int yearofrelease,
                           int diameter,
                           int weight,
                           string material)
            : base(id, name, denomination, currency, yearofrelease, diameter, weight, material)
        {
        }

        public override void AddPricing(float price)
        {
            if (price > 0)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(price);

                    if (PricingAdded != null)
                    {
                        PricingAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new Exception("Wprowadzona cena nie może mieć wartośści równej lub mniejszej od zera (0).\n");
            }
        }

        public override void AddPricing(string price)
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

        public override void AddPricing(double price)
        {
            float priceDouble = (float)price;
            this.AddPricing(priceDouble);
        }

        public override void AddPricing(long price)
        {
            float priceLong = (float)price;
            this.AddPricing(priceLong);
        }

        public override void AddPricing(decimal price)
        {
            float priceDecimal = (float)price;
            this.AddPricing(priceDecimal);
        }

        public override void AddPricing(int price)
        {
            float priceInt = price;
            this.AddPricing(priceInt);
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        var price = float.Parse(line);
                        statistics.AddPricing(price);
                        line = reader.ReadLine();
                    }
                }
            }
            return statistics;
        }
    }
}
