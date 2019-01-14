﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleAngular.App.Helpers;
using Microsoft.AspNetCore.Http;

namespace SampleAngular.App.Messages
{
    public class UnauthorizedMessage : Message<string>
    {
        public override int Code { get; set; } = StatusCodes.Status401Unauthorized;
        public override string Msg { get; set; } = "没有权限";
        public override int ErrorCode { get; set; } = ErrorCodeStatus.ErrorCode40001;
    }
}
