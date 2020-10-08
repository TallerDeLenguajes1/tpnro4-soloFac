using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace ProgramaCadeteria
{
    class Cadeteria
    {
        private string nombre;
        private List<Cadete> listadoCadetes;

        public string Nombre { get => nombre; set => nombre = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

        public Cadeteria()
        {
            //Composicion
            this.ListadoCadetes = new List<Cadete>();
        }

        public Cadeteria(string Nombre, List<Cadete> ListadoCadetes)
        {
            this.Nombre = Nombre;
            //Composicion con Cadetes
            this.ListadoCadetes = new List<Cadete>(ListadoCadetes);
        }

        /// <summary>
        /// Recibe un diccionario <Cadete, CantidadPedidos(int)> y devuelve el cadete con mas entregas
        /// </summary>
        /// <param name="dicCadetePedido"></param>
        public Cadete CadeteMasEntregas()
        {
            Cadete CadeteMasEntregas = new Cadete();
            int MaxPedidosEntregados = 0;

            foreach (Cadete cadete in this.ListadoCadetes)
            {
                int cantPedidosEntregados = cadete.DeterminarCantidadPedidosEntregados();
                if (cantPedidosEntregados > MaxPedidosEntregados)
                {
                    CadeteMasEntregas = cadete;
                    MaxPedidosEntregados = cantPedidosEntregados;
                }
            }

            return CadeteMasEntregas;
        }


    }
}
