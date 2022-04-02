
using DevinBank.Library.Enums;
using DevinBank.Library.Modelos;

namespace DevinBank.App.UI
{
    public partial class ConsoleUI
    {
        private void MainMenu()
        {
            bool sair = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Selecione a opção desejada: \n");
                Console.WriteLine("[1] Acessar conta ");
                Console.WriteLine("[2] Criar nova conta ");
                Console.WriteLine("[3] Acessar área restrita ");
                Console.WriteLine("[4] Encerrar aplicação ");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        FluxoAcessarConta();
                        break;
                    case "2":
                        MenuCriarConta();
                        break;
                    case "3":
                        MenuAreaRestrita();
                        break;
                    case "4":
                        sair = true;
                        break;
                    default:
                        InvalidOption();
                        break;
                }
            } while (!sair);
        }
        private void MenuCriarConta()
        {
            bool sair = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Qual o tipo de conta deseja criar? \n");
                Console.WriteLine("[1] Criar conta corrente");
                Console.WriteLine("[2] Criar conta poupança");
                Console.WriteLine("[3] Criar conta de investidor");
                Console.WriteLine("[4] Voltar ");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        FluxoCriarConta("corrente");
                        break;

                    case "2":
                        FluxoCriarConta("poupança");
                        break;
                    case "3":
                        FluxoCriarConta("investidor");
                        break;
                    case "4":
                        sair = true;
                        break;
                    default:
                        InvalidOption();
                        break;
                }
            } while (!sair);
        }
        private void MenuAreaRestrita()
        {
            bool sair = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Selecione a opção desejada: \n");
                Console.WriteLine("[1] Listar todas as contas ");
                Console.WriteLine("[2] Listar contas com saldo negativo ");
                Console.WriteLine("[3] Valor total de investimentos ");
                Console.WriteLine("[4] Extrato de transações de cliente ");
                Console.WriteLine("[5] Mudar data do sistema ");
                Console.WriteLine("[6] Voltar ");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        FluxoListarContas();
                        break;
                    case "2":
                        FluxoListarContasSaldoNegativo();
                        break;
                    case "3":
                        FluxoTotalEmInvestimentos();
                        break;
                    case "4":
                        FluxoExtratoTransacoesCliente();
                        break;
                    case "5":
                        FluxoMudarData();
                        break;
                    case "6":
                        sair = true;
                        break;
                    default:
                        InvalidOption();
                        break;
                }
            } while (!sair);
        }
        private void MenuConta()
        {
            bool sair = false;
            do
            {
                Console.Clear();
                Console.WriteLine("O que deseja fazer? \n");
                Console.WriteLine("[1] Depósito");
                Console.WriteLine("[2] Saque");
                Console.WriteLine("[3] Transferência");
                Console.WriteLine("[4] Extrato");
                Console.WriteLine("[5] Editar cadastro");
                Console.WriteLine("[6] Mais opções...");
                Console.WriteLine("[7] Sair");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        FluxoDeposito();
                        break;
                    case "2":
                        FluxoSaque();
                        break;
                    case "3":
                        FluxoTransferencia();
                        break;
                    case "4":
                        FluxoExtrato();
                        break;
                    case "5":
                        MenuAlterarCadastro();
                        break;
                    case "6":
                        FluxoMaisOpcoes();
                        break;
                    case "7":
                        Farewell();
                        sair = true;
                        break;
                    default:
                        InvalidOption();
                        break;
                }
            } while (!sair);
        }
        private void MenuAlterarCadastro()
        {
            bool sair = false;
            do
            {
                Console.Clear();
                Console.WriteLine("O que deseja editar no seu cadastro? \n");
                Console.WriteLine("[1] Meu nome");
                Console.WriteLine("[2] Minha renda mensal");
                Console.WriteLine("[3] Minha agência");
                Console.WriteLine("[4] Voltar");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        FluxoEditarCadastro("nome");
                        break;
                    case "2":
                        FluxoEditarCadastro("renda");
                        break;
                    case "3":
                        FluxoEditarCadastro("agencia");
                        break;
                    case "4":
                        sair = true;
                        break;
                    default:
                        InvalidOption();
                        break;
                }
            } while (!sair);
        }
        private void MenuContaPoupanca()
        {
            bool sair = false;
            do
            {
                Console.Clear();
                Console.WriteLine("O que deseja fazer? \n");
                Console.WriteLine("[1] Simular rendimentos");
                Console.WriteLine("[2] Extrato de transações");
                Console.WriteLine("[3] Historico de transferências");
                Console.WriteLine("[4] Voltar");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        FluxoSimularRendimentoPoupanca();
                        break;
                    case "2":
                        FluxoExtratoTransacoes();
                        break;
                    case "3":
                        FluxoHistoricoTransferencias();
                        break;
                    case "4":
                        sair = true;
                        break;
                    default:
                        InvalidOption();
                        break;
                }
            } while (!sair);
        }
        private void MenuContaCorrente()
        {
            bool sair = false;
            do
            {
                Console.Clear();
                Console.WriteLine("O que deseja fazer? \n");
                Console.WriteLine("[1] Extrato de transações");
                Console.WriteLine("[2] Historico de transferências");
                Console.WriteLine("[3] Voltar");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        FluxoExtratoTransacoes();
                        break;
                    case "2":
                        FluxoHistoricoTransferencias();
                        break;
                    case "3":
                        sair = true;
                        break;
                    default:
                        InvalidOption();
                        break;
                }
            } while (!sair);
        }
        private void MenuContaInvest()
        {
            bool sair = false;
            do
            {
                Console.Clear();
                Console.WriteLine("O que deseja fazer? \n");
                Console.WriteLine("[1] Investir");
                Console.WriteLine("[2] Simular investimentos");
                Console.WriteLine("[3] Extrato de transações");
                Console.WriteLine("[4] Historico de transferências");
                Console.WriteLine("[5] Voltar");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        FluxoInvestir();
                        break;
                    case "2":
                        FluxoSimularInvestimento();
                        break;
                    case "3":
                        FluxoExtratoTransacoes();
                        break;
                    case "4":
                        FluxoHistoricoTransferencias();
                        break;
                    case "5":
                        sair = true;
                        break;
                    default:
                        InvalidOption();
                        break;
                }
            } while (!sair);
        }
        private static bool MenuSimOuNao(string texto)
        {
            bool sair = false;
            bool confirma = false;
            do
            {
                Console.Clear();
                Console.WriteLine(texto);
                Console.WriteLine("[1] Sim");
                Console.WriteLine("[2] Não");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        confirma = true;
                        sair = true;
                        break;
                    case "2":
                        sair = true;
                        break;
                    default:
                        InvalidOption();
                        break;
                }
            } while (!sair);

            return confirma;
        }
        private static TipoInvestimentoEnum MenuEscolhaInvestimento()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha o tipo de investimento: ");
                Console.WriteLine($"[1] {TipoInvestimento.PegaNome(TipoInvestimentoEnum.LCI)} (resgate em {TipoInvestimento.PegaRentabilidade(TipoInvestimentoEnum.LCI)} meses) ");
                Console.WriteLine($"[2] {TipoInvestimento.PegaNome(TipoInvestimentoEnum.LCA)} (resgate em {TipoInvestimento.PegaRentabilidade(TipoInvestimentoEnum.LCA)} meses) ");
                Console.WriteLine($"[3] {TipoInvestimento.PegaNome(TipoInvestimentoEnum.CDB)} (resgate em {TipoInvestimento.PegaRentabilidade(TipoInvestimentoEnum.CDB)} meses) ");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        return TipoInvestimentoEnum.LCI;
                    case "2":
                        Console.Clear();
                        return TipoInvestimentoEnum.LCA;
                    case "3":
                        Console.Clear();
                        return TipoInvestimentoEnum.CDB;
                    default:
                        InvalidOption();
                        break;
                }
            } while (true);
        }
        private static AgenciaEnum MenuEscolhaAgencia()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha sua agência: \n");
                Console.WriteLine($"[1] {Agencia.PegaNome(AgenciaEnum.Fpolis)}");
                Console.WriteLine($"[2] {Agencia.PegaNome(AgenciaEnum.SaoJose)}");
                Console.WriteLine($"[3] {Agencia.PegaNome(AgenciaEnum.Biguacu)}");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        return AgenciaEnum.Fpolis;
                    case "2":
                        Console.Clear();
                        return AgenciaEnum.SaoJose;
                    case "3":
                        Console.Clear();
                        return AgenciaEnum.Biguacu;
                    default:
                        InvalidOption();
                        break;
                }
            } while (true);
        }
    }
}
