using EstudioContable.AccesoDatos.Utilidades;
using EstudioContable.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioContable.AccesoDatos
{
    public class LiquidacionDatos
    {
        public List<Liquidacion> TraerTodos()
        {
            string json2 = WebHelper.Get("EstudioContable/Liquidaciones/");
            List<Liquidacion> resultado = MapList(json2);
            return resultado;
        }

        public Liquidacion TraerPorIdLiquidacion(int id)
        {
            string json2 = WebHelper.Get("EstudioContable/Liquidacion/" + id.ToString());
            Liquidacion resultado = MapObj(json2);
            return resultado;
        }

        private List<Liquidacion> MapList(string json)
        {
            List<Liquidacion> lst = JsonConvert.DeserializeObject<List<Liquidacion>>(json); // deserializacion
            return lst;
        }



        private Liquidacion MapObj(string json)
        {
            Liquidacion lst = JsonConvert.DeserializeObject<Liquidacion>(json); // deserializacion
            return lst;
        }

        public TransactionResult InsertarLiquidacion(Liquidacion liquidacion)
        {
            NameValueCollection obj = ReverseMapLiquidacion(liquidacion); //serializacion -> json

            string json = WebHelper.Post("EstudioContable/Liquidacion", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }


        public TransactionResult Actualizar(Liquidacion liquidacion)
        {
            NameValueCollection obj = ReverseMapLiquidacion(liquidacion);

            string json = WebHelper.Put("EstudioContable/Liquidacion", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        private NameValueCollection ReverseMapLiquidacion(Liquidacion liquidacion)
        {
            NameValueCollection n = new NameValueCollection();

            n.Add("idEmpleado", liquidacion.IdEmpleado.ToString());
            n.Add("periodo", liquidacion.Periodo.ToString());
            n.Add("codigoTransferencia", liquidacion.CodigoTransferencia.ToString());
            n.Add("bruto", liquidacion.Bruto.ToString());
            n.Add("descuentos", liquidacion.Descuentos.ToString());
            n.Add("fechaAlta", liquidacion.FechaAlta.ToString());
            n.Add("id", liquidacion.Id.ToString());

            return n;
        }


    }
}
