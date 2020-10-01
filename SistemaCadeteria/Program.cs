using System;

namespace ProgramaCadeteria
{
    class Program
    {
        static void Main(string[] args)
        {
            Cadeteria nCadeteria = new Cadeteria();
            nCadeteria.GenerarCadeteria();

            Helper.GenerarInforme(nCadeteria);
        }
    }
}
