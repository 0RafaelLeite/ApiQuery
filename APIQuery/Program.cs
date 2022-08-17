using System.Net;
using System.Text.Json;

using (WebClient wc = new WebClient())
{
    string PrettyJson(string unPrettyJson)
    {
        var options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        var jsonElement = JsonSerializer.Deserialize<JsonElement>(unPrettyJson);

        return JsonSerializer.Serialize(jsonElement, options);
    }

    try
    {
        Console.Write("Digite um cep: ");

        string cep = Console.ReadLine();

        string url = $"https://viacep.com.br/ws/{cep}/json/";

        string json = wc.DownloadString(url);

        Console.WriteLine(PrettyJson(json));
    }
    catch (Exception)
    {
         Console.WriteLine("\nCEP inválido, tente novamente");
        Console.ReadLine();
    }

    

}