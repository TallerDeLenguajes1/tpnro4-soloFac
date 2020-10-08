using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaCadeteria
{
    class Pedido
    {
        private float numeroCliente;
        private string observacion;
        private bool estado;
        private Cliente pCliente;

        public float NumeroCliente { get => numeroCliente; set => numeroCliente = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public bool Estado { get => estado; set => estado = value; }
        internal Cliente PCliente { get => pCliente; set => pCliente = value; }

        


        //CONSTRUCTOR POR DEFECTO
        public Pedido()
        {
            //Composicion
            PCliente = new Cliente();
        }

        //CONSTRUCTOR PEDIDO
        public Pedido(float NumeroCliente, string Observacion, bool Estado)
        {
            this.NumeroCliente = NumeroCliente;
            this.Observacion = Observacion;
            this.Estado = false;
            //Composicion
            this.PCliente = new Cliente();
        }

        public string DatosPedido()
        {
            return (this.NumeroCliente + ";" + this.Observacion + ";" + this.Estado);
        }

        public string DatosClienteRealizaPedido()
        {
            return (this.pCliente.DatosCliente());
        }

    }
}
