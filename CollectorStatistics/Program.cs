using System.Drawing;

namespace CollectorStatistics
{
    internal class Program
    {
        static void PricingAdded(object sender, EventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nDodano nową cenę sprzedaży monety.\n");
            Console.ResetColor();
        }

        private static void Main()
        {
            ShowMenu();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nWybierz 1, 2 lub X aby zakończyć pracę programu. Twój wybór: ");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                string choice = Console.ReadLine();
                Console.ResetColor();

                if (choice == "1")
                {
                    var coins = new CoinsInMemory("K(10)130", "Przewodnictwo Polski w Radzie UE", 10, "Złotych", 2011, 32, 14, "Ag 925");
                    coins.PricingAdded += PricingAdded; ShowMenu();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nWprowadź znane ceny transkacji kupna-sprzedaży dla monety:\n");
                    ShowCoinDetails(coins.ID, coins.Name, coins.Denomination, coins.Currency, coins.YearOfRelease, coins.Diameter, coins.Weight, coins.Material);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Program automatycznie wyliczy dane statystyczne.\n");

                    while (true)
                    {
                        Console.WriteLine("Wprowadź cenę monety lub q aby zakończyć wprowadzanie danych i wyliczyć wynik: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        var price = GetDataFromUser("Cena: ");
                        Console.ResetColor();
                        price = price.Replace(".", ",");

                        if (price == "q")
                        {
                            break;
                        }

                        try
                        {
                            coins.AddPricing(price);
                        }
                        catch (Exception e)
                        {
                            ShowBug(e.Message);
                        }
                    }
                    var statistics = coins.GetStatistics();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("\nDane dotyczące monety:");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"\t\t\t\t{coins.ID} {coins.Name} {coins.Denomination} {coins.Currency}\n");
                    ShowStatistics(statistics);
                }
                else if (choice == "2")
                {
                    try
                    {
                        var coins = new CoinsInFile("K(10)130", "Przewodnictwo Polski w Radzie UE", 10, "Złotych", 2011, 32, 14, "Ag 925");
                        coins.PricingAdded += PricingAdded; ShowMenu();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nWprowadź znane ceny transkacji kupna sprzedaży dla monety:\n");
                        ShowCoinDetails(coins.ID, coins.Name, coins.Denomination, coins.Currency, coins.YearOfRelease, coins.Diameter, coins.Weight, coins.Material);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Program automatycznie wyliczy dane statystyczne.\n");

                        while (true)
                        {
                            Console.WriteLine("Wprowadź cenę monety lub q aby zakończyć wprowadzanie danych i wyliczyć wynik: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            var price = GetDataFromUser("Cena: ");
                            Console.ResetColor();
                            price = price.Replace(".", ",");

                            if (price == "q")
                            {
                                break;
                            }

                            try
                            {
                                coins.AddPricing(price);
                            }
                            catch (Exception e)
                            {
                                ShowBug(e.Message);
                            }
                        }
                        var statistics = coins.GetStatistics();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("\nDane dotyczące monety:");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write($"\t\t\t\t{coins.ID} {coins.Name} {coins.Denomination} {coins.Currency}\n");
                        ShowStatistics(statistics);
                    }
                    catch (Exception e)
                    {
                        ShowBug(e.Message);
                    }
                }
                else if (choice == "X" || choice == "x")
                {
                    Environment.Exit(0);
                }
                else
                {
                    ShowBug("Wprowadzono złą wartość.\n");
                }
            }
        }

        private static void ShowStatistics(Statistics statistics)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Średnia cena z wprowadzonych transakcji: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"\t{String.Format("{0:C2}", statistics.Average)}\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Minimalna cena sprzedaży: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"\t\t\t{String.Format("{0:C2}", statistics.Min)}\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Maksymalna cena sprzedazy: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"\t\t\t{String.Format("{0:C2}", statistics.Max)}\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Liczba transkcji kupna-sprzedaży nominału: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"\t{statistics.Count}\n");
            Console.ResetColor();
        }

        private static void ShowBug(string bug)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nWystąpił błąd: {bug}");
            Console.ResetColor();
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("             Witamy w programie Kolekcjoner Statystyki:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("====================================================================");
            Console.ResetColor();
            Console.WriteLine("   1. Dodawanie cen kupna-sprzedaży monet (In memory)");
            Console.WriteLine("   2. Dodawanie cen kupna-sprzedaży monet (In File)");
            Console.WriteLine("   X. Zakończ pracę programu");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("====================================================================");
            Console.ResetColor();
        }

        private static string? GetDataFromUser(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Gray;
            string userInput = Console.ReadLine();
            return userInput;
        }

        private static void ShowCoinDetails(string id, string name, int denomination, string currency, int yearOfRelease, int diameter, int weight, string material)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Identyfikator:");
            Console.ResetColor();
            Console.WriteLine($"\t\t{id}");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Nazwa:");
            Console.ResetColor();
            Console.WriteLine($"\t\t\t{name}");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Nominał:");
            Console.ResetColor();
            Console.WriteLine($"\t\t{denomination}");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Waluta:");
            Console.ResetColor();
            Console.WriteLine($"\t\t\t{currency}");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Rok wydania:");
            Console.ResetColor();
            Console.WriteLine($"\t\t{yearOfRelease}");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Średnica:");
            Console.ResetColor();
            Console.WriteLine("\t\t{0,-8:N2}", diameter);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Waga (g):");
            Console.ResetColor();
            Console.WriteLine("\t\t{0,-8:N2}", weight);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Materiał:");
            Console.ResetColor();
            Console.WriteLine($"\t\t{material}\n");
            Console.ResetColor();
        }
    }
}


