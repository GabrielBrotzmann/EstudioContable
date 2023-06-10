using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;
using EstudioContable.AccesoDatos.Utilidades;
using EstudioContable.Entidades;

namespace EstudioContable.AccesoDatos
{
    public class CategoriaDatos
    {
        public List<Categoria> TraerTodos()
        {
            string json2 = WebHelper.Get("EstudioContable.Consola/Categorias");
            List<Categoria> resultado = MapList(json2);
            return resultado;
        }

        public Categoria TraerPorIdCategoria(int id)
        {
            string json2 = WebHelper.Get("EstudioContable.Consola/Categoria/" + id.ToString());
            Categoria resultado = MapObj(json2);
            return resultado;
        }

        private List<Categoria> MapList(string json)
        {
            List<Categoria> lst = JsonConvert.DeserializeObject<List<Categoria>>(json); // deserializacion
            return lst;
        }



        private Categoria MapObj(string json)
        {
            Categoria lst = JsonConvert.DeserializeObject<Categoria>(json); // deserializacion
            return lst;
        }

        public void InsertarCategoria(Categoria Categoria)
        {
            NameValueCollection obj = ReverseMapCategoria(Categoria); //serializacion -> json

            string json = WebHelper.Post("EstudioContable.Consola/Categoria", obj);

            TransactionResult transaction = JsonConvert.DeserializeObject<TransactionResult>(json);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }


        public TransactionResult Actualizar(Categoria Categoria)
        {
            NameValueCollection obj = ReverseMapCategoria(Categoria);

            string json = WebHelper.Put("EstudioContable.Consola/Categoria", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        private NameValueCollection ReverseMapCategoria(Categoria categoria)
        {
            NameValueCollection n = new NameValueCollection();

            n.Add("nombre", categoria.Nombre);
            n.Add("convenio", categoria.Convenio.ToString());
            n.Add("SueldoBasico", categoria.SueldoBasico.ToString());
            n.Add("id", categoria.Id.ToString());

            return n;
        }
    }
}
