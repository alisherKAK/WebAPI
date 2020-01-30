namespace Domain.ConstructorRequirements
{
    public abstract class BaseResponse<TObject> where TObject : class
    {
        public TObject Item { get; protected set; }
        public bool IsSuccess { get; protected set; }
        public string ErrorMessage { get; protected set; }

        protected BaseResponse(TObject item, bool isSuccess, string errorMessage)
        {
            Item = item;
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }

        protected BaseResponse(TObject item)
        {
            Item = item;
        }
        protected BaseResponse(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
