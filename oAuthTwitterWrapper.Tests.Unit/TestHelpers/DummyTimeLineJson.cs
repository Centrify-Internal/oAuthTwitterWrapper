﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuthTwitterWrapper.Tests.Unit.TestHelpers
{
    public static class DummyTimeLineJson
    {
        public static string GetTimeLineJsonWithPlacePropertySet(string coordinateType = "Point")
        {
            string coordinatesValue = GetCoordinateTestValueFromType(coordinateType, false);

            return "[{\"created_at\":\"Tue Mar 07 16:29:58 +0000 2017\",\"id\":839151144320434176,\"id_str\":\"839151144320434176\",\"text\":\"More Thoughts on Vendor Consolidation in the Security Market https:\\/\\/t.co\\/q8gwYtUwRk\",\"truncated\":false,\"entities\":{\"hashtags\":[],\"symbols\":[],\"user_mentions\":[],\"urls\":[{\"url\":\"https:\\/\\/t.co\\/q8gwYtUwRk\",\"expanded_url\":\"http:\\/\\/blog.centrify.com\\/consolidating-security-vendors\\/\",\"display_url\":\"blog.centrify.com\\/consolidating-\\u2026\",\"indices\":[61,84]}]},\"source\":\"\\u003ca href=\\\"http:\\/\\/twitter.com\\/download\\/android\\\" rel=\\\"nofollow\\\"\\u003eTwitter for Android\\u003c\\/a\\u003e\",\"in_reply_to_status_id\":null,\"in_reply_to_status_id_str\":null,\"in_reply_to_user_id\":null,\"in_reply_to_user_id_str\":null,\"in_reply_to_screen_name\":null,\"user\":{\"id\":32498985,\"id_str\":\"32498985\",\"name\":\"Tom Kemp\",\"screen_name\":\"ThomasRKemp\",\"location\":\"Santa Clara, CA\",\"description\":\"CEO of Centrify, a leading provider of security and identity management solutions for the hybrid cloud.  Tweets are my own.\",\"url\":\"http:\\/\\/t.co\\/pFscklNkHy\",\"entities\":{\"url\":{\"urls\":[{\"url\":\"http:\\/\\/t.co\\/pFscklNkHy\",\"expanded_url\":\"http:\\/\\/www.centrify.com\",\"display_url\":\"centrify.com\",\"indices\":[0,22]}]},\"description\":{\"urls\":[]}},\"protected\":false,\"followers_count\":3089,\"friends_count\":390,\"listed_count\":191,\"created_at\":\"Fri Apr 17 17:55:35 +0000 2009\",\"favourites_count\":1120,\"utc_offset\":-28800,\"time_zone\":\"Pacific Time (US & Canada)\",\"geo_enabled\":true,\"verified\":false,\"statuses_count\":7447,\"lang\":\"en\",\"contributors_enabled\":false,\"is_translator\":false,\"is_translation_enabled\":false,\"profile_background_color\":\"C0DEED\",\"profile_background_image_url\":\"http:\\/\\/abs.twimg.com\\/images\\/themes\\/theme1\\/bg.png\",\"profile_background_image_url_https\":\"https:\\/\\/abs.twimg.com\\/images\\/themes\\/theme1\\/bg.png\",\"profile_background_tile\":false,\"profile_image_url\":\"http:\\/\\/pbs.twimg.com\\/profile_images\\/421375338891853825\\/lUfetOAp_normal.jpeg\",\"profile_image_url_https\":\"https:\\/\\/pbs.twimg.com\\/profile_images\\/421375338891853825\\/lUfetOAp_normal.jpeg\",\"profile_banner_url\":\"https:\\/\\/pbs.twimg.com\\/profile_banners\\/32498985\\/1449788340\",\"profile_link_color\":\"1DA1F2\",\"profile_sidebar_border_color\":\"C0DEED\",\"profile_sidebar_fill_color\":\"DDEEF6\",\"profile_text_color\":\"333333\",\"profile_use_background_image\":true,\"has_extended_profile\":false,\"default_profile\":true,\"default_profile_image\":false,\"following\":null,\"follow_request_sent\":null,\"notifications\":null,\"translator_type\":\"none\"},\"geo\":null,\"coordinates\":null,\"place\":{\"id\":\"3ad0f706b3fa62a8\",\"url\":\"https:\\/\\/api.twitter.com\\/1.1\\/geo\\/id\\/3ad0f706b3fa62a8.json\",\"place_type\":\"city\",\"name\":\"Palo Alto\",\"full_name\":\"Palo Alto, CA\",\"country_code\":\"US\",\"country\":\"United States\",\"contained_within\":[],\"bounding_box\":{\"type\":\"" + coordinateType + "\",\"coordinates\":" + coordinatesValue + "},\"attributes\":{\"street_address\": \"795 Folsom St\",\"623:id\": \"210176\"}},\"contributors\":null,\"is_quote_status\":false,\"retweet_count\":1,\"favorite_count\":0,\"favorited\":false,\"retweeted\":false,\"possibly_sensitive\":false,\"lang\":\"en\"}]";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinateType"></param>
        /// <returns></returns>
        public static string GetTimeLineJsonWithGeoPropertySet(string coordinateType = "Point")
        {
            string coordinatesValue = GetCoordinateTestValueFromType(coordinateType, true);
            

            return "[{\"created_at\":\"Tue Mar 07 16:29:58 +0000 2017\",\"id\":839151144320434176,\"id_str\":\"839151144320434176\",\"text\":\"More Thoughts on Vendor Consolidation in the Security Market https:\\/\\/t.co\\/q8gwYtUwRk\",\"truncated\":false,\"entities\":{\"hashtags\":[],\"symbols\":[],\"user_mentions\":[],\"urls\":[{\"url\":\"https:\\/\\/t.co\\/q8gwYtUwRk\",\"expanded_url\":\"http:\\/\\/blog.centrify.com\\/consolidating-security-vendors\\/\",\"display_url\":\"blog.centrify.com\\/consolidating-\\u2026\",\"indices\":[61,84]}]},\"source\":\"\\u003ca href=\\\"http:\\/\\/twitter.com\\/download\\/android\\\" rel=\\\"nofollow\\\"\\u003eTwitter for Android\\u003c\\/a\\u003e\",\"in_reply_to_status_id\":null,\"in_reply_to_status_id_str\":null,\"in_reply_to_user_id\":null,\"in_reply_to_user_id_str\":null,\"in_reply_to_screen_name\":null,\"user\":{\"id\":32498985,\"id_str\":\"32498985\",\"name\":\"Tom Kemp\",\"screen_name\":\"ThomasRKemp\",\"location\":\"Santa Clara, CA\",\"description\":\"CEO of Centrify, a leading provider of security and identity management solutions for the hybrid cloud.  Tweets are my own.\",\"url\":\"http:\\/\\/t.co\\/pFscklNkHy\",\"entities\":{\"url\":{\"urls\":[{\"url\":\"http:\\/\\/t.co\\/pFscklNkHy\",\"expanded_url\":\"http:\\/\\/www.centrify.com\",\"display_url\":\"centrify.com\",\"indices\":[0,22]}]},\"description\":{\"urls\":[]}},\"protected\":false,\"followers_count\":3089,\"friends_count\":390,\"listed_count\":191,\"created_at\":\"Fri Apr 17 17:55:35 +0000 2009\",\"favourites_count\":1120,\"utc_offset\":-28800,\"time_zone\":\"Pacific Time (US & Canada)\",\"geo_enabled\":true,\"verified\":false,\"statuses_count\":7447,\"lang\":\"en\",\"contributors_enabled\":false,\"is_translator\":false,\"is_translation_enabled\":false,\"profile_background_color\":\"C0DEED\",\"profile_background_image_url\":\"http:\\/\\/abs.twimg.com\\/images\\/themes\\/theme1\\/bg.png\",\"profile_background_image_url_https\":\"https:\\/\\/abs.twimg.com\\/images\\/themes\\/theme1\\/bg.png\",\"profile_background_tile\":false,\"profile_image_url\":\"http:\\/\\/pbs.twimg.com\\/profile_images\\/421375338891853825\\/lUfetOAp_normal.jpeg\",\"profile_image_url_https\":\"https:\\/\\/pbs.twimg.com\\/profile_images\\/421375338891853825\\/lUfetOAp_normal.jpeg\",\"profile_banner_url\":\"https:\\/\\/pbs.twimg.com\\/profile_banners\\/32498985\\/1449788340\",\"profile_link_color\":\"1DA1F2\",\"profile_sidebar_border_color\":\"C0DEED\",\"profile_sidebar_fill_color\":\"DDEEF6\",\"profile_text_color\":\"333333\",\"profile_use_background_image\":true,\"has_extended_profile\":false,\"default_profile\":true,\"default_profile_image\":false,\"following\":null,\"follow_request_sent\":null,\"notifications\":null,\"translator_type\":\"none\"},\"geo\":{ \"type\":\"" + coordinateType + "\", \"coordinates\":" + coordinatesValue + "},\"coordinates\":null,\"place\":null,\"contributors\":null,\"is_quote_status\":false,\"retweet_count\":1,\"favorite_count\":0,\"favorited\":false,\"retweeted\":false,\"possibly_sensitive\":false,\"lang\":\"en\"}]";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetTimeLineJsonWithCoordinatesPropertySet(string coordinateType = "Point")
        {
            string coordinatesValue = GetCoordinateTestValueFromType(coordinateType, false);


            return "[{\"created_at\":\"Tue Mar 07 16:29:58 +0000 2017\",\"id\":839151144320434176,\"id_str\":\"839151144320434176\",\"text\":\"More Thoughts on Vendor Consolidation in the Security Market https:\\/\\/t.co\\/q8gwYtUwRk\",\"truncated\":false,\"entities\":{\"hashtags\":[],\"symbols\":[],\"user_mentions\":[],\"urls\":[{\"url\":\"https:\\/\\/t.co\\/q8gwYtUwRk\",\"expanded_url\":\"http:\\/\\/blog.centrify.com\\/consolidating-security-vendors\\/\",\"display_url\":\"blog.centrify.com\\/consolidating-\\u2026\",\"indices\":[61,84]}]},\"source\":\"\\u003ca href=\\\"http:\\/\\/twitter.com\\/download\\/android\\\" rel=\\\"nofollow\\\"\\u003eTwitter for Android\\u003c\\/a\\u003e\",\"in_reply_to_status_id\":null,\"in_reply_to_status_id_str\":null,\"in_reply_to_user_id\":null,\"in_reply_to_user_id_str\":null,\"in_reply_to_screen_name\":null,\"user\":{\"id\":32498985,\"id_str\":\"32498985\",\"name\":\"Tom Kemp\",\"screen_name\":\"ThomasRKemp\",\"location\":\"Santa Clara, CA\",\"description\":\"CEO of Centrify, a leading provider of security and identity management solutions for the hybrid cloud.  Tweets are my own.\",\"url\":\"http:\\/\\/t.co\\/pFscklNkHy\",\"entities\":{\"url\":{\"urls\":[{\"url\":\"http:\\/\\/t.co\\/pFscklNkHy\",\"expanded_url\":\"http:\\/\\/www.centrify.com\",\"display_url\":\"centrify.com\",\"indices\":[0,22]}]},\"description\":{\"urls\":[]}},\"protected\":false,\"followers_count\":3089,\"friends_count\":390,\"listed_count\":191,\"created_at\":\"Fri Apr 17 17:55:35 +0000 2009\",\"favourites_count\":1120,\"utc_offset\":-28800,\"time_zone\":\"Pacific Time (US & Canada)\",\"geo_enabled\":true,\"verified\":false,\"statuses_count\":7447,\"lang\":\"en\",\"contributors_enabled\":false,\"is_translator\":false,\"is_translation_enabled\":false,\"profile_background_color\":\"C0DEED\",\"profile_background_image_url\":\"http:\\/\\/abs.twimg.com\\/images\\/themes\\/theme1\\/bg.png\",\"profile_background_image_url_https\":\"https:\\/\\/abs.twimg.com\\/images\\/themes\\/theme1\\/bg.png\",\"profile_background_tile\":false,\"profile_image_url\":\"http:\\/\\/pbs.twimg.com\\/profile_images\\/421375338891853825\\/lUfetOAp_normal.jpeg\",\"profile_image_url_https\":\"https:\\/\\/pbs.twimg.com\\/profile_images\\/421375338891853825\\/lUfetOAp_normal.jpeg\",\"profile_banner_url\":\"https:\\/\\/pbs.twimg.com\\/profile_banners\\/32498985\\/1449788340\",\"profile_link_color\":\"1DA1F2\",\"profile_sidebar_border_color\":\"C0DEED\",\"profile_sidebar_fill_color\":\"DDEEF6\",\"profile_text_color\":\"333333\",\"profile_use_background_image\":true,\"has_extended_profile\":false,\"default_profile\":true,\"default_profile_image\":false,\"following\":null,\"follow_request_sent\":null,\"notifications\":null,\"translator_type\":\"none\"},\"geo\":null,\"coordinates\":{ \"type\":\"" + coordinateType + "\", \"coordinates\":" + coordinatesValue + "},\"place\":null,\"contributors\":null,\"is_quote_status\":false,\"retweet_count\":1,\"favorite_count\":0,\"favorited\":false,\"retweeted\":false,\"possibly_sensitive\":false,\"lang\":\"en\"}]";
        }


        public static string GetCoordinateTestValueFromType(string coordinateType, bool isLegacyFormat)
        {
            string coordinatesValue = "null";

            switch (coordinateType)
            {
                case "Point":
                    coordinatesValue = isLegacyFormat ? "[37.78029, -122.39697]" : "[-122.39697, 37.78029]";
                    break;
                case "LineString":
                    coordinatesValue = isLegacyFormat ? "[[37.78029, -122.39697],[38.78029, -121.39697]]" : "[[-122.39697, 37.78029],[-121.39697, 38.78029]]";
                    break;
                case "Polygon":
                    //coordinatesValue = "[[[37.78029, -122.39697],[38.78029, -121.39697],[39.78029, -120.39697]],[[36.78029, -122.39697],[34.78029, -121.39697],[35.78029, -120.39697]]]";
                    coordinatesValue = isLegacyFormat ? "[[[37.362824,-122.190523],[37.362824,-122.097537],[37.465918,-122.097537],[37.465918,-122.190523]]]" : "[[[-122.190523,37.362824],[-122.097537,37.362824],[-122.097537,37.465918],[-122.190523,37.465918]]]";
                    break;
                default:
                    break;
            }

            return coordinatesValue;
        }
    }
}
