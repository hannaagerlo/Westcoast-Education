using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace razorApp.Pages.Administration
{
    public class RegistrationConfirmation : PageModel
    {
        private readonly ILogger<RegistrationConfirmation> _logger;

        public RegistrationConfirmation(ILogger<RegistrationConfirmation> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}