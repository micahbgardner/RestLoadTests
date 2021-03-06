﻿using System.Globalization;
using RestSharp;

namespace RestCalls.FavoritesRestCalls
{
    public class FavoritesRestCalls : AbstractBaseRestSetup
    {
        public IRestResponse GetFavoriteUserLocations(int userId, int siteId)
        {
            var client = new RestClient("http://dev-mobile-rest.mbodev.me");

            var request = new RestRequest("/rest/user/{id}/favoritelocations", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserAccessToken);
            request.AddHeader("SiteID", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddUrlSegment("id", userId.ToString(CultureInfo.InvariantCulture));

            return client.Execute(request);
        }

        public IRestResponse AddFavoriteLocation(int userId, int siteId, int masterLocationId)
        {
            var client = new RestClient("http://dev-mobile-rest.mbodev.me");

            var request = new RestRequest("/rest/user/{id}/FavoriteLocations", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserAccessToken);
            request.AddHeader("SiteID", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddUrlSegment("id", userId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(new
                {
                    id = masterLocationId.ToString(CultureInfo.InvariantCulture)
                });

            return client.Execute(request);
        }

        public IRestResponse RemoveFavoriteLocation(int userId, int siteId, int masterLocationId)
        {
            var client = new RestClient("http://dev-mobile-rest.mbodev.me");

            var request = new RestRequest("/rest/user/{id}/favoritelocations/{masterLocationId}", Method.DELETE) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserAccessToken);
            request.AddHeader("SiteID", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddUrlSegment("id", userId.ToString(CultureInfo.InvariantCulture));
            request.AddUrlSegment("masterLocationId", masterLocationId.ToString(CultureInfo.InvariantCulture));

            return client.Execute(request);
        }

        public IRestResponse GetClassesFromUserFavoriteLocation(int userId, string startDate, string endDate)
        {
            var client = new RestClient("http://dev-mobile-rest.mbodev.me");

            var request = new RestRequest("/rest/user/{id}/favoritelocations/classes?startrange={startrange}&endrange={endrange}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserAccessToken);

            request.AddUrlSegment("id", userId.ToString(CultureInfo.InvariantCulture));
            request.AddUrlSegment("startrange", startDate);
            request.AddUrlSegment("endrange", endDate);

            return client.Execute(request);
        }
    }
}
