using System;

namespace ProgramaCadeteria
{
    class Program
    {
        static void Main(string[] args)
        {
            Cadeteria nCadeteria = new Cadeteria();
            Helper.GenerarCadeteria(nCadeteria);

            Helper.GenerarInforme(nCadeteria);
        }
    }
}
