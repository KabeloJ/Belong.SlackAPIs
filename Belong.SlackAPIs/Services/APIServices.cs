using Belong.SlackAPIs.Models.API;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Belong.SlackAPIs.Services
{
    public class APIServices
    {
        private readonly IConfiguration _config;
        private string BaseURL { get; set; }
        private string BotToken { get; set; }
        private string UserToken { get; set; }
        public APIServices(IConfiguration config) 
        { 
            _config = config;
            var slack = _config.GetSection("SlackApis");
            BaseURL = slack.GetSection(nameof(BaseURL)).Value;
            BotToken = slack.GetSection(nameof(BotToken)).Value;
            UserToken = slack.GetSection(nameof(UserToken)).Value;
        }
        public object JoinChannel(string channelId)
        {
            var client = new RestClient(BaseURL);
            var request = new RestRequest("/conversations.join");
            request.Method = Method.Post;
            string jsonBody = "{\"Channel\":\""+channelId+"\"}";
            request.AddBody(jsonBody);
            request.AddHeader("Authorization", $"Bearer {BotToken}");
            var response = client.Execute(request);
            return response;
        }

        public ChannelMessagesModel GetChannelMessages(string channel)
        {

            var client = new RestClient(BaseURL);
            var request = new RestRequest("/conversations.history");
            request.Method = Method.Get;
            request.AddParameter("channel", channel);
            request.AddHeader("Authorization", $"Bearer {BotToken}");
            var response = client.Execute(request);
            try
            {
                return JsonConvert.DeserializeObject<ChannelMessagesModel>(response.Content);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ChannelModel GetChannels()
        {
            var client = new RestClient(BaseURL);
            var request = new RestRequest("/conversations.list");
            request.Method = Method.Get;
            request.AddHeader("Authorization", $"Bearer {BotToken}");
            var response = client.Execute(request);
            try
            {
                return JsonConvert.DeserializeObject<ChannelModel>(response.Content);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
