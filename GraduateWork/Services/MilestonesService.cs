﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GraduateWork.Clients;
using GraduateWork.Models;
using GraduateWork.Helpers.Configuration;

namespace GraduateWork.Services
{
    public class MilestonesService : IMilestonesService, IDisposable
    {
        private readonly RestClientExtended _client;

        public MilestonesService(RestClientExtended client)
        {
            _client = client;
        }

        public Task<ErrorResponseDetails> GetMilestonesIncorrectById(string milestoneid)
        {
            var request = new RestRequest("api/v1/milestones/{milestone_id}")
                .AddUrlSegment("milestone_id", milestoneid);

            return _client.ExecuteAsync<ErrorResponseDetails>(request);
        }



        public Task<Milestones.ResultContainer> GetMilestonesById(string milestoneid)
        {
            var request = new RestRequest("api/v1/milestones/{milestone_id}")
                .AddUrlSegment("milestone_id", milestoneid);

            return _client.ExecuteAsync<Milestones.ResultContainer>(request);
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }



    }
}