using System;

public class Categoria
{
	public Categoria()
	{

		private string _nombreCategoria;
		private string _convenio;
		private double _sueldoBasico;
		private int _idCategoria;
		
		public string nombreCategoria { get => _nombreCategoria; set => _nombreCategoria = value; }
		public string convenio { get => _convenio; set => _convenio = value; }
		public double sueldoBasico { get => _sueldoBasico; set => _sueldoBasico = value; }
		public int idCategoria { get => _idCategoria; set => _idCategoria = value; }

}
}
