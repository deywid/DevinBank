
namespace DevinBank.Library.Utils
{
    public class Validacoes
    {
        public static string ValidaString(string texto)
        {
            string input;
            bool notOk;
            do
            {
                Console.WriteLine(texto);
                input = Console.ReadLine();
                notOk = String.IsNullOrWhiteSpace(input);

                if (notOk)
                    Console.WriteLine("O valor digitado é inválido. \n");

                Console.Clear();
            } while (notOk);

            return input;
        }

        public static string PegaCPF(string texto)
        {
            string input;
            bool ok;
            do
            {
                Console.WriteLine(texto);
                input = Console.ReadLine();
                ok = ValidaCPF.IsCpf(input);

                if (!ok)
                    Console.WriteLine("O valor digitado é inválido. \n");

                Console.Clear();
            } while (!ok);

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

                if (!ok)
                    Console.WriteLine("O valor digitado é inválido. \n");

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

                if (!ok)
                    Console.WriteLine("O valor digitado é inválido. \n");

                Console.Clear();
            } while (!ok);

            return input;
        }
    }
}
