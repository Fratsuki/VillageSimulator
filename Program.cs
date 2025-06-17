using System;

class Village {
    public int Food = 100, Wood = 100, Gold = 50, Villagers = 5, Day = 1;

    public void ShowStatus() {
        Console.WriteLine($"\nDía {Day}");
        Console.WriteLine($"Aldeanos: {Villagers} | Comida: {Food} | Madera: {Wood} | Oro: {Gold}");
    }

    public void NextDay() {
        Day++;
        Food -= Villagers * 2;
        if (Food < 0) {
            int deaths = Math.Min(Villagers, (int)Math.Ceiling(Math.Abs(Food) / 2.0));
            Villagers -= deaths;
            Food = 0;
            Console.WriteLine($"¡{deaths} aldeano(s) murieron de hambre!");
        }
    }
}

class Program {
    static void Main() {
        Village v = new Village();
        bool playing = true;

        while (playing && v.Villagers > 0) {
            v.ShowStatus();
            Console.WriteLine("\n¿Qué deseas hacer?");
            Console.WriteLine("1. Recolectar comida (+10)");
            Console.WriteLine("2. Taladrar madera (+10)");
            Console.WriteLine("3. Minar oro (+10)");
            Console.WriteLine("4. Construir casa (-30 madera)");
            Console.WriteLine("5. Contratar aldeano (-20 oro)");
            Console.WriteLine("6. Pasar al siguiente día");
            Console.WriteLine("0. Salir");
            Console.Write("> ");

            string input = Console.ReadLine();

            switch (input) {
                case "1": v.Food += 10; break;
                case "2": v.Wood += 10; break;
                case "3": v.Gold += 10; break;
                case "4":
                    if (v.Wood >= 30) { v.Wood -= 30; Console.WriteLine("Casa construida."); }
                    else Console.WriteLine("No hay suficiente madera.");
                    break;
                case "5":
                    if (v.Gold >= 20) { v.Gold -= 20; v.Villagers++; Console.WriteLine("Aldeano contratado."); }
                    else Console.WriteLine("No hay suficiente oro.");
                    break;
                case "6": v.NextDay(); break;
                case "0": playing = false; break;
                default: Console.WriteLine("Opción inválida."); break;
            }

            if (v.Villagers <= 0)
                Console.WriteLine("\n¡Todos los aldeanos han muerto! Fin del juego.");
        }
    }
}
