using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    internal class Veiculo
    {
        private string _placa;
        private string _modelo;

        public string Placa
        {
            get => _placa;
            set
            {
                if (value.Length != 7)
                {
                    throw new ArgumentException("Placa Inválida");
                }
                _placa = value;
            }
        }

        public string Modelo { get => _modelo; private set => _modelo = value; }

        public void CadastraVeiculo()
        {
            string entradaModelo;
            string entradaPlaca;
            do
            {
                Console.WriteLine("Digite o Modelo Do veiculo");
                entradaModelo = Console.ReadLine();
                Console.WriteLine("Digite a Placa Do veiculo");
                entradaPlaca = Console.ReadLine();
                if( entradaModelo =="" || entradaPlaca == ""||entradaPlaca.Length != 7)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada errada Digite Novamente!");
                }
            } while (entradaModelo == "" || entradaPlaca == "" || entradaPlaca.Length!=7);

            _modelo = entradaModelo;
            _placa = entradaPlaca;
        }

        public void ApresentaVeiculo()
        {
            Console.WriteLine($"Modelo: {_modelo}");

            Console.WriteLine($"Placa: {_placa}");

        }


    }
}
