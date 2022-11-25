using System.Collections.Generic;

namespace Belong.SlackAPIs.Models.API
{
    public class ChannelMessagesModel
    {
        public bool ok { get; set; }
        public List<Message> messages { get; set; }
        public bool has_more { get; set; }
        public int pin_count { get; set; }
        public object channel_actions_ts { get; set; }
        public int channel_actions_count { get; set; }
    }
    public class Block
    {
        public string type { get; set; }
        public string block_id { get; set; }
        public List<Element> elements { get; set; }
    }

    public class BotProfile
    {
        public string id { get; set; }
        public bool deleted { get; set; }
        public string name { get; set; }
        public int updated { get; set; }
        public string app_id { get; set; }
        public Icons icons { get; set; }
        public string team_id { get; set; }
    }

    public class Element
    {
        public string type { get; set; }
        public List<Element> elements { get; set; }
        public string text { get; set; }
    }

    public class Icons
    {
        public string image_36 { get; set; }
        public string image_48 { get; set; }
        public string image_72 { get; set; }
    }

    public class Message
    {
        public string type { get; set; }
        public string subtype { get; set; }
        public string text { get; set; }
        public string user { get; set; }
        public string bot_id { get; set; }
        public string bot_link { get; set; }
        public string ts { get; set; }
        public string username { get; set; }
        public string app_id { get; set; }
        public List<Block> blocks { get; set; }
        public string team { get; set; }
        public BotProfile bot_profile { get; set; }
        public string client_msg_id { get; set; }
    }


}
