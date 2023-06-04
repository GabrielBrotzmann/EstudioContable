using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioContable.Entidades
{
    public class Liquidacion
    {
        private int idLiquidacion { get; set; }
        private int idEmpleado { get; }
        private int periodo { get; }
        private string codigoTransferencia { get; }

        public double bruto;

        public double descuento;
        private DateTime fechaAlta { get; }

    }
}
