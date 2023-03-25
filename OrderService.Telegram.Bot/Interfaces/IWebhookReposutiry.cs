using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Telegram.Bot.Runner.Models;

namespace OrderService.Telegram.Bot.Runner.Interfaces
{
    public interface IWebhookReposutiry
    {
        public bool Add(Webhook webhook);
        public bool Remove(int id);
    }
}
