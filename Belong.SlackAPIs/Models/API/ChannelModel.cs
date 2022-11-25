using System.Collections.Generic;

namespace Belong.SlackAPIs.Models.API
{
    public class Channel
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool is_channel { get; set; }
        public bool is_group { get; set; }
        public bool is_im { get; set; }
        public bool is_mpim { get; set; }
        public bool is_private { get; set; }
        public int created { get; set; }
        public bool is_archived { get; set; }
        public bool is_general { get; set; }
        public int unlinked { get; set; }
        public string name_normalized { get; set; }
        public bool is_shared { get; set; }
        public bool is_org_shared { get; set; }
        public bool is_pending_ext_shared { get; set; }
        public List<object> pending_shared { get; set; }
        public string context_team_id { get; set; }
        public object updated { get; set; }
        public object parent_conversation { get; set; }
        public string creator { get; set; }
        public bool is_ext_shared { get; set; }
        public List<string> shared_team_ids { get; set; }
        public List<object> pending_connected_team_ids { get; set; }
        public bool is_member { get; set; }
        public Topic topic { get; set; }
        public Purpose purpose { get; set; }
        public List<object> previous_names { get; set; }
        public int num_members { get; set; }
    }

    public class Purpose
    {
        public string value { get; set; }
        public string creator { get; set; }
        public int last_set { get; set; }
    }

    public class ResponseMetadata
    {
        public string next_cursor { get; set; }
    }

    public class ChannelModel
    {
        public bool ok { get; set; }
        public List<Channel> channels { get; set; }
        public ResponseMetadata response_metadata { get; set; }
    }

    public class Topic
    {
        public string value { get; set; }
        public string creator { get; set; }
        public int last_set { get; set; }
    }

}
