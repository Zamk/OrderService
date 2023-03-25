using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Telegram.Bot.Runner.Models;
using OrderService.Telegram.Bot.Runner.Interfaces;

namespace OrderService.Telegram.Bot.Runner.Repositories
{
    public class InMemoryWebhookRepository : IWebhookReposutiry
    {
        private readonly List<Webhook> _webhooks;

        public InMemoryWebhookRepository()
        {
            this._webhooks = new List<Webhook>();
        }

        public InMemoryWebhookRepository(List<Webhook> webhooks)
        {
            this._webhooks = webhooks;
        }

        public bool Add(Webhook webhook)
        {
            try
            {
                _webhooks.Add(webhook);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                var item = _webhooks.FirstOrDefault(w => w.Id == id);
                _webhooks.Remove(item);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
