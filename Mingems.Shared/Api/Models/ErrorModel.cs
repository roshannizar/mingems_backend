namespace Mingems.Shared.Api.Models
{
    public class ErrorModel
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string Errors { get; set; }

        public ErrorModel() { }

        public ErrorModel(string message = null, bool succeeded = true)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public ErrorModel(string message)
        {
            Succeeded = false;
            Message = message;
        }
    }
}
