using System;
using System.Collections.Generic;
using EstudioContable.AccesoDatos;
using EstudioContable.Entidades;

namespace EstudioContable.Negocio
{
    public class LiquidacionNegocio
    {
        private readonly LiquidacionDatos _liquidacionDatos;

        public LiquidacionNegocio(LiquidacionDatos liquidacionDatos)
        {
            _liquidacionDatos = liquidacionDatos;
        }

        public List<Liquidacion> GetLiquidaciones()
        {
            List<Liquidacion> list = _liquidacionDatos.TraerTodos();

            return list;
        }

        public Liquidacion GetByIdLiquidacion(int idLiquidacion)
        {
            foreach (var item in GetLiquidaciones())
            {
                if (idLiquidacion == item.Id)
                    return item;
            }

            return null;
        }

        public List<Liquidacion> GetLiquidacionByEmpleado(int idEmpleado)
        {
            List<Liquidacion> liquidacionPorEmpleado = new List<Liquidacion>();
            List<Liquidacion> liquidaciones = _liquidacionDatos.TraerTodos();
            foreach (Liquidacion liquidacion in liquidaciones)
            {
                if (liquidacion.EsDeEmpleado(idEmpleado))
                {
                    liquidacionPorEmpleado.Add(liquidacion);
                }
            }

            return liquidacionPorEmpleado;
        }

        public Liquidacion TraerLiquidacion(Liquidacion liquidacion)
        {
            return _liquidacionDatos.TraerPorIdLiquidacion(liquidacion.Id);
        }

        public void AltaLiquidacion(int idEmpleado, int periodo, string codigoTransferencia, double bruto,
            double descuentos, DateTime fechaAlta, int id)
        {
            Liquidacion liquidacion =
                new Liquidacion(idEmpleado, periodo, codigoTransferencia, bruto, descuentos, fechaAlta, id);

            _liquidacionDatos.InsertarLiquidacion(liquidacion);
        }

        public List<Liquidacion> GetLiquidacionesByEmpleados(List<Empleado> empleados)
        {
            List<Liquidacion> liquidacionesByCategoria = new List<Liquidacion>();
            List<Liquidacion> liquidaciones = GetLiquidaciones();
            {
                foreach (Liquidacion liquidacion in liquidaciones)
                {
                    foreach (Empleado empleado in empleados)
                    {
                        if (liquidacion.EsDeEmpleado(empleado.Id))
                        {
                            liquidacionesByCategoria.Add(liquidacion);
                        }
                    }
                }

                return liquidacionesByCategoria;
            }
        }

        public bool ValidarLiquidacionExistente(int id)
        {
            bool resultado = false;
            List<Liquidacion> listadoLiquidaciones = GetLiquidaciones();

            foreach (Liquidacion liquidacion in listadoLiquidaciones)
            {
                if (liquidacion.Id == id)
                {
                    resultado = true;
                    break;
                }
                else
                {
                    resultado = false;
                }
            }

            return resultado;
        }
    }
}