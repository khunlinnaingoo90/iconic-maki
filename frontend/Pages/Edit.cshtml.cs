using frontend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class EditModel : PageModel
{
    private readonly EmployeeController _apiService;

    public EditModel(EmployeeController apiService)
    {
        _apiService = apiService;
    }

    [BindProperty]
    public Customer Customer { get; set; }
    public async Task OnGetAsync(int id)
    {
        Customer = await _apiService.GetCustomerAsync(id);
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _apiService.UpdateCustomerAsync(id,Customer);
        return RedirectToPage("/Index");
    }
}
