namespace TripConsumeApp.Models
{
    public class RefuelingVM
    {
        public int Id { get; set; }
        public DateTime? DateTime { get; set; }
        public double? Amount { get; set; }
        public double? Liters { get; set; }
        public bool FullCharged { get; set; }
        public int? Odometer { get; set; }
        public double? Kilometers { get; set; }
        public double? Liters100Km { get; set; }
        public double? KmPerLiter { get; set; }
        public string? Comments { get; set; }
        public string? VehicleName { get; set; }

        public int VehicleId { get; set; }
    }
}
