using DesafioFundamentos.InterfaceUsuario;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal _precoInicial = 0;
        private decimal _precoPorHora = 0;
        private List<CartaoEstacionameno> veiculosEstacionados = new List<CartaoEstacionameno>();

        public decimal PrecoInicial { get => _precoInicial; private set => _precoInicial = value; }
        public decimal PrecoPorHora { get => _precoPorHora; private set => _precoPorHora = value; }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            CartaoEstacionameno c = new CartaoEstacionameno();
            c.RegistraCartão();
            veiculosEstacionados.Add(c);
        }
        public void RemoverVeiculoCosoleMenu()
        {
            ListarVeiculos();
            if (veiculosEstacionados.Count > 0)
            {
                string[] itensFormatados = veiculosEstacionados.Select(item => $"\n- Modelo: {item.Veiculoestacionado.Modelo} \n- Placa: {item.Veiculoestacionado.Placa}").ToArray();
                var opcoes = new ConsoleMenu<string>(itensFormatados);
                int selecaoUsario = opcoes.ShowMenu();
                // Pedir para o usuário digitar a placa e armazenar na variável placa
                // *IMPLEMENTE AQUI*


                var cartão = veiculosEstacionados[selecaoUsario];

                // Verifica se o veículo existe
                if (cartão != null)
                {
                    cartão.RegistraSaida();
                    Console.WriteLine("Calculando valor a ser pago ....");
                    Thread.Sleep(2000);

                    // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                    // *IMPLEMENTE AQUI*
                    int horas = cartão.RegistraSaida();
                    decimal valorTotal = _precoInicial + (_precoPorHora * horas);

                    // TODO: Remover a placa digitada da lista de veículos
                    // *IMPLEMENTE AQUI*
                    veiculosEstacionados.Remove(cartão);
                    Console.WriteLine($"O veículo {cartão.Veiculoestacionado.Placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
        }

        public void RemoverVeiculo()
        {
            ListarVeiculos();
            if (veiculosEstacionados.Count > 0)
            {

                Console.Write("Digite a placa do veículo para remover: ");
                // Pedir para o usuário digitar a placa e armazenar na variável placa
                // *IMPLEMENTE AQUI*
                string placa = Console.ReadLine();

                var cartão = veiculosEstacionados.FirstOrDefault(c => c.Veiculoestacionado.Placa == placa);

                // Verifica se o veículo existe
                if (cartão != null)
                {
                    cartão.RegistraSaida();
                    Console.WriteLine("Calculando valor a ser pago ....");
                    Thread.Sleep(2000);

                    // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                    // *IMPLEMENTE AQUI*
                    int horas = cartão.RegistraSaida();
                    decimal valorTotal = _precoInicial + (_precoPorHora * horas);

                    // TODO: Remover a placa digitada da lista de veículos
                    // *IMPLEMENTE AQUI*
                    veiculosEstacionados.Remove(cartão);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculosEstacionados.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach (var item in veiculosEstacionados)
                {
                    Console.WriteLine("======================");
                    item.Veiculoestacionado.ApresentaVeiculo();
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void ListarCartoesVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculosEstacionados.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach (var item in veiculosEstacionados)
                {
                    Console.WriteLine("======================");
                    item.ApresentaCartão();
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void RecebeValores()
        {
            bool PrecoIniciaEhDecimal;
            bool PrecoPHEhDecimal;
            do
            {
                Console.Write("Seja bem vindo ao sistema de estacionamento!\n" +
                                  "Digite o preço inicial: R$");

                PrecoIniciaEhDecimal = decimal.TryParse(Console.ReadLine(), out decimal PrecoInicial);

                Console.Write("Agora digite o preço por hora: R$");

                PrecoPHEhDecimal = decimal.TryParse(Console.ReadLine(), out decimal PrecoPorHora);
                if (PrecoIniciaEhDecimal || PrecoPHEhDecimal)
                {
                
                    _precoInicial = PrecoInicial;
                    _precoPorHora = PrecoPorHora;

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Entrada incorreta! Digite novamente");
                }
            } while (!PrecoIniciaEhDecimal || !PrecoPHEhDecimal);
        }
    }
}
