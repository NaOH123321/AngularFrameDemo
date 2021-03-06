﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleAngular.App.Helpers;
using Microsoft.AspNetCore.Http;

namespace SampleAngular.App.Messages
{
    public class UnsupportedMediaTypeMessage :Message<string>
    {
        public override int Code { get; set; } = StatusCodes.Status415UnsupportedMediaType;
        public override string Msg { get; set; } = "不支持的MediaType";
        public override int ErrorCode { get; set; } = ErrorCodeStatus.ErrorCode40002;
    }
}
