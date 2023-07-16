using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class Message
{
    [Key]
    public int MessageId { get; set; }
    public int MessageSenderId { get; set; }
    public int MessageReceiverId { get; set; }
    public string MessageSubject { get; set; }
    public string MessageDetails { get; set; }
    public DateTime MessageDate { get; set; }
    public bool MessageStatus { get; set; }
    public Author SenderUser { get; set; }
    public Author ReceiverUser { get; set; }
}