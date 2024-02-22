namespace WebOrderSystem.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long MemberId { get; set; }
        public long ProductId { get; set; }
        public DateTime DateOrder { get; set; }

        public virtual Member Member { get; set; }
        public virtual Product Product { get; set; }
    }
}
