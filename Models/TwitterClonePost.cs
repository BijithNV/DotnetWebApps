using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterClone.Models
{
    public class TwitterClonePost
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTimeOffset PostTime { get; set; }
        public TwitterCloneUser User { get; set; }
    }
}
