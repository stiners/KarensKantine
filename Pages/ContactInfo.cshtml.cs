using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IBAS_kantine.Pages
{
    public class ContactInfoModel : PageModel
    {
        private readonly ILogger<ContactInfoModel> _logger;

        public ContactInfoModel(ILogger<ContactInfoModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
