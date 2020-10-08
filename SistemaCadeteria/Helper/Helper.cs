using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaCadeteria
{
    static class Helper
    {
        static Random aleat = new Random();
        //PARA VALORES ALEATORIOS CADETE
        static string[] NombresCadetes = { "Cecilia", "Lautaro", "Gabriel", "Javier", "Sofia", "Gerardo", "Gonzalo", "Camilo", "Martin", "Nadia" };
        static string[] DireccionesCadetes = { "Av Alem 90", "Lamadrid 51", "San Martin 58", "Av. Soldati 85", "Mendoza 45", "San Juan 75", "Av Avellaneda 50", "Av America 58", "Ayacucho 26", "Av Salta 97" };
        static string[] TelefonosCadetes = { "3817020356", "3817434439", "3813022745", "3814893804", "3812423882", "3813397144", "3815367815", "3811212862", "3819710230", "3818225830" };

        //PARA VALORES ALEATORIOS CLIENTE
        static string[] NombresClientes = { "Fernando", "Lucia", "Juan", "Armando", "Selena", "Jose", "Lucia", "Nahuel", "Mariana", "Nicolas" };
        static string[] DireccionesClientes = { "Av Roca 990", "Gral Paz 589", "25 de Mayo 89", "Buenos Aires 1282", "Laprida 150", "Cordoba 785", "Santiago 850", "Bernabe Araoz 584", "Av. Mitre 587", "Pje Padilla 897" };
        static string[] TelefonosClientes = { "3817020356", "3817434439", "3813022745", "3814893804", "3812423882", "3813397144", "3815367815", "3811212862", "3819710230", "3818225830" };

        //PARA VALORES ALEATORIOS PEDIDO
        static string[] Observaciones = { "Forma de pago: Tarjeta", "Comida caliente", "Sabores: Frutilla y Vainilla", "Sin aceitunas" };

        //Informe de Entregas realizadas por Cadete
        public static void GenerarInforme(Cadeteria nCadeteria)
        {
            InformeCadetes(nCadeteria.ListadoCadetes);

            //DETERMINAR CANTIDAD DE PEDIDOS ENTREGADOS
            Console.WriteLine("El cadete con mas entregas realizadas es: ");
            Cadete cadeteMasEntregasRealizadas = nCadeteria.CadeteMasEntregas();
            MostrarDatosCadete(cadeteMasEntregasRealizadas);

            Console.WriteLine("El promedio de sus entregas es: " + cadeteMasEntregasRealizadas.PromedioEntregasRealizadas());

        }

        public static void InformeCadetes(List<Cadete> listadoCadetes)
        {
            Console.WriteLine("Cadetes:");
            foreach (Cadete cadete in listadoCadetes)
            {
                InformeCadete(cadete);
            }
        }


        public static Cadeteria GenerarCadeteria()
        {
            Cadeteria nCadeteria = new Cadeteria();
            Random aleat = new Random();

            nCadeteria.Nombre = "Cadeteria Rapida";
            nCadeteria.ListadoCadetes = GenerarListadoCadetes();

            return nCadeteria;
        }

        /// <summary>
        /// Genera Cadete de valores aleatorios ID, Nombre, Direccion, Telefono, Listado de Pedidos Vacio
        /// </summary>
        public static Cadete GenerarCadete()
        {
            Cadete nCadete = new Cadete();
            Random aleat = new Random();

            nCadete.ID = aleat.Next(550);
            nCadete.Nombre = NombresCadetes[aleat.Next(NombresCadetes.Length)];
            nCadete.Direccion = DireccionesCadetes[aleat.Next(DireccionesCadetes.Length)];
            nCadete.Telefono = TelefonosCadetes[aleat.Next(TelefonosCadetes.Length)];

            return nCadete;
        }

        public static Cliente GenerarCliente()
        {
            Cliente nCliente = new Cliente();
            Random aleat = new Random();

            nCliente.ID = aleat.Next(550);
            nCliente.Nombre = NombresClientes[aleat.Next(NombresClientes.Length + 1)];
            nCliente.Direccion = DireccionesClientes[aleat.Next(DireccionesClientes.Length + 1)];
            nCliente.Telefono = TelefonosClientes[aleat.Next(TelefonosClientes.Length + 1)];

            return nCliente;        //Retorna la referencia de nCliente
        }

        public static Pedido GenerarPedido()
        {
            Pedido nPedido = new Pedido();
            Random aleat = new Random();

            nPedido.NumeroCliente = aleat.Next(550);
            nPedido.Observacion = Observaciones[aleat.Next(Observaciones.Length)];
            nPedido.Estado = false;
            nPedido.PCliente = GenerarCliente();             //Consulta: estaria bien generar un cliente sin un new?

            return nPedido;
        }


        //Consulta: Hay algo que no se puede hacer cuando declaro una clase o metodo como static
        /// <summary>
        /// Genera Listado de Pedidos con sus respectivos valores aleatorios 
        /// </summary>
        /// <param name="cantPedidos"></param>
        /// <returns></returns>
        public static List<Pedido> GenerarListadoPedidos()
        {
            Pedido nPedido;
            List<Pedido> nListaPedidos = new List<Pedido>();
            Console.WriteLine("Cantidad de Cadetes a Registrar");
            int cantPed = Convert.ToInt32(Console.ReadKey());

            for (int i = 0; i < cantPed; i++)
            {
                nPedido = GenerarPedido();
                nListaPedidos.Add(nPedido);
            }
            return nListaPedidos;
        }
        /// <summary>
        /// Genera Listado de Cadetedes con sus respectivos valores aleatorios ID, Nombre, Direccion, Telefono, Listado de Pedidos Vacio
        /// </summary>
        /// <returns>void</returns>
        public static List<Cadete> GenerarListadoCadetes()
        {
            Cadete nCadete;
            List<Cadete> listado = new List<Cadete>();
            Console.WriteLine("Cantidad de Cadetes a Registrar");
            int cantCad = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < cantCad; i++)
            {
                nCadete = GenerarCadete();

                listado.Add(nCadete);
            }

            return listado;
        }

        /// <summary>
        /// Determina si el Pedido fue entregado o no
        /// </summary>
        /// <returns>Lista completa con los valores que ya tenia y su Estado de entrega que se detemrino en esta funcion</returns>
        public static List<Pedido> DeterminarEntregaPedidos(List<Pedido> listadoPedidos)
        {
            foreach (Pedido _pedido in listadoPedidos)
            {
                if (aleat.Next(2) == 1)
                {
                    _pedido.Estado = true;
                }
                else
                {
                    _pedido.Estado = false;
                }
            }

            return listadoPedidos;
        }


        public static void MostrarDatosPedido(Pedido nPedido)
        {
            Console.WriteLine("Datos del Pedido: ");

            Console.WriteLine("Numero de Cliente: " + nPedido.NumeroCliente);
            Console.WriteLine("Observacion del Pedido: " + nPedido.Observacion);
            Console.WriteLine("Estado: " + nPedido.Estado);
            Console.WriteLine("Cliente que realizo el pedido: ");
            MostrarDatosCliente(nPedido.PCliente);
        }
        public static void MostrarDatosCliente(Cliente nCliente)
        {
            Console.WriteLine("Datos del Cliente: ");
            Console.WriteLine("ID: " + nCliente.ID);
            Console.WriteLine("Nombre: " + nCliente.Nombre);
            Console.WriteLine("Direccion" + nCliente.Direccion);
            Console.WriteLine("Telefono " + nCliente.Telefono);
        }
        public static void MostrarDatosCadete(Cadete nCadete)
        {
            Console.WriteLine("Datos del Cadete: ");
            Console.WriteLine("ID: " + nCadete.ID);
            Console.WriteLine("Nombre: " + nCadete.Nombre);
            Console.WriteLine("Direccion: " + nCadete.Direccion);
            Console.WriteLine("Telefono: " + nCadete.Telefono);
        }


        public static void InformeCadete(Cadete cadete)
        {
            Console.WriteLine("Nombre: " + cadete.Nombre);
            Console.WriteLine("Cantidad de Pedidos Entregados: " + cadete.DeterminarCantidadPedidosEntregados());
            Console.WriteLine("Paga jornal: " + cadete.DeterminarPago());
        }

    }
}
