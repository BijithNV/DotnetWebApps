using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace TwitterClone.Models
{
    public class TwitterCloneUser : IdentityUser
    {
        public List<TwitterClonePost> TwitterClonePosts;

        public bool HasProfilePicture { get; set; }
    }
}