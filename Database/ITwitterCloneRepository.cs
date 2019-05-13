using TwitterClone.Models;
using System.Collections.Generic;

namespace TwitterClone.Database
{
    public interface ITwitterCloneRepository
    {
        IEnumerable<TwitterClonePost> GetAllPosts();
        IEnumerable<TwitterClonePost> GetAllPostsByUserId(string a_userId);
        void AddPost(TwitterClonePost newMessage);
        bool SaveAll();
    }
}