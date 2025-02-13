namespace HotelBooking.Domain.Entities;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public decimal CommissionRate { get; set; } 
    public bool IsActive { get; set; } = true; 

    public Hotel(string name, string address, string city, decimal commissionRate)
    {
        Name = name;
        Address = address;
        City = city;
        CommissionRate = commissionRate;
    }
}