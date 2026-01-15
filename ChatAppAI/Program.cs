using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;

namespace ChatAppAI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            string model = config["ModelName"];
            string key = config["OpenAIKey"];

            // Create the IChatClient
            IChatClient chatClient =
                new OpenAIClient(key).GetChatClient(model).AsIChatClient();

            // Start the conversation with context for the AI model
            List<ChatMessage> chatHistory =
                [
                    new ChatMessage(ChatRole.System, """
                    You are a helpful, reliable, and concise AI assistant.

                    Your goal is to assist users by providing clear, accurate, and actionable responses. 
                    You explain concepts step-by-step when helpful, adapt your level of detail to the user’s question, 
                    and ask clarifying questions only when necessary.

                    You should:
                    - Be polite, professional, and approachable
                    - Provide examples when they improve understanding
                    - Avoid unnecessary jargon unless the user is technical
                    - Clearly state assumptions when making them
                    - Admit uncertainty and suggest next steps when unsure

                    You should not:
                    - Invent facts or claim certainty when information is incomplete
                    - Provide harmful, unethical, or illegal guidance
                    - Overwhelm the user with unnecessary detail

                    When responding:
                    - Prefer clarity over verbosity
                    - Format answers using lists or short sections when helpful
                    - Stay focused on the user’s intent
                    """)
                ];

            // Loop to get user input and stream AI response
            while (true)
            {
                // Get user prompt and add to chat history
                Console.Write("Your prompt: ");
                string? userPrompt = Console.ReadLine();
                chatHistory.Add(new ChatMessage(ChatRole.User, userPrompt));

                // Stream the AI response and add to chat history
                Console.Write("AI Response: ");
                string response = "";
                await foreach (ChatResponseUpdate item in
                    chatClient.GetStreamingResponseAsync(chatHistory))
                {
                    Console.Write(item.Text);
                    response += item.Text;
                }
                chatHistory.Add(new ChatMessage(ChatRole.Assistant, response));
                Console.WriteLine();
            }
        }
    }
}
