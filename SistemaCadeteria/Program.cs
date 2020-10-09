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

            foreach (Cadete cadete in nCadeteria.ListadoCadetes)
            {
                foreach (Pedido pedido in cadete.ListadoPedidos)
                {
                    TPedido TipoPedido = pedido.TipoPedido;
                    if (Helper.DicVehiculoPedido.TryGetValue(cadete.TipoVehiculo, out TipoPedido))
                    {
                        if (aleat.Next(2) == 1)
                        {
                            cadete.AgregarPedido(pedido);
                        }
                    }
                }
            }



            Helper.GenerarInforme(nCadeteria);

            Delicado PedidoDelicado = new Delicado();

        }
    }
}
