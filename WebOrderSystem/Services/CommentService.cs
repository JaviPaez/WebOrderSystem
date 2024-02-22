using Newtonsoft.Json;
using RestSharp;
using WebOrderSystem.Models;

namespace WebOrderSystem.Services
{
    public interface ICommentService
    {
        List<int> GetTopPostIdsWithMostComments();
    }

    public class CommentService : ICommentService
    {
        public List<int> GetTopPostIdsWithMostComments()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("comments", Method.Get);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                List<Comment>? comments = (response.Content != null) ? JsonConvert.DeserializeObject<List<Comment>>(response.Content) : [];
                if (comments != null)
                {
                    var topPosts = comments
                        .GroupBy(c => c.PostId)
                        .OrderByDescending(g => g.Count())
                        .Take(3)
                        .Select(g => g.Key)
                        .ToList();

                    return topPosts;
                }
                return [];
            }
            else
            {
                throw new Exception($"Error calling the API: {response.ErrorMessage}");
            }
        }
    }
}
