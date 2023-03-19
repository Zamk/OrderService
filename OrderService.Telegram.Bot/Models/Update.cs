using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OrderService.Telegram.Bot.Models
{
    public class Chat
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("first_name")]
        public string FirstName;

        [JsonProperty("last_name")]
        public string LastName;

        [JsonProperty("username")]
        public string Username;

        [JsonProperty("type")]
        public string Type;
    }

    public class From
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("is_bot")]
        public bool IsBot;

        [JsonProperty("first_name")]
        public string FirstName;

        [JsonProperty("last_name")]
        public string LastName;

        [JsonProperty("username")]
        public string Username;

        [JsonProperty("language_code")]
        public string LanguageCode;
    }

    public class Message
    {
        [JsonProperty("message_id")]
        public int MessageId;

        [JsonProperty("from")]
        public From From;

        [JsonProperty("chat")]
        public Chat Chat;

        [JsonProperty("date")]
        public int Date;

        [JsonProperty("text")]
        public string Text;
    }

    public class Update
    {
        [JsonProperty("update_id")]
        public int UpdateId;

        [JsonProperty("message")]
        public Message Message;
    }

}
