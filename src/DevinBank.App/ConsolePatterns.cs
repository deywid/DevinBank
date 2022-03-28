using DevinBank.Library;
using DevinBank.Library.Enums;

namespace DevinBank.App
{
    public class ConsolePatterns
    {
        private IBanco Banco { get; set; } = new Banco();
        private IConta? Conta { get; set; } 

        #region Menus tipicos
        public void MainMenu()
        {
            Console.Clear();
            bool sair = false;
            do
            {
                Console.WriteLine("Selecione a opção desejada: \n");
                Console.WriteLine("[1] Acessar conta ");
                Console.WriteLine("[2] Criar nova conta ");
                Console.WriteLine("[3] Encerrar aplicação ");
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
                        Console.Clear();
                        sair = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        }
        private void MenuCriarConta()
        {
            Console.Clear();
            bool sair = false;

            do
            {
                Console.WriteLine("Qual o tipo de conta deseja criar? \n");
                Console.WriteLine("[1] Criar conta corrente");
                Console.WriteLine("[2] Criar conta poupança");
                Console.WriteLine("[3] Criar conta de investidor");
                Console.WriteLine("[4] Voltar ao menu inicial");
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
                        Console.Clear();
                        sair = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        }
        private static AgenciaEnum MenuEscolhaAgencia()
        {
            Console.Clear();

            do
            {
                Console.WriteLine("Escolha sua agência: \n");
                Console.WriteLine("[1] 001 - Florianópolis ");
                Console.WriteLine("[2] 002 - São José ");
                Console.WriteLine("[3] 003 - Biguaçu ");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        return AgenciaEnum.Fpolis;
                    case "2":
                        return AgenciaEnum.SaoJose;
                    case "3":
                        return AgenciaEnum.Biguacu;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (true);
        }
        private void MenuConta()
        {
            Console.Clear();
            bool sair = false;
            do
            {
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
                        FluxoMenuConta();
                        break;
                    case "7":
                        Console.Clear();
                        sair = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        }
        private void MenuAlterarCadastro()
        {
            Console.Clear();
            bool sair = false;
            do
            {
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
                        Console.Clear();
                        sair = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        }
        #endregion

        #region Fluxos tipicos
        private void FluxoCriarConta(string tipoConta)
        {
            Console.Clear();

            Console.WriteLine("Informe seu nome: ");
            string nome = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Informe seu CPF: ");
            string cpf = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Informe sua renda mensal: ");
            decimal renda = decimal.Parse(Console.ReadLine());
            AgenciaEnum agencia = MenuEscolhaAgencia();
            Console.Clear();

            if (tipoConta == "poupança")
            {
                Banco.SalvarConta(new ContaPoupanca(nome, cpf, renda, agencia));
            } 
            else if(tipoConta == "corrente")
            {
                Banco.SalvarConta(new ContaCorrente(nome, cpf, renda, agencia));
            }
            else
            {
                Banco.SalvarConta(new ContaInvestimento(nome, cpf, renda, agencia));
            }
        }
        private void FluxoAcessarConta()
        {
            Console.Clear();
            Console.WriteLine("Informe seu CPF: ");
            string cpf = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Informe o número da conta: ");
            int numConta = int.Parse(Console.ReadLine());
            
            Conta = Banco.AcessarConta(cpf, numConta);

            MenuConta();
        }
        #endregion

        #region Fluxos de MenuConta
        private void FluxoSaque()
        {
            Console.Clear();
            Console.WriteLine("Quanto quer sacar?");
            decimal montante = decimal.Parse(Console.ReadLine());

            Conta.Saque(montante, Banco.DataAtual());
        }
        private void FluxoDeposito()
        {
            Console.Clear();
            Console.WriteLine("Quanto quer depositar?");
            decimal montante = decimal.Parse(Console.ReadLine());

            Conta.Deposito(montante, Banco.DataAtual());
        }
        private void FluxoTransferencia()
        {
            Console.Clear();
            Console.WriteLine("Quanto quer transferir?");
            decimal montante = decimal.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Para qual conta deseja transferir?");
            int numConta = int.Parse(Console.ReadLine());

            Conta.Transferencia(Banco.AcessarConta(numConta), montante, Banco.DataAtual());

        }
        private void FluxoExtrato()
        {
            Console.Clear();
            Console.WriteLine("Seu extrato: \n");

            Console.WriteLine(Conta.Extrato());
            Console.ReadKey(true);
        }
        private void FluxoEditarCadastro(string opcao)
        {
            Console.Clear();
            if(opcao == "nome")
            {
                Console.WriteLine("Digite o novo nome: ");
                string nome = Console.ReadLine();
                Conta.AlterarCadastro(nome);
            }
            else if(opcao == "renda")
            {
                Console.WriteLine("Informe sua nova renda: ");
                decimal renda = decimal.Parse(Console.ReadLine());
                Conta.AlterarCadastro(renda);
            }
            else
            {
                AgenciaEnum agencia = MenuEscolhaAgencia();
                Conta.AlterarCadastro(agencia);
            }
        }

        private void FluxoSimularRendimentoPoupanca()
        {
            Console.Clear();
            Console.WriteLine("Informe a quantidade de tempo(em meses): ");
            int tempo = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe a rentabilidade anual: ");
            int rentab = int.Parse(Console.ReadLine());

            if(Conta is ContaPoupanca conta)
            {
                conta.SimularRendimento(Conta.Saldo, tempo, rentab);
            }
            Console.ReadKey(true);
        }
        private void FluxoInvestimento(bool simular)
        {
            Console.Clear();
            var tipoInvest = MenuEscolhaInvestimento();
            Console.WriteLine("Qual valor deseja aplicar? ");
            decimal montante = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Informe a quantidade de tempo(em meses): ");
            int tempo = int.Parse(Console.ReadLine());

            if (simular)
            {
                if (Conta is ContaInvestimento conta)
                {
                    var rendimentos = conta.SimularRendimento(montante, tempo, new TipoInvestimento(tipoInvest));
                    Console.WriteLine($"Rendimentos: R$ {rendimentos}");
                }
                Console.ReadKey(true);
            }
            else
            {
                if (Conta is ContaInvestimento conta)
                    conta.Investimento(montante, tempo, Banco.DataAtual(), new TipoInvestimento(tipoInvest));
            }
            Console.ReadKey(true);

        }
        #endregion
       
        #region Menus especiais de MenuConta
        private void FluxoMenuConta()
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer? \n");
            if (Conta is ContaPoupanca)
            {
                MenuContaPoupanca();
            }
            else if(Conta is ContaCorrente)
            {
                MenuContaCorrente();
            }
            else
            {
                MenuContaInvest();
            } 
        }
        private void MenuContaPoupanca()
        {
            bool sair = false;
            do
            {
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
                        Console.Clear();
                        Console.WriteLine(Conta.ExtratoTransacoes());
                        Console.ReadKey(true);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine(Conta.HistoricoTransferencias());
                        Console.ReadKey(true);
                        break;
                    case "4":
                        Console.Clear();
                        sair = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        }
        private void MenuContaCorrente()
        {
            bool sair = false;
            do
            {
                Console.WriteLine("[1] Extrato de transações");
                Console.WriteLine("[2] Historico de transferências");
                Console.WriteLine("[3] Voltar");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(Conta.ExtratoTransacoes());
                        Console.ReadKey(true);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine(Conta.HistoricoTransferencias());
                        Console.ReadKey(true);
                        break;
                    case "3":
                        Console.Clear();
                        sair = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        }
        private void MenuContaInvest()
        {
            bool sair = false;
            do
            {
                Console.WriteLine("[1] Investir");
                Console.WriteLine("[2] Simular investimentos");
                Console.WriteLine("[3] Extrato de transações");
                Console.WriteLine("[4] Historico de transferências");
                Console.WriteLine("[5] Voltar");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        FluxoInvestimento(false);
                        break;
                    case "2":
                        FluxoInvestimento(true);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine(Conta.ExtratoTransacoes());
                        Console.ReadKey(true);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine(Conta.HistoricoTransferencias());
                        Console.ReadKey(true);
                        break;
                    case "5":
                        Console.Clear();
                        sair = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        }
        private static TipoInvestimentoEnum MenuEscolhaInvestimento()
        {
            Console.Clear();
            do
            {
                Console.WriteLine("Escolha o tipo de investimento: ");
                Console.WriteLine("[1] LCI: 8% a.a (resgate em 6 meses) ");
                Console.WriteLine("[2] LCA: 9% a.a (resgate em 12 meses) ");
                Console.WriteLine("[3] CDB: 10% a.a (resgate em 36 meses) ");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        return TipoInvestimentoEnum.LCI;
                    case "2":
                        return TipoInvestimentoEnum.LCA;
                    case "3":
                        return TipoInvestimentoEnum.CDB;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (true);
        }
        #endregion

        #region Misc
        public static void Logo()
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
        #endregion

    }
}
