using System.Net.Http.Headers;

var client = new HttpClient();

Console.WriteLine("Bei welchem Satz wollen Sie die Sprache herausfinden?");
var user_text = Console.ReadLine();


String user_text_as_json = "[\r\n    {\r\n        \"Text\": \"" + user_text + "\"\r\n    }\r\n]";




var request = new HttpRequestMessage
{
    Method = HttpMethod.Post,
    RequestUri = new Uri("https://microsoft-translator-text.p.rapidapi.com/BreakSentence?api-version=3.0"),
    Headers =
    {
        { "X-RapidAPI-Key", "225a9a49d5mshe648386092c5c3bp1eee05jsnd3e5d4cc0303" },
        { "X-RapidAPI-Host", "microsoft-translator-text.p.rapidapi.com" },
    },



    Content = new StringContent(user_text_as_json)
    {
        Headers =
        {
            ContentType = new MediaTypeHeaderValue("application/json")
        }
    }
};




using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    Console.WriteLine(body);
}