using WebApiTask.Model;

namespace WebApiTask.Services
{
    public interface ISmsService
    {
       public Message CreateMessage(string name, string text, string phoneNumber, Statuses status);
    
    }
}
