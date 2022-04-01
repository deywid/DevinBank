
namespace DevinBank.Library.Utils
{
    public class Validacoes
    {
        public static string ValidaString(string texto)
        {
            string input;
            do
            {
                Console.WriteLine(texto);
                input = Console.ReadLine()!;

                if (String.IsNullOrWhiteSpace(input))
                    Console.WriteLine("O valor digitado é inválido. \n");

                Console.Clear();
            } while (String.IsNullOrWhiteSpace(input));

            return input;
        }
        public static string PegaCPF(string texto)
        {
            string input;
            do
            {
                input = ValidaString(texto);

                if (!ValidaCPF.IsCpf(input))
                    Console.WriteLine("CPF inválido. \n");

                Console.Clear();
            } while (!ValidaCPF.IsCpf(input));

            return input;
        }
        public static decimal ValidaDecimal(string texto)
        {
            decimal input;
            bool ok;
            do
            {
                Console.WriteLine(texto);
                ok = decimal.TryParse(Console.ReadLine(), out input);

                if (!ok || input <= 0)
                {
                    Console.WriteLine("O valor digitado é inválido. \n");
                    ok = false;
                }
                Console.Clear();
            } while (!ok);

            return input;
        }
        public static int ValidaInt(string texto)
        {
            int input;
            bool ok;
            do
            {
                Console.WriteLine(texto);
                ok = int.TryParse(Console.ReadLine(), out input);

                if (!ok || input <= 0)
                {
                    Console.WriteLine("O valor digitado é inválido. \n");
                    ok = false;
                }
                Console.Clear();
            } while (!ok);

            return input;
        }
    }

}
