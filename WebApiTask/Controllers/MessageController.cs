using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTask.Model;
using WebApiTask.Services;

namespace WebApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private ISmsService smsService { get; set; }
        private ICheckStatusService checkStatusService { get; set; }
        private MessageContext db { get; set; }
        
        public MessageController(MessageContext db , ISmsService _smsService , ICheckStatusService checkStatus)
        {
            this.db = db;
            smsService = _smsService;
            checkStatusService = checkStatus;
            
        }

        [HttpGet]
        public  async Task<ActionResult<IEnumerable<MessageInfo>>> Get()
        {

            return await  db.Messages.Select(mess => new MessageInfo(mess)).ToListAsync();

        }

        [HttpPost]
        public async Task<ActionResult<Message>> Post(MessageInfo messageInfo)
        {   if (messageInfo != null)
            {
                Message message = new Message();
                message = smsService.CreateMessage(messageInfo.Sendername, messageInfo.MessageText, messageInfo.PhoneNumber, checkStatusService.GenerateStatus());
                db.Add(message);
                await db.SaveChangesAsync();
                return Ok(new MessageInfo(message));
            }
            else
            {
                return BadRequest();
            }
        }
            public IActionResult Index()
        {
            return View();
        }
    }
}
