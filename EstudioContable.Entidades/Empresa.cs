using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Empresa
{
	public Empresa()
	{

		private string _razonSocial;
		private int _cuitEmpresa;
		private string _domicilio;
		private DateTime _fechaAltaEmpresa;
		private int _usuario;
		private int _idEmpresa;

		public List<Empleado> empleados;

		public string razonSocial { get => _razonSocial; set => _razonSocial = value; }
		public int cuitEmpresa { get => _cuitEmpresa; set => _cuitEmpresa = value; }
		public string domicilio { get => _domicilio; set => _domicilio = value; }
		public DateTime fechaAltaEmpresa { get => _fechaAltaEmpresa; set => _fechaAltaEmpresa = value; }
		public int usuario { get => _usuario; set => _usuario = value; }
		public int idEmpresa { get => _idEmpresa; set => _idEmpresa = value; }



		public Empresa(string rs, int ce, string dom, DateTime fa, int user, int id, List<Empleado> emp)
			{	
				this.razonSocial = rs;
				this.cuitEmpresa = ce;
				this.domicilio = dom;
				this.usuario = user;
				this.idEmpresa = id;
				this.fechaAltaEmpresa = fa;
				this.empleados = emp;
			}



	}
}
