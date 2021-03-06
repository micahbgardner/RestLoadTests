﻿using System.Globalization;
using RestCalls.RestRequestObjects;
using RestSharp;

namespace RestCalls.UserRestCalls
{
    public class UserRestCalls : AbstractBaseRestSetup
    {
        public IRestResponse SetupUser(int userId)
        {
            var client = new RestClient("http://dev-mobile-rest.mbodev.me");

            var request = new RestRequest("/rest/user/{id}/setup", Method.POST) {RequestFormat = DataFormat.Json};

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedAccessToken);

            request.AddUrlSegment("id", userId.ToString(CultureInfo.InvariantCulture));

            return client.Execute(request);
        }

        public IRestResponse GetUser(int userId)
        {
            var client = new RestClient("http://dev-mobile-rest.mbodev.me");

            var request = new RestRequest("/rest/user/{id}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedAccessToken);

            request.AddUrlSegment("id", userId.ToString(CultureInfo.InvariantCulture));

            return client.Execute(request);
        }

        public IRestResponse CreateUser(RestRequestUser user)
        {
            var client = new RestClient("http://dev-mobile-rest.mbodev.me");

            var request = new RestRequest("/rest/user", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedAccessToken);

            request.AddBody(
                new
                {
                    username = user.Username,
                    password = user.Password,
                    firstname = user.Firstname,
                    lastname = user.Lastname
                });

            return client.Execute(request);
        }

        public IRestResponse UpdateUser(int userId, RestRequestUserProfile userProfile)
        {
            var client = new RestClient("http://dev-mobile-rest.mbodev.me");

            var request = new RestRequest("/rest/user/{id}", Method.PUT) {RequestFormat = DataFormat.Json};

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer {" + UserAccessToken + "}");

            request.AddUrlSegment("id", userId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(
                new
                {
                    firstname = userProfile.FirstName,
                    lastname = userProfile.LastName,
                    address = userProfile.Address,
                    city = userProfile.City,
                    state = userProfile.State,
                    zip = userProfile.Zip
                });

            return client.Execute(request);
        }
    }
}
