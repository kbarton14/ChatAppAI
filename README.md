# 🤖 ChatAppAI

ChatAppAI is a console-based AI chat application built with **.NET** using **Microsoft.Extensions.AI** and the **OpenAI .NET SDK**.
It demonstrates how to securely integrate an AI chat model, maintain conversational context, and stream responses in real time.

---

## ✨ Features

* Interactive console-based chat interface
* Real-time streaming AI responses
* Maintains conversation history across turns
* Secure API key handling using .NET User Secrets
* Configurable model selection
* Asynchronous, non-blocking design

---

## 🛠 Tech Stack

* .NET 8
* C#
* Microsoft.Extensions.AI
* OpenAI .NET SDK
* Microsoft.Extensions.Configuration
* Console Application

---

## 📁 Project Structure

```
ChatAppAI/
├── Program.cs
├── ChatAppAI.csproj
├── Properties/
│   └── launchSettings.json
└── README.md
```

---

## 🚀 Getting Started

### Prerequisites

* .NET 8 SDK or later
* An OpenAI API key
* Visual Studio or the .NET CLI

---

### 🔐 Configure User Secrets

This project uses **User Secrets** to keep sensitive configuration out of source control.

From the project directory, run:

```bash
dotnet user-secrets init
dotnet user-secrets set "OpenAIKey" "YOUR_API_KEY_HERE"
dotnet user-secrets set "ModelName" "gpt-5.2"
```

> Replace the model name with any supported OpenAI chat model available to your account.

---

### ▶ Run the Application

```bash
dotnet run
```

You will be prompted in the console:

```
Your prompt:
```

Type a message and press Enter to receive a streamed AI response.

---

## 🧠 How It Works

1. Configuration is loaded using `Microsoft.Extensions.Configuration`
2. An `IChatClient` is created using the OpenAI SDK
3. A system prompt defines the assistant’s behavior
4. User input is added to the conversation history
5. The AI response is streamed token-by-token to the console
6. The assistant’s response is appended to history for context

---

## 🔒 Security Notes

* API keys are never hard-coded
* Secrets are stored using .NET User Secrets
* No sensitive configuration is committed to source control

Recommended `.gitignore` entries:

```
secrets.json
bin/
obj/
```

---

## 🧩 Future Improvements

* Command handling (`/exit`, `/reset`, `/save`)
* Conversation persistence (JSON or SQLite)
* Context windowing or summarization
* Function calling / tool integration
* Retrieval-Augmented Generation (RAG)
* Configurable model parameters (temperature, token limits)
* Enhanced console UI (colors, multiline input)

---

## 📄 License

This project is licensed under the **MIT License**.

---

## 🙌 Acknowledgements

* Microsoft documentation for Microsoft.Extensions.AI
* OpenAI API and SDKs
