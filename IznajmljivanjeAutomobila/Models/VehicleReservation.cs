using System.ComponentModel.DataAnnotations;

public class VehicleReservation
{
    [Key]
    public int ReservationId { get; set; }
    public string CustomerName { get; set; }
    public string VehicleType { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime PickupDate { get; set; }
    public DateTime ReturnDate { get; set; }

    [Required] // Dodano za obavezno polje
    public string PickupLocation { get; set; }

    [Required] // Dodano za obavezno polje
    public string ReturnLocation { get; set; }

    public bool IsConfirmed { get; set; }

    public VehicleReservation()
    {
        ReservationDate = DateTime.Now;
        IsConfirmed = false;
    }
}
