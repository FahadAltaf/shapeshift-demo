using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service
{

    public class Post
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string avatar_template { get; set; }
        public DateTime created_at { get; set; }
        public int like_count { get; set; }
        public string blurb { get; set; }
        public int post_number { get; set; }
        public int topic_id { get; set; }
    }

    public class Listing
    {
        public string website { get; set; }
        public List<Post> posts { get; set; } = new List<Post>();
        public List<Topic> topics { get; set; } = new List<Topic>();
    
    }

    public class Topic
    {
        public int id { get; set; }
        public string title { get; set; }
        public string fancy_title { get; set; }
        public string slug { get; set; }
        public int posts_count { get; set; }
       
    }


}
