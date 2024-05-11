using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GraduateWork.Models;
using Newtonsoft.Json.Linq;

namespace GraduateWork.Services
{
    public interface IMilestonesService
    {
        Task<ErrorResponseDetails> GetMilestonesIncorrectById(string milestoneid);

        Task<Milestones.ResultContainer> GetMilestonesById(string milestoneid);

    }
}
