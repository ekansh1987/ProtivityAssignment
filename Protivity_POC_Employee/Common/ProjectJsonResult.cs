namespace Protivity_POC_Employee.Common
{
    public class ProjectJsonResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public object Result { get; set; }
    }
}
