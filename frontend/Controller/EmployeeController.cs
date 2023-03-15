using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace frontend
{
    public class EmployeeController
    {
        private readonly HttpClient _httpClient;

        public EmployeeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            var response = await _httpClient.GetAsync("/api/students");
            var content = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<List<Customer>>(content);
            return customers;
        }

        public async Task<Customer> GetCustomerAsync(int id)
         {
             var response = await _httpClient.GetAsync($"/api/students/{id}");
             var content = await response.Content.ReadAsStringAsync();
             var customer = JsonConvert.DeserializeObject<Customer>(content);
             return customer;
         }

         public async Task CreateCustomerAsync(Customer customer)
         {
             var json = JsonConvert.SerializeObject(customer);
             var content = new StringContent(json, Encoding.UTF8, "application/json");
             await _httpClient.PostAsync("/api/students", content);
         }

         public async Task UpdateCustomerAsync(int id,Customer customer)
         {
            Console.WriteLine($"/api/students/{id}");
             var json = JsonConvert.SerializeObject(customer);
             var content = new StringContent(json, Encoding.UTF8, "application/json");
             await _httpClient.PutAsync($"/api/students/{id}", content);
         }

         public async Task DeleteCustomerAsync(int id)
         {
             await _httpClient.DeleteAsync($"/api/students/{id}");
         }
    }

}