
namespace DevinBank.App.UI
{
    public partial class ConsoleUI
    {
        public void RunApp()
        {
            UpdateTittle(false);
            Logo();
            Load();
            MainMenu();
            LogOff("Hasta la vista, Baby.\n");
        }
        private static void Load()
        {
            Console.Write("Carregando");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(".");
                Thread.Sleep(900);
            }

        }
        private static void LogOff(string text)
        {
            Console.Clear();
            for(int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(new Random().Next(1,5)*100);
            }
            Thread.Sleep(2000);
        }
        private static void Logo()
        {
            string logo = @"
 /$$$$$$$  /$$$$$$$$ /$$    /$$ /$$                 /$$$$$$$                      /$$      
| $$__  $$| $$_____/| $$   | $$|__/                | $$__  $$                    | $$      
| $$  \ $$| $$      | $$   | $$ /$$ /$$$$$$$       | $$  \ $$  /$$$$$$  /$$$$$$$ | $$   /$$
| $$  | $$| $$$$$   |  $$ / $$/| $$| $$__  $$      | $$$$$$$  |____  $$| $$__  $$| $$  /$$/
| $$  | $$| $$__/    \  $$ $$/ | $$| $$  \ $$      | $$__  $$  /$$$$$$$| $$  \ $$| $$$$$$/ 
| $$  | $$| $$        \  $$$/  | $$| $$  | $$      | $$  \ $$ /$$__  $$| $$  | $$| $$_  $$ 
| $$$$$$$/| $$$$$$$$   \  $/   | $$| $$  | $$      | $$$$$$$/|  $$$$$$$| $$  | $$| $$ \  $$
|_______/ |________/    \_/    |__/|__/  |__/      |_______/  \_______/|__/  |__/|__/  \__/";

            Console.WriteLine(logo + "\n");
        }
        private static void PressKey()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey(true);
        }
        private static void ErrorMsg(Exception ex)
        {
            Console.WriteLine($"Não foi possível processar a requisição. {ex.Message}");
        }
        private static void InvalidOption()
        {
            Console.Clear();
            Console.WriteLine("Opção inválida.");
            Thread.Sleep(1100);
        }
        private void Greetings()
        {
            Console.Clear();
            UpdateTittle(true);
            Console.WriteLine($"Que bom que você veio, {Conta!.Nome}!");
            Thread.Sleep(1700);
        }
        private void Farewell()
        {
            Console.Clear();
            UpdateTittle(false);
            Console.WriteLine($"Até logo, {Conta!.Nome}!");
            Thread.Sleep(1200);
        }
        private void UpdateTittle(bool isLoggedin)
        {
            if (isLoggedin)
            {
                Console.Title = "DEVin Bank" + $"       Cliente: {Conta!.Nome}        Conta: {Conta.NumConta}        {Banco.Data:d}".ToUpper();
            }
            else
            {
                Console.Title = $"DEVin Bank            {Banco.Data:d}";
            }
        }
    }
}
