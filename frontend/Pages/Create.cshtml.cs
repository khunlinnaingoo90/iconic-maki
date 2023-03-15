using frontend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CreateModel : PageModel
{
    private readonly EmployeeController _apiService;

    public CreateModel(EmployeeController apiService)
    {
        _apiService = apiService;
    }

    [BindProperty]
    public Customer Customer { get; set; }

    public void OnGet()
    {
        Customer = new Customer();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _apiService.CreateCustomerAsync(Customer);

        return RedirectToPage("/Index");
    }
}
