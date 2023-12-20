namespace Coderland.Domain.Dtos.Responses
{
	public class MarcaAutoByActiveQueryResponse
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string PaisOrigen { get; set; }
		public bool EstaActivo { get; set; }
	}
}
