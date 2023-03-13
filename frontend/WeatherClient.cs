using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
namespace frontend
{
   public class WeatherClient
   {
      private readonly JsonSerializerOptions options = new JsonSerializerOptions()
      {
         PropertyNameCaseInsensitive = true,
         PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      };

      private readonly HttpClient client;

      public WeatherClient(HttpClient client)
      {
         this.client = client;
      }

      public async Task<EmployeeModels[]> GetEmployeesAsync()
      {
         var responseMessage = await this.client.GetAsync("/api/students");
         var stream = await responseMessage.Content.ReadAsStreamAsync();
         return await JsonSerializer.DeserializeAsync<EmployeeModels[]>(stream, options);
      }
   }
}