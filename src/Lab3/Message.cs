namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Message
{
   private string? _messageText;

   public string? MessageText
   {
       get
       {
           return _messageText;
       }

       protected set
       {
           ArgumentNullException.ThrowIfNull(value);
           _messageText = value;
       }
   }

   public Message(int id, string textMessage, int importance)
    {
        Id = id;
        MessageText = textMessage;
        _messageText = MessageText;
        ImportanceLevel = importance;
    }

   public int Id { get; }

   public int ImportanceLevel { get; }
}