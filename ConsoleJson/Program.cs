using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleJson.Model;
using ConsoleJson.BusinessLogic;

namespace ConsoleJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonRelativePath = "Data/posts.json";
            List<PostModel> postListFromFile = new PostService().GetPostListFromJsonWithPath(jsonRelativePath);

            string jsonUrl = "https://jsonplaceholder.typicode.com/posts";
            List<PostModel> postListFromUrl = new PostService().GetPostListFromJsonWithUrl(jsonUrl);

            for (int i = 0; i < postListFromFile.Count; i++)
            {
                PostModel thisPost = postListFromFile[i];

                Console.WriteLine("L'id dello user del post n. " + thisPost.id + " => " + thisPost.userId);
            }

            foreach (PostModel post in postListFromUrl)
            {
                Console.WriteLine("Il titolo del post n. " + post.id + " => " + post.title);
            }

            Console.Read();
        }
    }

}
