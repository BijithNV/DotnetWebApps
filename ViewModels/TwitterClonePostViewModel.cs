using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterClone.ViewModels
{
    public class TwitterClonePostViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Message { get; set; }
        public DateTimeOffset PostTime { get; set; }
        public TwitterCloneUserViewModel User { get; set; }
    }
}
