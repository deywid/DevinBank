using DevinBank.Library;
using DevinBank.Library.Enums;
using DevinBank.Library.Modelos;
using DevinBank.Library.Utils;

namespace DevinBank.App
{
    public class ConsolePatterns
    {
        private IBanco Banco { get; set; } = new Banco();
        private IConta? Conta { get; set; } 

        #region Menus -ok
        public void MainMenu()
        {
            AtualizaTitulo(false);
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
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        } //ok
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
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        } //ok
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
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        } //ok
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
                        AtualizaTitulo(false);
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        } //ok
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
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        } //ok
        private void MenuContaPoupanca()
        {
            bool sair = false;
            do
            {
                Console.Clear();
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
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        } //ok
        private void MenuContaCorrente()
        {
            bool sair = false;
            do
            {
                Console.Clear();
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
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        } //ok
        private void MenuContaInvest() //ok
        {
            bool sair = false;
            do
            {
                Console.Clear();
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
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);
        }
        private static bool MenuSimOuNao()
        {
            bool sair = false;
            bool confirma = false;
            do
            {
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
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (!sair);

            return confirma;
        } //ok
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
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (true);
        } //ok
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
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (true);
        } //ok
        #endregion

        #region Fluxos
        private void FluxoCriarConta(string tipoConta)
        {
            Console.Clear();
            string nome = Validacoes.ValidaString("Informe seu nome: ");
            string cpf = Validacoes.PegaCPF("Informe seu CPF: ");
            decimal renda = Validacoes.ValidaDecimal("Informe sua renda mensal: ");           
            AgenciaEnum agencia = MenuEscolhaAgencia();
            try
            {
                if (tipoConta == "poupança")
                {
                    Banco.SalvarConta(new ContaPoupanca(nome, cpf, renda, new Agencia(agencia)));
                } 
                else if(tipoConta == "corrente")
                {
                    Banco.SalvarConta(new ContaCorrente(nome, cpf, renda, new Agencia(agencia)));
                }
                else
                {
                    Banco.SalvarConta(new ContaInvestimento(nome, cpf, renda, new Agencia(agencia)));
                }

                Console.Clear();
                Console.WriteLine("Sua conta foi criada com sucesso! \n");
                Console.WriteLine($"Este é o número da conta: {Banco.Contas.LastOrDefault()?.NumConta}\nGuarde-o em segurança!");
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

        } // teste ok
        private void FluxoAcessarConta()
        {
            Console.Clear();
            string cpf = Validacoes.PegaCPF("Informe seu CPF: ");
            int numConta = Validacoes.ValidaInt("Informe o número da conta: ");
            try
            {
                Conta = Banco.AcessarConta(cpf, numConta);
                Greetings();
                MenuConta();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao tentar acessar conta. {ex.Message}");
                PressKey();
            }
        } // teste ok
        private void FluxoListarContas()
        {
            Console.Clear();
            try
            {
                Console.WriteLine(Banco.ListarContas());
            }
            catch(Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

        } //teste ok
        private void FluxoListarContasSaldoNegativo()
        {
            Console.Clear();
            try
            {
                Banco.ListarContasSaldoNegativo();
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

        } //teste ok
        private void FluxoTotalEmInvestimentos()
        {
            Console.Clear();
            try
            {
                Console.WriteLine($"Valor total dos investimentos: R$ {Banco.TotalEmInvestimentos():N2}");
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

        } // teste ok
        private void FluxoExtratoTransacoesCliente()
        {
            Console.Clear();
            int numConta = Validacoes.ValidaInt("Informe o número da conta do cliente: ");
            try
            {
                Console.WriteLine(Banco.AcessarConta(numConta).ExtratoTransacoes());
            }
            catch(Exception ex)
            {
                ErrorMsg(ex);
            }

            PressKey();
        } // teste ok
        private void FluxoMudarData()
        {
            Console.Clear();
            int dia = Validacoes.ValidaInt("Informe primeiro o dia (dd): ");
            int mes = Validacoes.ValidaInt("Agora o Mês (mm): ");
            int ano = Validacoes.ValidaInt("Por ultimo, informe o Ano (yyyy): ");
            try
            {
                Banco.AtualizaData(new DateTime(ano, mes, dia));
                Banco.AtualizaContas();
                Console.WriteLine("A data foi atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

        } // teste ok
        private void FluxoSaque()
        {
            Console.Clear();
            decimal montante = Validacoes.ValidaDecimal("Quanto quer sacar?");
            try
            {
                Conta?.Saque(montante, Banco.Data);
                Console.WriteLine($"Saque de R${montante:N2} realizado com sucesso!");
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

        } //teste ok
        private void FluxoDeposito()
        {
            Console.Clear();
            decimal montante = Validacoes.ValidaDecimal("Quanto quer depositar?");
            try
            {
                Conta?.Deposito(montante, Banco.Data);
                Console.WriteLine($"Depósito de R${montante:N2} realizado com sucesso!");
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

        } // teste ok
        private void FluxoTransferencia()
        {
            Console.Clear();
            decimal montante = Validacoes.ValidaDecimal("Quanto quer transferir? ");
            int numConta = Validacoes.ValidaInt("Para qual conta deseja transferir? ");
            try
            {
                var benef = Banco.AcessarConta(numConta);
                Conta?.Transferencia(benef, montante, Banco.Data);
                Console.WriteLine($"Transferência de R$ {montante:N2} para {benef.Nome} realizada com sucesso!");
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

        } // teste ok
        private void FluxoExtrato()
        {
            Console.Clear();
            Console.WriteLine("Seu extrato: ");
            try
            {
                Console.WriteLine(Conta?.Extrato());
            }
            catch(Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();
        } // teste ok
        private void FluxoEditarCadastro(string opcao)
        {
            Console.Clear();
            if(opcao == "nome")
            {
                string nome = Validacoes.ValidaString("Digite o novo nome: ");
                try
                {
                    Conta?.AlterarCadastro(nome);
                }
                catch(Exception ex)
                {
                    ErrorMsg(ex);
                }
            }
            else if(opcao == "renda")
            {
                decimal renda = Validacoes.ValidaDecimal("Informe sua nova renda: ");
                try
                {
                    Conta?.AlterarCadastro(renda);
                }
                catch (Exception ex)
                {
                    ErrorMsg(ex);
                }
            }
            else
            {
                AgenciaEnum agencia = MenuEscolhaAgencia();
                try
                {
                    Conta?.AlterarCadastro(new Agencia(agencia));
                }
                catch (Exception ex)
                {
                    ErrorMsg(ex);
                }
            }
        } // teste ok
        private void FluxoMaisOpcoes()
        {
            Console.Clear();
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
        } // s/teste ok
        private void FluxoExtratoTransacoes()
        {
            Console.Clear();
            try
            {
                Console.WriteLine(Conta?.ExtratoTransacoes());
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();
        } // teste ok
        private void FluxoHistoricoTransferencias()
        {
            Console.Clear();
            try
            {
                Console.WriteLine(Conta?.HistoricoTransferencias());
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();
        } // teste ok
        private void FluxoSimularRendimentoPoupanca()
        {
            Console.Clear();
            try
            {
                if (Conta!.Saldo > 0)
                {
                    int tempo = Validacoes.ValidaInt("Informe a quantidade de tempo(em meses): ");
                    int rentab = Validacoes.ValidaInt("Informe a rentabilidade anual: ");

                    decimal rend = ContaPoupanca.SimularRendimento(Conta.Saldo, tempo, rentab);
                    Console.WriteLine($"Saldo ao final: R${rend + Conta.Saldo:N2}");
                    Console.WriteLine($"Rendimentos totais: R${rend:N2}");
                }
                else
                {
                    throw new Exception("Não é possível simular seus rendimentos. Sem saldo em conta.");
                }
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

            FluxoEscolhaDeposito();

        } //ok
        private void FluxoEscolhaDeposito()
        {
            Console.Clear();
            Console.WriteLine("Deseja realizar um depósito agora? \n");
            if (MenuSimOuNao())
                FluxoDeposito();

        } // s/teste ok
        private void FluxoSimularInvestimento()
        {
            Console.Clear();
            var tipoInvest = MenuEscolhaInvestimento();
            decimal montante = Validacoes.ValidaDecimal("Qual valor deseja aplicar? ");
            int tempo = Validacoes.ValidaInt("Informe a quantidade de tempo(em meses): ");
            try
            {
                decimal rend = ContaInvestimento.SimularRendimento(montante, tempo, new TipoInvestimento(tipoInvest));
                Console.WriteLine($"Saldo ao final: R${rend + montante:N2}");
                Console.WriteLine($"Rendimentos totais: R${rend:N2}");
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

            FluxoEscolhaInvestir(montante, tempo, tipoInvest);

        } //ok
        private void FluxoEscolhaInvestir(decimal montante, int tempo, TipoInvestimentoEnum tipoInvest)
        {
            Console.Clear();
            Console.WriteLine("Deseja realizar este investimento? \n");
            if (MenuSimOuNao())
                FluxoInvestir(montante, tempo, tipoInvest);

        } // s/teste ok
        private void FluxoInvestir()
        {
            Console.Clear();
            var tipoInvest = MenuEscolhaInvestimento();
            decimal montante = Validacoes.ValidaDecimal("Qual valor deseja aplicar? ");
            int tempo = Validacoes.ValidaInt("Informe a quantidade de tempo(em meses): ");
            try
            {
                if (Conta is ContaInvestimento conta)
                    conta.Investimento(montante, tempo, Banco.Data, new TipoInvestimento(tipoInvest));
                Console.WriteLine($"Investimento de R$ {montante:N2} em {TipoInvestimento.PegaNome(tipoInvest)} realizado com sucesso!");
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

        } // teste ok
        private void FluxoInvestir(decimal montante, int tempo, TipoInvestimentoEnum tipoInvest)
        {
            Console.Clear();
            try
            {
                if (Conta is ContaInvestimento conta)
                    conta.Investimento(montante, tempo, Banco.Data, new TipoInvestimento(tipoInvest));
                Console.WriteLine($"Investimento de R$ {montante:N2} em {TipoInvestimento.PegaNome(tipoInvest)} realizado com sucesso!");
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

        } // teste ok
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
        private static void PressKey()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey(true);
        }
        private static void ErrorMsg(Exception ex)
        {
            Console.WriteLine($"Não foi possível processar a requisição. {ex.Message}");
        }
        private void Greetings()
        {
            Console.Clear();
            AtualizaTitulo(true);
            Console.WriteLine($"Que bom que você veio, {Conta!.Nome}!");
            PressKey();
        }
        private void AtualizaTitulo(bool isLoggedin)
        {
            if (isLoggedin)
            {
                Console.Title = $"|DevIn BANK        |Cliente: {Conta!.Nome}        |Conta: {Conta.NumConta}        |Data: {Banco.Data:d}".ToUpper();
            }
            else
            {
                Console.Title = "|DevIn BANK";
            }
        }
        #endregion

      
    }
}
