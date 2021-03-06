﻿using System.Globalization;
using RestSharp;

namespace RestCalls.VisitHistoryFutureScheduleRestCalls
{
    public class VisitHistoryFutureScheduleRestCalls : AbstractBaseRestSetup
    {
        public IRestResponse GetVisitHistoryFutureSchedule(int userId, string startDate, string endDate)
        {
            var client = new RestClient("http://dev-mobile-rest.mbodev.me");

            var request = new RestRequest("/rest/user/{id}/visits?startrange={startDate}&endrange={endDate}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedAccessToken);

            request.AddUrlSegment("id", userId.ToString(CultureInfo.InvariantCulture));
            request.AddUrlSegment("startDate", startDate);
            request.AddUrlSegment("endDate", endDate);

            return client.Execute(request);
        }
    }
}
