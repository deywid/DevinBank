
using DevinBank.Library.Enums;

namespace DevinBank.Library.Modelos
{
    public class Agencia
    {
        public AgenciaEnum IdAgencia { get; }
        public string Nome { get; }
        public Agencia(AgenciaEnum agencia)
        {
            IdAgencia = agencia;
            Nome = PegaNome(agencia);
        }

        public static string PegaNome(AgenciaEnum agencia)
        {
            if (agencia == AgenciaEnum.Fpolis)
            {
                return "001 - Florianópolis";
            }
            else if (agencia == AgenciaEnum.SaoJose)
            {
                return "002 - São José";
            }
            else
            {
                return "003 - Biguaçu";
            }
        }

    }
}
