# ChatCMD
ChatCMD is a simple command-line interface (CLI) application that enables users to interact with OpenAI's GPT-3.5 Turbo model directly from the terminal. It's designed as an alternative to the browser-based chat.openai.com interface, providing a lightweight and straightforward solution to communicate with the AI.

# Features
Leverage the power of OpenAI's GPT-3.5 Turbo model directly from the command line.
Manage multiple chat sessions simultaneously.
Bypass the 25 message limit imposed by the browser-based chat.openai.com.
# Requirements
.NET 5.0 or later
An OpenAI API key with access to the GPT-3.5 Turbo model
# Installation
Clone this repository:

bash
Copy code
git clone https://github.com/your_github_username/ChatCMD.git
Navigate to the project directory:

cd ChatCMD
Build the project:

dotnet build
Update the apiKey variable in the ChatCMD.cs file with your OpenAI API key.

# Usage
Run the application:

arduino
Copy code
dotnet run --project ChatCMD
Follow the on-screen prompts to start a new chat session or manage existing sessions.

Type your messages and press Enter to receive a response from the AI.

To exit the application, type exit or quit.

# Credits
This project is based on an idea and initial implementation provided by OpenAI's ChatGPT.

# License
This project is licensed under the MIT License. See the LICENSE file for details.
