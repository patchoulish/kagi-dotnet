# kagi-dotnet [![CI](https://github.com/patchoulish/kagi-dotnet/actions/workflows/ci.yml/badge.svg)](https://github.com/patchoulish/kagi-dotnet/actions/workflows/ci.yml)
A .NET library for interacting with the [Kagi](https://kagi.com/) API.


## Features
- **API Coverage** – Full support for **`v0`** of the **Universal Summarizer**, **FastGPT**, **Search**, and **Enrichment** APIs.
- **.NET Standards Compliant** – Adheres to .NET best practices and conventions.


## Installation
Install the library via [NuGet](https://www.nuget.org/packages/kagi-dotnet):
```bash
dotnet add package kagi-dotnet
```

### Extensions
Install optional library extensions for more functionality, depending on your use case.
#### Dependency Injection
Integrate gravatar-dotnet and your DI container of choice. Install the extension library via [NuGet](https://www.nuget.org/packages/kagi-dotnet-dependencyinjection):
```bash
dotnet add package kagi-dotnet-dependencyinjection
```


## Usage
1. Obtain your API key from the [Kagi API portal](https://kagi.com/settings?p=api) (requires a Kagi account).
2. Pass the API key into a new instance of the `KagiService` class or use a configured `HttpClient` if advanced configuration (e.g., proxies) is required.
3. Use the methods available on `KagiService` to interact with the Kagi API.

### Initialization
The library can be initialized in three ways:
#### Basic Initialization
Pass in your API key directly:
```csharp
var kagi = new KagiService("YOUR_KAGI_API_KEY");
```
#### Advanced Initialization
Use an existing `HttpClient`, ensuring that `BaseAddress` and an `Authorization` header have been set:
```csharp
var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://kagi.com/api/v0/"),
    Timeout = TimeSpan.FromSeconds(5)
};

httpClient.DefaultRequestHeaders.Authorization =
	new AuthenticationHeaderValue("Bot", "YOUR_KAGI_API_KEY");

var kagi = new KagiService(httpClient);
```
#### Dependency Injection
If you've installed the appropriate extension library.
1. Register `KagiService` with your dependency container:
```csharp
services.AddKagiHttpClient(options =>
{
	options.BaseUrl = new Uri("https://kagi.com/api/v0/");
	options.ApiKey = "YOUR_KAGI_API_KEY";
});
```
2. Inject `IKagiService` where needed:
```csharp
public class MyClass
{
    private readonly IKagiService kagi;

    public MyClass(IKagiService kagi)
    {
        this.kagi = kagi;
    }
}
```

### Summarization
The **Universal Summarizer API** uses large language models to generate summaries for various types of content.
```csharp
var summarizeOptions = new KagiSummarizeOptions
{
    // Provide either a URL to summarize...
    Url = new Uri("https://en.wikipedia.org/wiki/Kagi_(search_engine)")

    // ...or raw text content.
    Text = "Kagi is a paid ad-free search engine developed by Kagi Inc..."
};

var summarizeResult = await kagi.SummarizeAsync(summarizeOptions);
	
Console.WriteLine(summarizeResult.Data.Output);
```

### Search-augmented Q&A
The **FastGPT API** combines Kagi’s search engine with language models to answer queries.
```csharp
var answerOptions = new KagiAnswerOptions
{
    Query = "What is the airspeed of a fully-laden swallow?"
};

var answerResult = await kagi.AnswerAsync(answerOptions);

Console.WriteLine(
	$"{answerResult.Data.Output}\n\n" +
	$"References Used: {answerResult.Data.References.Length}");
```

### Search
The **Search API** allows you to access Kagi’s search engine programmatically.
> [!NOTE]
> This API is currently in closed beta for business users.
```csharp
var searchResults = await kagi.SearchAsync("weather today", limit: 20);

foreach (var item in searchResults.Data)
{
    if (item is KagiRecordSearchData record)
    {
        // Item contains a search result (i.e. with a URL, title, optional snippet, etc.)
    }
    else if (item is KagiRelatedQuerySearchData relatedQuery)
    {
        // Item contains a list of related queries
    }
}
```

### Enrichment APIs for Supplemental Content
The **Enrichment API** allows you to access unique web content from Kagi’s specialized indexes, Teclis (for web content) and TinyGem (for news). This API is designed to provide specialized, non-mainstream results and is ideal for enhancing broader search results.

#### Web Enrichment
Retrieve supplemental results focused on high-quality "small web" content.
```csharp
var webEnrichmentResults = await kagi.SearchWebEnrichmentsAsync("coffee blog");

foreach (var item in webEnrichmentResults.Data)
{
    // Processing similar to the Search API output
}
```

#### News Enrichment
Retrieve non-mainstream, high-quality news content relevant to your query.
```csharp
var newsEnrichmentResults = await kagi.SearchNewsEnrichmentsAsync("local news");

foreach (var item in newsEnrichmentResults.Data)
{
    // Processing similar to the Search API output
}
```


## Documentation
Refer to the [Usage](#usage) section above for a quick start, or consult the inline documentation while working in your IDE. For detailed information about the underlying API endpoints, parameters, and expected responses, refer to the [official Kagi API documentation](https://help.kagi.com/kagi/api/overview.html).


## Contributing
Contributions are welcome! To contribute, fork the repository, create a new branch, and submit a pull request with your changes. Please make sure all tests pass before submitting.


## License
This project is licensed under the MIT license. See `license.txt` for full details.
