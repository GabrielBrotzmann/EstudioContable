using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioContable.Entidades
{
    public class Liquidacion
    {
        private int _idLiquidacion;
        private int _idEmpleado;
        private int _periodo;
        private string _codigoTransferencia;
        private double _bruto;
        private double _descuento;
        private DateTime _fechaAlta;

        public int idLiquidacion { get => _idLiquidacion; set => _idLiquidacion = value; }
        public int idEmpleado { get => _idEmpleado; set => _idEmpleado = value; }
        public int periodo { get => _periodo; set => _periodo = value; }
        public string codigoTransferencia { get => _codigoTransferencia; set => _codigoTransferencia = value; }
        public double bruto { get => _bruto; set => _bruto = value; }
        public double descuento { get => _descuento; set => _descuento = value;}
        public DateTime fechaAlta { get => _fechaAlta; set => _fechaAlta = value;}
        
    }
}
