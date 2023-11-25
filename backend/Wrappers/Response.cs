namespace Backend.Wrappers
{
    public class Response<T>
    {
        public T Data { get; set; } = default!;
        public bool? Succeeded { get; set; }
        public string[] Errors { get; set; } = null!;
        public string? Message { get; set; }

        public Response() { }
        public Response(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null!;
            Data = data;
        }

    }
}
