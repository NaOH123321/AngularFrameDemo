﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleAngular.App.Helpers;
using Microsoft.AspNetCore.Http;

namespace SampleAngular.App.Messages
{
    public class NotFoundMessage :Message<string>
    {
        public override int Code { get; set; } = StatusCodes.Status404NotFound;
        public override string Msg { get; set; } = "控制器或方法不存在";
        public override int ErrorCode { get; set; } = ErrorCodeStatus.ErrorCode40000;
    }
}
