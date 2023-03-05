namespace DataAccessLayer.DTOs
{
    using System;

    public class BookingDTO
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BookedQuantity { get; set; }
    }
}
