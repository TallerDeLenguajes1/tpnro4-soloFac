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

        string[] Observaciones = { "Forma de pago: Tarjeta", "Comida caliente", "Sabores: Frutilla y Vainilla", "Sin aceitunas"};


        //CONSTRUCTOR POR DEFECTO
        public Pedido()
        {
            //Composicion
            PCliente = new Cliente();                   //???? Consulta
            //PCliente = Cliente.GenerarCliente();
        }

        //CONSTRUCTOR PEDIDO
        public Pedido(float NumeroCliente, string Observacion, bool Estado)
        {
            this.NumeroCliente = NumeroCliente;
            this.Observacion = Observacion;
            this.Estado = Estado;   //Deberia inicializarlo en false?
            //Composicion
            this.PCliente = new Cliente();  //Consulta
            this.PCliente.GenerarPersona();
        }

        public string DatosPedido()
        {
            return (this.NumeroCliente + " " + this.Observacion + " " + this.Estado);
        }

        public string DatosClienteRealizaPedido()
        {
            return (this.pCliente.DatosCliente());
        }

        public void GenerarPedido()
        {
            Random aleat = new Random();

            this.NumeroCliente = aleat.Next(550);
            this.Observacion = Observaciones[aleat.Next(Observaciones.Length)];
            this.Estado = false;
            //this.PCliente = Cliente.GenerarCliente();
            this.PCliente.GenerarPersona();             //Consulta: estaria bien generar un cliente sin un new?
        }

        public void MostrarDatosPedido()
        {
            //string[] Datos = this.DatosPedido().Split(" ");
            Console.WriteLine("Datos del Pedido: ");    //Si lo quisiese hacer en la clase Helper como Resolveria para que dependiendo de
                                                        //si es un Pedido, Cliente o Cadete muestre por Consola los mismos.
            Console.WriteLine("Numero de Cliente: " + this.NumeroCliente);
            Console.WriteLine("Observacion del Pedido: " + this.Observacion);
            Console.WriteLine("Estado: " + this.Estado);
            Console.WriteLine("Cliente que realizo el pedido: ");
            this.PCliente.MostrarDatosCliente();

            //foreach (string datos in Datos)
            //{
            //    //Puede no tener observacion el pedido
            //    if (datos!=null)                                //TRY CATCH????
            //    {
            //        Console.WriteLine(datos);
            //    }
            //}
        }
    }
}
