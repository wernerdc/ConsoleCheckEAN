namespace ConsoleCheckEAN {
    internal class Program {
        static void Main(string[] args) {

            bool appRunning = true;
            while (appRunning) {

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.WriteLine("ConsoleCheckEAN \n");

                long ean;
                try {
                    Console.Write("Bitte geben Sie eine EAN ein: ");
                    ean = Convert.ToInt64(Console.ReadLine());
                } catch {

                    throw;
                }

                Console.Write("\n\nProgramm beenden (e)? ");
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
    }
}
