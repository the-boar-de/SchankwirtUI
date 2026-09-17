using Newtonsoft.Json;
public struct jsonstruct
{
    public uint id { get; set; }
    public string info { get; set; }


}


class ApiService(HttpClient http)
{
    public async Task<jsonstruct> GetItemAsync() {
        
        return JsonConvert.DeserializeObject<jsonstruct>(await http.GetStringAsync("item"));
    }
    

    public async Task<string> PutItemAsync(jsonstruct info)
    {
        var json = JsonConvert.SerializeObject(info);
      var response =  await http.PutAsync($"put?info={Uri.EscapeDataString(json)}", null);
      return await response.Content.ReadAsStringAsync();
    }

    
}