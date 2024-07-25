namespace ConsoleCheckEAN {
    internal class Program {
        static void Main(string[] args) {

            bool appRunning = true;
            while (appRunning) {

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.WriteLine("ConsoleCheckEAN \n");

                long ean = 0;
                bool validInput = false;
                while (!validInput) {
                    try {
                        Console.Write("Bitte geben Sie eine EAN ein: ");
                        //ean = Convert.ToInt64(Console.ReadLine());
                        ean = long.Parse(Console.ReadLine());

                        if (ean <= 0 || ean.ToString().Length > 13) {
                            ShowInputErrorMessage();
                        } else {
                            validInput = true;
                        }
                    } catch {
                        ShowInputErrorMessage();
                    }
                }
                
                string eanString13 = string.Format("{0:D13}", ean);
                int sum = 0;
                for (int i = 0; i < eanString13.Length; i++) {
                    if (i % 2 == 0) {
                        sum += int.Parse(eanString13[i].ToString());
                    } else {
                        sum += int.Parse(eanString13[i].ToString()) * 3;
                    }
                }

                string isValid = (sum % 10 == 0) ? "gültig" : "ungültig";
                Console.WriteLine("Summe: {0}\n", sum);
                Console.WriteLine("Die EAN {0:0 000 000 000 000} ist {1}!\n", ean, isValid);


                Console.Write("\nProgramm beenden (e)? ");
                try {
                    string? exitApp = Console.ReadLine();
                    if (exitApp.ToUpper() == "E") {
                        appRunning = false;
                    }
                } catch {
                    // no error message, just keep going and repeat the app
                }
            }

        }

        private static void ShowInputErrorMessage() {

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nUngültige Eingabe: Nur positive Ganzzahlen sind erlaubt\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
