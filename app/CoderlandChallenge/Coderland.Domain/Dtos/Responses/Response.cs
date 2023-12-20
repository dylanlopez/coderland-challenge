namespace Coderland.Domain.Dtos.Responses
{
	public class Response<T>
	{
		public void ResultOk(T value)
		{
			State = 200;
			Message = "Ok";
			Value = value;
		}

		public void ResultError(string error)
		{
			State = 400;
			Message = "Error: " + error;
		}

		public int State { get; set; }
		public string Message { get; set; }
		public T Value { set; get; }
	}
}
