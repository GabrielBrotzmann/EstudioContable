﻿using EstudioContable.AccesoDatos.Utilidades;
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
    public class EmpleadoDatos
    {


        public List<Empleado> TraerTodos()
        {
            string json2 = WebHelper.Get("EstudioContable/Empleados");
            List<Empleado> resultado = MapList(json2);
            return resultado;
        }

        public List<Empleado> Traer(int usuario)
        {
            string json2 = WebHelper.Get("EstudioContable/Empleados" + usuario.ToString()); // trae un texto en formato json de una web
            List<Empleado> resultado = MapList(json2);
            return resultado;
        }

      

        private List<Empleado> MapList(string json)
        {
            List<Empleado> lst = JsonConvert.DeserializeObject<List<Empleado>>(json); // deserializacion
            return lst;
        }

        

        private Empleado MapObj(string json)
        {
            Empleado lst = JsonConvert.DeserializeObject<Empleado>(json); // deserializacion
            return lst;
        }

        public TransactionResult Insertar(Empleado empleado)
        {
            NameValueCollection obj = ReverseMap(empleado); //serializacion -> json

            string json = WebHelper.Post("EstudioContable/Empleado", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }


        public TransactionResult Actualizar(Empleado empleado)
        {
            NameValueCollection obj = ReverseMap(empleado);

            string json = WebHelper.Put("EstudioContable/Empleado", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        private NameValueCollection ReverseMap(Empleado empleado)
        {
            NameValueCollection n = new NameValueCollection();

            n.Add("idCategoria", empleado.IdCategoria.ToString());
            n.Add("idEmpresa", empleado.IdEmpresa.ToString());
            n.Add("cuil", empleado.Cuil.ToString());
            n.Add("nombre", empleado.Nombre);
            n.Add("apellido", empleado.Apellido);
            n.Add("fechaNacimiento", empleado.FechaNacimiento.ToString());
            n.Add("fechaAlta", empleado.FechaAlta.ToString());
            n.Add("id", empleado.Id.ToString());
            
            Console.WriteLine(n);
            return n;
        }

        
    }
}
