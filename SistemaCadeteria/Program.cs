using SistemaCadeteria.Entidades.Tipos_Pedidos;
using System;
using System.Collections.Generic;

namespace ProgramaCadeteria
{
    class Program
    {
        static void Main(string[] args)
        {
            Random aleat = new Random();

            Cadeteria nCadeteria = new Cadeteria();

            Helper.GenerarListadoCadetes(nCadeteria.ListadoCadetes);

            List<Pedido> listadoPedidosAleatorios = new List<Pedido>();
            Helper.GenerarListadoPedidos(listadoPedidosAleatorios);

            //DE UNA LISTA DE PEDIDOS ALEATORIOS DETERMINA PARA CADA CADETE EL PEDIDO, SI EL CADETE LO ACEPTA
            foreach (Cadete cadete in nCadeteria.ListadoCadetes)
            {
                Helper.DeterminarPedidosCadete(cadete, listadoPedidosAleatorios);
                Helper.DeterminarEntregaPedidos(cadete.ListadoPedidos);
            }

            Helper.MostrarInformacionCompletaCadeteria(nCadeteria);

            Helper.GenerarInforme(nCadeteria);

            Console.ReadLine();
        }
    }
}
