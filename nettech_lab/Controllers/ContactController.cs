using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using nettech_lab.Models;
using Microsoft.Extensions.Options;


namespace nettech_lab.Controllers {
    public class ContactController : Controller {

        private readonly IOptions<EmailSettings> _emailSettings;

        public ContactController(IOptions<EmailSettings> emailSettings) {
            _emailSettings = emailSettings;
        }

        [HttpGet]
        public IActionResult Index() {
            
            return View();
        }        

        [HttpPost]
        public async Task<IActionResult> Send(ContactFormModel contactFormModel) {
            

            if (ModelState.IsValid) {
                try {
                    EmailService emailService = new EmailService();
                    await emailService.SendEmailAsync(contactFormModel.Email, contactFormModel.Subject, contactFormModel.Message,
                       _emailSettings.Value.myemail, _emailSettings.Value.mypass, int.Parse(_emailSettings.Value.SmtpPort),
                       _emailSettings.Value.SmtpServer);

                    TempData["result"] = "Message sent!";
                    return RedirectToAction("Index");
                }
                catch (Exception e) {
                    TempData["result"] = @"Error ¯\_(ツ)_/¯: " + e.Message;
                }
            }

            return RedirectToAction("Index");
        }    
                
    }
}
