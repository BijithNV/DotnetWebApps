using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using TwitterClone.Models;

namespace TwitterClone.Database
{
    public class TwitterCloneRepository : ITwitterCloneRepository
    {
        private TwitterCloneContext m_context;
        private ILogger<TwitterCloneRepository> m_logger;

        public TwitterCloneRepository(TwitterCloneContext a_context, ILogger<TwitterCloneRepository> a_logger)
        {
            m_context = a_context;
            m_logger = a_logger;
        }

        public void AddPost(TwitterClonePost newPost)
        {
            m_context.Add(newPost);
        }

        public IEnumerable<TwitterClonePost> GetAllPosts()
        {
            try
            {
                return m_context.TwitterClonePosts.Include(t => t.User).OrderBy(t => t.PostTime).ToList();
            }
            catch (Exception ex)
            {
                m_logger.LogError("Could not get TwitterClones from database", ex);
                return null;
            }
            
        }

        public IEnumerable<TwitterClonePost> GetAllPostsByUserId(string a_userId)
        {
            try
            {
                return m_context.TwitterClonePosts.Where(t => (t.User.Id == a_userId)).OrderBy(t => t.PostTime).ToList();
            }
            catch (Exception ex)
            {
                m_logger.LogError("Could not get trips from database", ex);
                return null;
            }
        }

        public bool SaveAll()
        {
            return (m_context.SaveChanges() > 0);
        }
    }
}
