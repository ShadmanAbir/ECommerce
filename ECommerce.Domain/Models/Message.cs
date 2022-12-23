namespace ECommerce.Domain.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public string MessageBody { get; set; }
        public string SenderID { get; set; }
        public string ReceiverID { get; set; }
        public int SellPostID { get; set; }
        public int ParentID { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public SellPost SellPost { get; set; }
    }
}
