using System.Text;

namespace ChatCMD
{
    internal class ChatCMD
    {
        static async Task Main()
        {
            string apiKey = ApiKeyManager.GetApiKey();

            if (apiKey == null)
            {
                Console.Write("Please enter your OpenAI API key: ");
                apiKey = Console.ReadLine();

                Console.Write("Do you want to save this API key for future use? (y/n): ");
                if (Console.ReadLine().ToLower() == "y")
                {
                    ApiKeyManager.SaveApiKey(apiKey);
                }
            }

            var models = new List<string>
        {
            "gpt-3.5-turbo",
            "gpt-3.5-turbo-0301",
            "text-davinci-003",
            "text-davinci-002",
            "code-davinci-002"
        };

            Console.WriteLine("Please select a model:");
            for (int i = 0; i < models.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {models[i]}");
            }

            int modelIndex;
            while (true)
            {
                Console.Write("Enter the number of your selection: ");
                if (int.TryParse(Console.ReadLine(), out modelIndex) && modelIndex > 0 && modelIndex <= models.Count)
                {
                    break;
                }

                Console.WriteLine("Invalid input. Please try again.");
            }

            string selectedModel = models[modelIndex - 1];

            IApiClient apiClient = new OpenAIApiClient(apiKey);
            ChatSession chatSession = new ChatSession(apiClient, selectedModel);

            Console.WriteLine("Welcome to ChatCMD! Type 'exit' to quit the application.");
            Console.WriteLine("Start typing your message:");

            while (true)
            {
                Console.Write($"[{DateTime.Now:HH:mm:ss}] You: ");
                StringBuilder userInputBuilder = new StringBuilder();

                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        break;
                    }

                    userInputBuilder.Append(keyInfo.KeyChar);
                    Console.Write(keyInfo.KeyChar);
                }

                Console.WriteLine();
                string userInput = userInputBuilder.ToString();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Please enter a valid message.");
                    continue;
                }

                if (userInput.ToLower() == "exit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                // Send user input to chat session and receive a response
                string response = await chatSession.SendMessageAsync(userInput);

                // Display the response with the timestamp and model prefix
                chatSession.DisplayMessage(new ChatMessage("assistant", response));
            }
        }
    }
}