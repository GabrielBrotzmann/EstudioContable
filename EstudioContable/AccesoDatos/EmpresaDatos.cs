using System.Collections.Generic;
using EstudioContable.Entidades;
using Newtonsoft.Json;
using System.Collections.Specialized;
using EstudioContable.AccesoDatos.Utilidades;
using EstudioContable.Utilidades;


namespace EstudioContable.AccesoDatos
{
   public class EmpresaDatos
    {
        //Empresa
        public List<Empresa> TraerTodosEmpresa()
        {
            string json2 = WebHelper.Get("EstudioContable/Empresas");
            List<Empresa> resultado = MapList(json2);
            return resultado;
        }

        public List<Empresa> Traer(int usuario)
        {
            string json2 = WebHelper.Get("EstudioContable/Empresas/" + usuario.ToString()); // trae un texto en formato json de una web
            List<Empresa> resultado = MapList(json2);
            return resultado;
        }


        public List<Empresa> MapList(string json)
        {
            List<Empresa> lst = JsonConvert.DeserializeObject<List<Empresa>>(json); // deserializacion
            return lst;
        }



        public Empresa MapObj(string json)
        {
            Empresa lst = JsonConvert.DeserializeObject<Empresa>(json); // deserializacion
            return lst;
        }

        public Response InsertarEmpresa(Empresa empresa)
        {
            NameValueCollection obj = ReverseMapEmpresa(empresa); //serializacion -> json

            string json = WebHelper.Post("EstudioContable/Empresa", obj);

            Response lst = JsonConvert.DeserializeObject<Response>(json);

            return lst;
        }


        public Response ActualizarEmpresa(Empresa empresa)
        {
            NameValueCollection obj = ReverseMapEmpresa(empresa);

            string json = WebHelper.Put("EstudioContable/Empresa", obj);

            Response lst = JsonConvert.DeserializeObject<Response>(json);

            return lst;
        }

        public NameValueCollection ReverseMapEmpresa(Empresa empresa)
        {
            NameValueCollection n = new NameValueCollection();

            n.Add("RazonSocial", empresa.RazonSocial);
            n.Add("Cuit", empresa.Cuit.ToString());
            n.Add("Domicilio", empresa.Domicilio);
            n.Add("FechaAlta", empresa.FechaAlta.ToString());
            n.Add("Id", empresa.Id.ToString());
            n.Add("Usuario", empresa.Usuario.ToString());

            return n;
        }

    }
}
