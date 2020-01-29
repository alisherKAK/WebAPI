namespace Domain.Interfaces
{
    public interface IResponse<TObject>
    {
        TObject Object { get; set; }
        bool IsSuccess { get; set; }
        string ErrorMessage { get; set; }
    }
}
