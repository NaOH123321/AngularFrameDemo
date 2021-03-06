﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleAngular.App.Helpers;
using Microsoft.AspNetCore.Http;

namespace SampleAngular.App.Messages
{
    public class UnprocessableEntityMessage : Message<object>
    {
        public override int Code { get; set; } = StatusCodes.Status422UnprocessableEntity;
        public override object Msg { get; set; }
        public override int ErrorCode { get; set; } = ErrorCodeStatus.ErrorCode40003;
    }
}
