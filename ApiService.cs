using Newtonsoft.Json;
public struct Jsonstruct
{
    public uint id { get; set; }
    public string info { get; set; }


}


class ApiService(HttpClient http)
{
    public async Task<Jsonstruct> GetItemAsync() {
        
        return JsonConvert.DeserializeObject<Jsonstruct>(await http.GetStringAsync("item"));
    }
    

    public async Task<string> PutItemAsync(Jsonstruct info)
    {
        var json = JsonConvert.SerializeObject(info);
      var response =  await http.PutAsync($"put?info={Uri.EscapeDataString(json)}", null);
      return await response.Content.ReadAsStringAsync();
    }

    
}