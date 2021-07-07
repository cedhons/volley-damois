namespace VolleyDamois.Models.Validators
{
    public struct ValidationError
    {
        public string Message { get; }

        public ValidationError(string message)
        {
            Message = message;
        }
    }
}