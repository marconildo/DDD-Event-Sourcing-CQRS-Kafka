using System;
using System.Collections.Generic;
using System.Text;

namespace MikeGrayCodes.BuildingBlocks.Service.Errors
{
    public class Error
    {
        public string Message { get; set; }
        public IEnumerable<ErrorDetail> Details { get; set; }
    }
}
