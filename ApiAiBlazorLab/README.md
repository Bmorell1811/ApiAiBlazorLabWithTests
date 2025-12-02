# API AI Blazor Lab

A Blazor Server application demonstrating API integration, AI services, and secure API key management.

## Features

✔ **CatFactService** - Fetches random cat facts from a public API  
✔ **AiService** - Integrates with OpenAI's GPT API  
✔ **Two Interactive Pages** - Cat Facts and AI Chat  
✔ **Secure API Key Management** - Using appsettings.json and User Secrets  
✔ **Minimal API Endpoint** - `/hello` endpoint demonstration

## Setup Instructions

### 1. Configure OpenAI API Key

**Option A: Using appsettings.json (for testing only)**
- Open `appsettings.json`
- Replace `YOUR_KEY_HERE` with your actual OpenAI API key
- ⚠️ **NEVER commit this file to GitHub with a real key!**

**Option B: Using User Secrets (recommended)**
1. Right-click the project → **Manage User Secrets**
2. Add your API key:
```json
{
  "OpenAI": {
    "ApiKey": "your-actual-api-key-here"
  }
}
```

### 2. Run the Application

```bash
dotnet run --project ApiAiBlazorLab
```

Or press F5 in Visual Studio.

### 3. Test the Features

- **Cat Facts Page** (`/catfacts`) - Click "Get Cat Fact" to fetch random cat facts
- **AI Chat Page** (`/ai`) - Enter prompts to chat with GPT-4o-mini
- **Minimal API** - Navigate to `/hello` to see the custom endpoint

## Project Structure

```
ApiAiBlazorLab/
├── Models/
│   └── CatFact.cs          # JSON model for cat fact API
├── Services/
│   ├── CatFactService.cs   # Service for fetching cat facts
│   └── AiService.cs        # Service for OpenAI integration
├── Pages/
│   ├── CatFacts.razor      # Cat facts UI page
│   └── AiChat.razor        # AI chat UI page
├── Shared/
│   └── NavMenu.razor       # Navigation menu
└── Program.cs              # Service registration & configuration
```

## Key Concepts Demonstrated

### API Endpoints
- Making GET requests to public APIs
- Making POST requests with authentication headers
- Deserializing JSON responses

### API Key Security
- Storing keys in configuration files
- Using User Secrets for development
- Never exposing keys in client-side code

### Dependency Injection
- Registering services with `AddScoped`
- Injecting HttpClient
- Injecting IConfiguration

### Blazor Components
- `@inject` directive for service injection
- Event handling with `@onclick`
- Conditional rendering with `@if`
- Two-way binding with `@bind`

## Bonus Challenges

1. **Temperature Slider** - Add a slider to control AI response creativity
2. **JSON Output Panel** - Display raw API responses
3. **Multi-message Chat** - Save conversation history in a list
4. **Model Selector** - Add dropdown to choose different GPT models
5. **Custom Minimal API** - Expand the `/hello` endpoint with parameters

## Technologies Used

- .NET 8
- Blazor Server
- System.Net.Http.Json
- OpenAI API
- Cat Facts API (https://catfact.ninja)
