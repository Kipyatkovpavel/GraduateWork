﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GraduateWork.Models
{
    public record ErrorResponseDetails
    {
        [JsonPropertyName("message")] public string Message { get; set; }

        [JsonPropertyName("code")]  public int Code { get; set; }
    }
}
