using DesafioFundamentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFundamentos.InterfaceUsuario
{
    internal class interfacePrincipal
    { 
        public static void ExibeMenuPrincipal()
        {
            var es = new Estacionamento();
            es.RecebeValores();
            string[] opcoesUsuario ={ "1 - Cadastrar veículo", "2 - Remover veículo (Através da placa)", "3 - Remover veículo (Menu interativo)", "4 - Listar veículos", "5 - Listar Cartões veículos", "6 - Encerrar" };
            bool exibirMenu = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Digite a sua opção:");
                var opcoes = new ConsoleMenu<string>(opcoesUsuario);
                var selecaoUsario = opcoes.ShowMenu();
                switch (selecaoUsario)
                {
                    case 0:
                        es.AdicionarVeiculo();
                        break;

                    case 1:
                        es.RemoverVeiculo();
                        break;
                    
                    case 2:
                        es.RemoverVeiculoCosoleMenu();
                        break;

                    case 3:
                       es.ListarVeiculos();
                        break;
                    case 4:
                        es.ListarCartoesVeiculos();
                        break;

                    case 5:
                        exibirMenu = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadLine();
            }while (exibirMenu);
        }
    }
}
