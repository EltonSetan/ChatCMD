using Newtonsoft.Json.Linq;

namespace ChatCMD
{
    public class ChatSession
    {
        private readonly IApiClient _apiClient;
        private List<ChatMessage> _messages;
        private readonly string _modelName;

        public ChatSession(IApiClient apiClient, string modelName)
        {
            _apiClient = apiClient;
            _messages = new List<ChatMessage>();
            _modelName = modelName;
        }

        public async Task<string> SendMessageAsync(string message)
        {
            // Add user input message to the message list
            var userInputMessage = new ChatMessage("user", message);
            _messages.Add(userInputMessage);

            // Prepare payload for OpenAI API
            var payload = new
            {
                model = _modelName,
                messages = _messages.Select(m => new { role = m.Role, content = m.Content }).ToList()
            };

            // Send the payload and receive the response
            var result = await _apiClient.PostAsync<Dictionary<string, object>>("chat/completions", payload);
            var choices = result["choices"] as JArray;
            var responseText = choices[0]["message"]["content"].ToString();

            // Add GPT-4 response to the message list
            var assistantMessage = new ChatMessage("assistant", responseText);
            _messages.Add(assistantMessage);

            return responseText;
        }

        public void DisplayMessage(ChatMessage message)
        {
            var timestamp = DateTime.Now.ToString("HH:mm:ss");
            var prefix = message.Role == "user" ? "You" : $"{_modelName}";
            Console.WriteLine($"[{timestamp}] {prefix}: {message.Content}");
        }
    }
}
