﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.IO;
using Newtonsoft.Json;

namespace TekionClient
{
    public class Connection
    {
        private const String HOST = "tekion.azurewebsites.net";
        private const String DISPLAY_URL_FORMAT = "http://{0}/api/display?username={1}&userToken={2}";
        private const String VOTE_URL_FORMAT = "http://{0}/api/vote?username={1}&userToken={2}&voteCode={3}";

        private String host;
        private String user;
        private String token;

        public Connection(String user, String token)
        {
            this.host = HOST;
            this.user = user;
            this.token = token;
        }

        public async Task<DisplayModel> GetDisplay()
        {
            var url = string.Format(DISPLAY_URL_FORMAT, host, user, token);
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            if (String.IsNullOrEmpty(responseContent))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<DisplayModel>(responseContent);
        }

        public async Task<String> Vote(int code)
        {
            var url = string.Format(VOTE_URL_FORMAT, host, user, token, code);
            var httpClient = new HttpClient();
            return await httpClient.GetStringAsync(url);
        }
    }
}
