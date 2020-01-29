using Domain.Interfaces;
using Domain.Models;

namespace Domain.Responses
{
    public class CarResponse : IResponse<Car>
    {
        public Car Object { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        private CarResponse(Car car, bool isSuccess, string errorMessage)
        {
            Object = car;
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }

        public CarResponse(Car car) : this(car, true, "") { }
        public CarResponse(string errorMessage) : this(null, false, errorMessage) { }
    }
}
