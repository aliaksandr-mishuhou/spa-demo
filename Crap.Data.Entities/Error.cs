using System;
using Crap.Data.Entities.Common;

namespace Crap.Data.Entities
{
    public class Error : Entity
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime Time { get; set; }
    }
}
