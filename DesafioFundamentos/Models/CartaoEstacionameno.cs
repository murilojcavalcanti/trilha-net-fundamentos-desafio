using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    internal class CartaoEstacionameno
    {
        private DateTime _horarioEntrada ;
        private DateTime _horarioSaida;
        private Veiculo _veiculoestacionado;

        public DateTime HorarioSaida { get => _horarioSaida; private set => _horarioSaida = value; }
        public DateTime HorarioEntrada { get => _horarioEntrada; set => _horarioEntrada = value; }
        internal Veiculo Veiculoestacionado { get => _veiculoestacionado; private set => _veiculoestacionado = value; }

        public void RegistraCartão()
        {
            var v = new Veiculo();
            v.CadastraVeiculo();
            _veiculoestacionado = v;
            _horarioEntrada = DateTime.Now;
        }

        public int RegistraSaida()
        {
            _horarioSaida = DateTime.Now.AddMinutes(15);
            double diferencaEmHoras = (_horarioSaida - _horarioEntrada).TotalHours;
            int diferenca = (int)(Math.Ceiling(diferencaEmHoras));

            return diferenca;
        }

        public void ApresentaCartão()
        {
            Console.WriteLine("=============================================================\n");
            Console.WriteLine($"Horario de entrada: {_horarioEntrada.ToString("HH:mm")}");
            Console.WriteLine($"Horario de saida: {_horarioSaida.ToString("HH:mm")}");
            Console.WriteLine($"Modelo: {Veiculoestacionado.Modelo}");
            Console.WriteLine($"Placa: {Veiculoestacionado.Placa}");
            
            Console.WriteLine("\n=============================================================");
        }

    }
}
