using Domain.Interfaces;
using Domain.Models;

namespace Domain.ConstructorRequirements
{
    public class CarConstructorRequirement : IConstuctorRequirement
    {
        private CarConstructorRequirement(Car car, bool isSuccess, string errorMessage) { }
        public CarConstructorRequirement(Car car) : this(car, true, "") {}
        public CarConstructorRequirement(string errorMessage) : this(null, false, errorMessage) { }
    }
}
