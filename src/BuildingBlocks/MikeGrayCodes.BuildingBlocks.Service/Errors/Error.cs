using System.Collections.Generic;

namespace MikeGrayCodes.BuildingBlocks.Service.Errors
{
    public class Error
    {
        public string Message { get; set; }
        public IEnumerable<ErrorDetail> Details { get; set; }
    }
}
