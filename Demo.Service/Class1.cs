using HtmlAgilityPack;
using RestSharp;
using System.Text.Json;
using System.Web;

namespace Demo.Service
{
    public class DataService
    {
        public static async Task<List<SteamModel>> Search(string input)
        {
            List<SteamModel> records = new List<SteamModel>();
            string url = "https://forum.shapeshift.com/c/workstream-discussion/6.json";
           
            if (!string.IsNullOrEmpty(input))
            {
                var keys = input.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                var steams = await FetchData(url, keys);
                int pages = (steams.Count + 1 - 1) / 1;
                List<Task> tasks = new List<Task>();
                for (int count = 1; count <= pages; ++count)
                {
                    int index = count - 1;
                    var data = steams.Skip(index * 1).Take(1).ToList();

                    Task newTask = Task.Factory.StartNew(() =>
                    {
                        var entry = data.FirstOrDefault();
                        var steam = FetchDetails(entry, keys);
                        records.Add(steam);
                        if (steam.ContainsKey)
                            Console.WriteLine($"Match found. Url:" + steam.Url);
                        else
                        {
                            Console.WriteLine($"No Match found. Url:{steam.Url} Where: {string.Join(";", steam.Where)}");
                        }
                    });
                    tasks.Add(newTask);

                    if (count % 20 == 0 || count == pages)
                    {
                        foreach (Task task in tasks)
                        {
                            while (!task.IsCompleted)
                            { }
                        }
                    }
                }


                records = records.Where(x => x.ContainsKey).ToList();
                //if (records.Count > 0)
                //{
                //    var today = DateTime.Now;
                //    File.WriteAllText($"result-{today.Year}{today.Month}{today.Day}{today.Hour}{today.Minute}{today.Second}.json", JsonSerializer.Serialize(records));
                //}
            }
            return records;
        }

        public static SteamModel FetchDetails(SteamModel steam, List<string> keys)
        {
            Console.WriteLine("Fetching post details. Url: " + steam.Url);
            RestClient client = new RestClient();
            var request = new RestRequest(steam.Url, Method.Get);
            var response = client.Execute<PostDetails>(request);
            if (response != null && response.Data != null)
            {
                foreach (var post in response.Data.post_stream.posts)
                {
                    var doc = new HtmlDocument();
                    doc.LoadHtml(post.cooked);
                    var postModel = new PostModel
                    {
                        Id = post.id.ToString(),
                        By = post.name,
                        Text = HttpUtility.HtmlDecode(doc.DocumentNode.InnerText),
                        RepliesCount = post.reply_count,
                    };

                    if (CheckForKeys(postModel.Text, keys))
                    {
                        steam.ContainsKey = true;
                        steam.Where.Add($"Post: {postModel.Id} By: {postModel.By}");
                    }

                    if (postModel.RepliesCount > 0)
                    {
                        postModel.Replies = FetchReplies(postModel.ReplyUrl, steam, keys);
                    }

                    steam.Posts.Add(postModel);
                }
            }
            return steam;
        }

        public static bool CheckForKeys(string text, List<string> keys)
        {
            var words = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var key in keys)
            {
                var word = words.FirstOrDefault(x => x.ToLower() == key.ToLower());
                if (word != null)
                    return true;
            }
            return false;
        }

        private static List<ReplyModel> FetchReplies(string replyUrl, SteamModel steam, List<string> keys)
        {
            List<ReplyModel> model = new List<ReplyModel>();
            RestClient client = new RestClient();
            var request = new RestRequest(replyUrl, Method.Get);
            request.AddHeader("Referer", steam.Url);
            request.AddHeader("X-Requested-With", " XMLHttpRequest");
            var response = client.Execute<List<ReplyDetails>>(request);
            if (response != null && response.Data != null)
            {
                foreach (var reply in response.Data)
                {
                    var doc = new HtmlDocument();
                    doc.LoadHtml(reply.cooked);

                    var m = new ReplyModel { By = reply.name, Text = HttpUtility.HtmlDecode(doc.DocumentNode.InnerText) };
                    if (CheckForKeys(m.Text, keys))
                    {
                        steam.ContainsKey = true;
                        steam.Where.Add($"Reply by {m.By}");
                    }
                    model.Add(m);
                }
            }
            return model;
        }

        public static async Task<List<SteamModel>> FetchData(string url, List<string> keys)
        {
            List<SteamModel> topics = new List<SteamModel>();
            RestClient client = new RestClient();
            bool hasPage = true;
            while (hasPage)
            {
                var request = new RestRequest(url, Method.Get);
                var data = await client.ExecuteAsync<Root>(request);
                Console.WriteLine("Processing " + url);
                if (data != null && data.Data != null)
                {
                    if (!string.IsNullOrEmpty(data.Data.topic_list.more_topics_url))
                    {
                        url = "https://forum.shapeshift.com" + data.Data.topic_list.more_topics_url;
                    }
                    else
                    {
                        hasPage = false;
                    }

                    var ts = data.Data.topic_list.topics;
                    if (ts.Count > 0)
                    {
                        foreach (var t in ts)
                        {
                            SteamModel model = new SteamModel
                            {
                                Id = t.id.ToString(),
                                Title = t.title,
                                Slug = t.slug,
                                ContainsKey = CheckForKeys(t.title, keys)
                            };
                            if (model.ContainsKey)
                                model.Where.Add("Title");
                            topics.Add(model);
                        }
                    }
                }
                else
                    throw new Exception("Unable to continue. Data from page didnt recieved");


            }

            return topics;

        }
    }
}