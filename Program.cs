using System;

class Village
{
    public int Food = 100, Wood = 100, Gold = 50, Villagers = 5, Day = 1;

    public void ShowStatus()
    {
        Console.WriteLine($"\nDía {Day}");
        Console.WriteLine($"Aldeanos: {Villagers} | Comida: {Food} | Madera: {Wood} | Oro: {Gold}");
    }

    public void NextDay()
    {
        Day++;
        Food -= Villagers * 2;
        if (Food < 0)
        {
            int deaths = Math.Min(Villagers, (int)Math.Ceiling(Math.Abs(Food) / 2.0));
            Villagers -= deaths;
            Food = 0;
            Console.WriteLine($"¡{deaths} aldeano(s) murieron de hambre!");
        }
    }
}

class Program
 {
    static void Main()
    {

        Village v = new Village();
        bool playing = true;

        while (playing && v.Villagers > 0)
        {
            v.ShowStatus();
            Console.WriteLine("\nWhat you want to do?");
            Console.WriteLine("1. Colect food (+10)");
            Console.WriteLine("2. Chop firewood (+10)");
            Console.WriteLine("3. Mine gold (+10)");
            Console.WriteLine("4. Construct house (-30 madera)");
            Console.WriteLine("5. Hire villager (-20 oro)");
            Console.WriteLine("6. Move to next day");
            Console.WriteLine("0. Exit");
            Console.Write("> ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    v.Food += 10;
                    break;

                case "2":
                    v.Wood += 10;
                    break;

                case "3":

                    v.Gold += 10;
                    break;

                case "4":

                    if (v.Wood >= 30)

                    {

                        v.Wood -= 30; Console.WriteLine("House builded!");

                    }

                    else Console.WriteLine("No wood in storage");
                    break;

                case "5":

                    if (v.Gold >= 20)
                    {

                        v.Gold -= 20; v.Villagers++; Console.WriteLine("Hired villager");

                    }

                    else
                        Console.WriteLine("No gold in our pocket.");

                    break;

                case "6":

                    v.NextDay();
                    break;

                case "0":

                    playing = false;
                    break;

                default: Console.WriteLine("Invalid option."); break;
            }


            if (v.Villagers <= 0)
                Console.WriteLine("\nAll villager(s are starved death! You lose)");

        }
    }
}
