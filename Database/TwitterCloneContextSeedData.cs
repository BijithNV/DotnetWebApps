using TwitterClone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterClone.Database
{
    public class TwitterCloneContextSeedData
    {
        private TwitterCloneContext m_context;
        private UserManager<TwitterCloneUser> m_userManager;

        public TwitterCloneContextSeedData(TwitterCloneContext a_context, UserManager<TwitterCloneUser> a_userManager)
        {
            m_context = a_context;
            m_userManager = a_userManager;
        }

        public async Task EnsureSeedDataAsync()
        {
            var userFound = await m_userManager.FindByEmailAsync("chase.huxley@TwitterClone.com");
            if (userFound == null)
            {
                var newUser = new TwitterCloneUser()
                {
                    UserName = "chasehuxley",
                    Email = "chase.huxley@TwitterClone.com"
                };

                var userRes = await m_userManager.CreateAsync(newUser, "qwertyui");
            }

            m_context.SaveChanges();

            if (!m_context.TwitterClonePosts.Any())
            {
                //Add new data
                var TwitterClonePost = new TwitterClonePost()
                {
                    Message = "First message! TwitterCloneTwitterClone!",
                    PostTime = DateTimeOffset.UtcNow,
                    User = await m_userManager.FindByEmailAsync("chase.huxley@TwitterClone.com")
                };

                m_context.TwitterClonePosts.Add(TwitterClonePost);

                m_context.SaveChanges();
            }
        }
    }

}