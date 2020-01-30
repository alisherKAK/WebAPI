using Domain.ConstructorRequirements;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Responses
{
    public class CarResponse : BaseResponse<Car>
    {
        private CarResponse(Car car, bool isSuccess, string errorMessage) : base(car, isSuccess, errorMessage)
        {
        }

        //public CarResponse(Car car) : this(car, true, "") { }
        //public CarResponse(string errorMessage) : this(null, false, errorMessage) { }
    }
}
