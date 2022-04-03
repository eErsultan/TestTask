namespace Application.DTOs.Common
{
    public class Response<T>
    {
        public Response()
        {

        }

        public Response(string error)
        {
            Error = error;
        }

        public Response(T data, string error = null)
        {
            Data = data;
            Error = error;
        }

        public string Error { get; set; }
        public T Data { get; set; }
    }
}
