using Domain.Interfaces;

namespace Domain.Models
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int Сarcase { get; set; }
        public string Color { get; set; }
    }
}
