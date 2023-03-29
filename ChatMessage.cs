namespace ChatCMD
{
    public class ChatMessage
    {
        public string Role { get; set; }
        public string Content { get; set; }
        public DateTimeOffset Created { get; set; }

        public ChatMessage(string role, string content)
        {
            Role = role;
            Content = content;
            Created = DateTimeOffset.UtcNow;
        }
    }

}
