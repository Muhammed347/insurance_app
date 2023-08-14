namespace deneme1.Models
{
    public class Policy
    {
        public int ProductId { get; set; }//fk for product class
        public int PersonId { get; set; }//fk for Person class
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public double? Prim { get; set; }
    }
}
