using frontend;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly EmployeeController _apiService;

    public IndexModel(EmployeeController apiService)
    {
        _apiService = apiService;
    }

    public List<Customer> Customers { get; set; }

    public async Task OnGetAsync()
    {
        Customers = await _apiService.GetCustomersAsync();
    }
}
