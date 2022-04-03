
using DevinBank.Library;
using DevinBank.Library.Enums;
using DevinBank.Library.Modelos;
using DevinBank.Library.Utils;

namespace DevinBank.App.UI
{
    public partial class ConsoleUI
    {
        private IBanco Banco { get; set; } = new Banco();
        private Conta? Conta { get; set; }

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
                    Banco.SalvarConta(new Poupanca(nome, cpf, renda, new Agencia(agencia)));
                }
                else if (tipoConta == "corrente")
                {
                    Banco.SalvarConta(new Corrente(nome, cpf, renda, new Agencia(agencia)));
                }
                else
                {
                    Banco.SalvarConta(new Investimentos(nome, cpf, renda, new Agencia(agencia)));
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

        }
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
        }
        private void FluxoListarContas()
        {
            Console.Clear();
            try
            {
                Console.WriteLine(Banco.ListarContas());
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

        }
        private void FluxoListarContasSaldoNegativo()
        {
            Console.Clear();
            try
            {
                Console.WriteLine(Banco.ListarContasSaldoNegativo());
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

        }
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

        }
        private void FluxoExtratoTransacoesCliente()
        {
            Console.Clear();
            int numConta = Validacoes.ValidaInt("Informe o número da conta do cliente: ");
            try
            {
                Console.WriteLine(Banco.AcessarConta(numConta).ExtratoTransacoes());
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }

            PressKey();
        }
        private void FluxoMudarData()
        {
            Console.Clear();
            int dia = Validacoes.ValidaInt("Informe primeiro o dia (dd): ");
            int mes = Validacoes.ValidaInt("Agora o Mês (mm): ");
            int ano = Validacoes.ValidaInt("Por ultimo, informe o Ano (yyyy): ");
            try
            {
                Banco.AtualizaData(new DateTime(ano, mes, dia));
                Console.WriteLine("A data foi atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            UpdateTittle(false);
            FluxoAtualizarContas();
            PressKey();

        }
        private void FluxoAtualizarContas()
        {
            try
            {
                Banco.AtualizaContas();
                Console.WriteLine("\n\nO valor das aplicações também foi atualizado!");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\n{ex.Message}");
            }
        }
        private void FluxoSaque()
        {
            Console.Clear();
            decimal montante = Validacoes.ValidaDecimal("Quanto quer sacar?");
            try
            {
                Conta?.Saque(montante, Banco.Data);
                Console.WriteLine($"Saque de R$ {montante:N2} realizado com sucesso!");
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

        }
        private void FluxoDeposito()
        {
            Console.Clear();
            decimal montante = Validacoes.ValidaDecimal("Quanto quer depositar?");
            try
            {
                Conta?.Deposito(montante, Banco.Data);
                Console.WriteLine($"Depósito de R$ {montante:N2} realizado com sucesso!");
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

        }
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

        }
        private void FluxoExtrato()
        {
            Console.Clear();
            Console.WriteLine("Seu extrato: ");
            try
            {
                Console.WriteLine(Conta?.Extrato());
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();
        }
        private void FluxoEditarCadastro(string opcao)
        {
            Console.Clear();
            if (opcao == "nome")
            {
                string nome = Validacoes.ValidaString("Digite o novo nome: ");
                try
                {
                    Conta?.AlterarCadastro(nome);
                }
                catch (Exception ex)
                {
                    ErrorMsg(ex);
                }
            }
            else if (opcao == "renda")
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
        }
        private void FluxoMaisOpcoes()
        {
            Console.Clear();
            if (Conta is Poupanca)
            {
                MenuContaPoupanca();
            }
            else if (Conta is Corrente)
            {
                MenuContaCorrente();
            }
            else
            {
                MenuContaInvest();
            }
        }
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
        }
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
        }
        private void FluxoSimularRendimentoPoupanca()
        {
            Console.Clear();
            try
            {
                if (Conta!.Saldo > 0)
                {
                    int tempo = Validacoes.ValidaInt("Informe a quantidade de tempo(em meses): ");
                    int rentab = Validacoes.ValidaInt("Informe a rentabilidade anual: ");

                    decimal rend = Poupanca.SimularRendimento(Conta.Saldo, tempo, rentab);
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

        }
        private void FluxoEscolhaDeposito()
        {

            if (MenuSimOuNao("Deseja realizar um depósito agora? \n"))
                FluxoDeposito();
        }
        private void FluxoSimularInvestimento()
        {
            Console.Clear();
            var tipoInvest = MenuEscolhaInvestimento();
            decimal montante = Validacoes.ValidaDecimal("Qual valor deseja aplicar? ");
            int tempo = Validacoes.ValidaInt("Informe a quantidade de tempo(em meses): ");
            try
            {
                decimal rend = Investimentos.SimularRendimento(montante, tempo, new TipoInvestimento(tipoInvest));
                Console.WriteLine($"Saldo ao final: R${rend + montante:N2}");
                Console.WriteLine($"Rendimentos totais: R${rend:N2}");
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

            FluxoEscolhaInvestir(montante, tempo, tipoInvest);

        }
        private void FluxoEscolhaInvestir(decimal montante, int tempo, TipoInvestimentoEnum tipoInvest)
        {

            if (MenuSimOuNao("Deseja realizar este investimento? \n"))
                FluxoInvestir(montante, tempo, tipoInvest);
        }
        private void FluxoInvestir()
        {
            Console.Clear();
            var tipoInvest = MenuEscolhaInvestimento();
            decimal montante = Validacoes.ValidaDecimal("Qual valor deseja aplicar? ");
            int tempo = Validacoes.ValidaInt("Informe a quantidade de tempo(em meses): ");
            try
            {
                if (Conta is Investimentos conta)
                    conta.Investimento(montante, tempo, Banco.Data, new TipoInvestimento(tipoInvest));
                Console.WriteLine($"Investimento de R$ {montante:N2} em {TipoInvestimento.PegaNome(tipoInvest)} realizado com sucesso!");
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

        }
        private void FluxoInvestir(decimal montante, int tempo, TipoInvestimentoEnum tipoInvest)
        {
            Console.Clear();
            try
            {
                if (Conta is Investimentos conta)
                    conta.Investimento(montante, tempo, Banco.Data, new TipoInvestimento(tipoInvest));
                Console.WriteLine($"Investimento de R$ {montante:N2} em {TipoInvestimento.PegaNome(tipoInvest)} realizado com sucesso!");
            }
            catch (Exception ex)
            {
                ErrorMsg(ex);
            }
            PressKey();

        }
    }
}
