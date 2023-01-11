using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace razorApp.Pages
{
    public class RegistraionConfirmation : PageModel
    {
        private readonly ILogger<RegistraionConfirmation> _logger;

        public RegistraionConfirmation(ILogger<RegistraionConfirmation> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}