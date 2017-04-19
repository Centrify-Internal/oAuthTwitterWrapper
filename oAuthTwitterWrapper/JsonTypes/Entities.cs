using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OAuthTwitterWrapper.JsonTypes
{

    public class Entities
    {

        [JsonProperty("hashtags")]
		public List<Hashtag> Hashtags { get; set; }

        /// <summary>
        /// This needs to use a class similar to Hashtag...
        /// https://dev.twitter.com/overview/api/entities-in-twitter-objects
        /// </summary>
        [JsonProperty("symbols")]
		public List<Symbol> Symbols { get; set; }

        [JsonProperty("urls")]
		public List<Url> Urls { get; set; }

        [JsonProperty("user_mentions")]
        public List<UserMention> UserMentions { get; set; }

        [JsonProperty("media")]
        public List<Media> Media { get; set; }
    }

}
