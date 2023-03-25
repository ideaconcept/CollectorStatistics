namespace CollectorStatistics.Tests
{
    public class CoinsInMemoryTests
    {

        [Test]
        public void MaxOfPrice()
        {
            var coins = new CoinsInMemory("K(10)130", "Przewodnictwo Polski w Radzie UE", 10, "Z這tych", 2011, 32, 14, "Ag 925");
            coins.AddPricing(8.77);
            coins.AddPricing(7);
            coins.AddPricing(9.99);

            var statistics = coins.GetStatistics();
            var result = statistics.Max;
            Assert.That(result, Is.EqualTo(9.99f));
        }

        [Test]
        public void MinOfPrice()
        {
            var coins = new CoinsInMemory("K(10)130", "Przewodnictwo Polski w Radzie UE", 10, "Z這tych", 2011, 32, 14, "Ag 925");
            coins.AddPricing(8);
            coins.AddPricing(20);
            coins.AddPricing(82);

            var statistics = coins.GetStatistics();
            var result = statistics.Min;
            Assert.That(result, Is.EqualTo(8));
        }
        [Test]
        public void AverageOfPrices()
        {
            var coins = new CoinsInMemory("K(10)130", "Przewodnictwo Polski w Radzie UE", 10, "Z這tych", 2011, 32, 14, "Ag 925");
            coins.AddPricing(2);
            coins.AddPricing(2);
            coins.AddPricing(6);

            var statistics = coins.GetStatistics();
            var result = Math.Round(statistics.Average, 2);
            Assert.That(result, Is.EqualTo(Math.Round(3.33, 2)));
        }

        [Test]
        public void AddPriceString()
        {
            var coins = new CoinsInMemory("K(10)130", "Przewodnictwo Polski w Radzie UE", 10, "Z這tych", 2011, 32, 14, "Ag 925");
            coins.AddPricing("100");
            coins.AddPricing("20");

            var statistics = coins.GetStatistics();
            var result = Math.Round(statistics.Average, 2);
            Assert.That(result, Is.EqualTo(Math.Round(60.00, 2)));
        }

        [Test]
        public void AddNewCoin()
        {
            var coins = new CoinsInMemory("K(10)130", "Przewodnictwo Polski w Radzie UE", 10, "Z這tych", 2011, 32, 14, "Ag 925");

            var result = coins.ID + coins.Name + coins.Denomination + coins.Currency + coins.YearOfRelease + coins.Diameter + coins.Weight + coins.Material;
            Assert.That(result, Is.EqualTo("K(10)130Przewodnictwo Polski w Radzie UE10Z這tych20113214Ag 925"));
        }
    }
}