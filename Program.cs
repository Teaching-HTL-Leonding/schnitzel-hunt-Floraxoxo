Console.Clear();
Console.OutputEncoding = System.Text.Encoding.Default;

var menu_card = Directory.GetFiles(@"C:\Users\Flora\Documents\htl leonding\Programmieren\Projekt_058_SchnitzelHunt\MenuCards");
int i = 0;
int min = int.MaxValue, max = int.MinValue;
string minimum = "", maximum = "";
string restaurant = "";

foreach (var menu in menu_card)
{
    bool alreadyFoundRestaurant = false;
    var lines = File.ReadAllLines(menu);
    foreach (var line in lines)
    {
        if (line.Contains(':'))
        {
            if (line.Contains("Schnitzel"))
            {
                if (!alreadyFoundRestaurant)
                {
                    alreadyFoundRestaurant = true;
                    restaurant = Path.GetFileNameWithoutExtension(menu);
                    Console.WriteLine(restaurant);
                }

                string splitLines = line.Split(':')[0];
                var price = line.Split(':')[1];
                price = price.Replace("€", "");
                int priceNumber = int.Parse(price);
                Console.WriteLine(" -" + splitLines);
                i++;
                if (line.Contains("Seitan Schnitzel"))
                {
                    min = int.Min(priceNumber, min); if (min == priceNumber) { minimum = restaurant; }
                    max = int.Max(priceNumber, max); if (max == priceNumber) { maximum = restaurant; }
                }
            }
        }
    }
}
Console.WriteLine($"You can find the cheapest Seitan Schnitzel at {minimum} which only costs {min}€");
Console.WriteLine($"You can find the most expensive Seitan Schnitzel at {maximum} which costs {max}€");
