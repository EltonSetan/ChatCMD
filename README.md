# ChatCMD
ChatCMD is a simple command-line interface (CLI) application that enables users to interact with OpenAI's GPT-3.5 Turbo model directly from the terminal. It's designed as an alternative to the browser-based chat.openai.com interface, providing a lightweight and straightforward solution to communicate with the AI.

# Features
Leverage the power of OpenAI's GPT-3.5 Turbo model directly from the command line.
Manage multiple chat sessions simultaneously. (To be implemented)
Bypass the 25 message limit imposed by the browser-based chat.openai.com for ChatGPT version 4. (To be implemented)
# Requirements
.NET 5.0 or later
An OpenAI API key
# Installation
Clone this repository:

git clone https://github.com/your_github_username/ChatCMD.git

Navigate to the project directory:

cd ChatCMD
Build the project:

dotnet build
Update the apiKey variable in the ChatCMD.cs file with your OpenAI API key.

# Usage
Run the application:

dotnet run --project ChatCMD
Follow the on-screen prompts to start a new chat session or manage existing sessions.

Type your messages and press Enter to receive a response from the AI.

To exit the application, type exit.

# Credits
This project is based on my idea and initial implementation provided by OpenAI's ChatGPT version 4.

# License
This project is licensed under the GNU General Public License (GPL) v3. See the LICENSE file for details.
