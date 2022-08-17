using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service
{

    //public class SteamModel
    //{
    //    public bool ContainsKey { get; set; }
    //    public List<string> Where { get; set; } = new List<string>();
    //    public string Title { get; set; }
    //    public string Slug { get; set; }
    //    public string Id { get; set; }
    //    public string Description { get; set; }
    //    public string Url
    //    {
    //        get
    //        {
    //            return $"https://forum.shapeshift.com/t/{Slug}/{Id}";
    //        }
    //    }
    //    public List<PostModel> Posts { get; set; } = new List<PostModel>();
    //}
    //public class APIResponse<T>
    //{
    //    public string Message { get; set; }
    //    public bool Status { get; set; }
    //    public List<T> Data { get; set; }
    //}
    //public class PostModel
    //{
    //    public string Id { get; set; }
    //    public string Text { get; set; }
    //    public string By { get; set; }
    //    public int RepliesCount { get; set; }
    //    public string ReplyUrl { get { return $"https://forum.shapeshift.com/posts/{Id}/replies"; } }
    //    public List<ReplyModel> Replies { get; set; } = new List<ReplyModel>();
    //}

    //public class ReplyModel
    //{
    //    public string Text { get; set; }
    //    public string By { get; set; }
    //}
    //public class Poster
    //    {
    //        public string extras { get; set; }
    //        public string description { get; set; }
    //        public int user_id { get; set; }
    //        public object primary_group_id { get; set; }
    //        public object flair_group_id { get; set; }
    //    }

    //    public class Root
    //    {
    //        public List<User> users { get; set; } = new List<User>();
    //        public List<object> primary_groups { get; set; } = new();
    //        public List<object> flair_groups { get; set; } = new();
    //        public TopicList topic_list { get; set; } = new TopicList();
    //    }

    //    public class TagsDescriptions
    //    {
    //    }

    //    public class Topic
    //    {
    //        public int id { get; set; }
    //        public string title { get; set; }
    //        public string fancy_title { get; set; }
    //        public string slug { get; set; }
    //        public int posts_count { get; set; }
    //        public int reply_count { get; set; }
    //        public int highest_post_number { get; set; }
    //        public string image_url { get; set; }
    //        public DateTime created_at { get; set; }
    //        public DateTime? last_posted_at { get; set; }
    //        public bool bumped { get; set; }
    //        public DateTime bumped_at { get; set; }
    //        public string archetype { get; set; }
    //        public bool unseen { get; set; }
    //        public bool pinned { get; set; }
    //        public object unpinned { get; set; }
    //        public string excerpt { get; set; }
    //        public bool visible { get; set; }
    //        public bool closed { get; set; }
    //        public bool archived { get; set; }
    //        public object bookmarked { get; set; }
    //        public object liked { get; set; }
    //        public List<string> tags { get; set; } = new List<string>();
    //        public TagsDescriptions tags_descriptions { get; set; }
    //        public int views { get; set; }
    //        public int like_count { get; set; }
    //        public bool has_summary { get; set; }
    //        public string last_poster_username { get; set; }
    //        public int category_id { get; set; }
    //        public bool pinned_globally { get; set; }
    //        public object featured_link { get; set; }
    //        public bool has_accepted_answer { get; set; }
    //        public List<Poster> posters { get; set; } = new List<Poster>();
    //    }

    //    public class TopicList
    //    {
    //        public bool can_create_topic { get; set; }
    //        public string more_topics_url { get; set; }
    //        public int per_page { get; set; }
    //        public List<string> top_tags { get; set; } = new List<string>();
    //        public List<Topic> topics { get; set; } = new List<Topic>();
    //    }

    //    public class User
    //    {
    //        public int id { get; set; }
    //        public string username { get; set; }
    //        public string name { get; set; }
    //        public string avatar_template { get; set; }
    //        public object flair_name { get; set; }
    //        public bool admin { get; set; }
    //        public int trust_level { get; set; }
    //        public bool? moderator { get; set; }
    //    }




    //    //Post details

    //    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    //    public class ActionsSummary
    //    {
    //        public int id { get; set; }
    //        public int count { get; set; }
    //        public bool hidden { get; set; }
    //        public bool can_act { get; set; }
    //    }

    //    public class CreatedBy
    //    {
    //        public int id { get; set; }
    //        public string username { get; set; }
    //        public string name { get; set; }
    //        public string avatar_template { get; set; }
    //    }

    //    public class Details
    //    {
    //        public bool can_edit { get; set; }
    //        public int notification_level { get; set; }
    //        public List<Participant> participants { get; set; } = new List<Participant>();
    //        public CreatedBy created_by { get; set; }
    //        public LastPoster last_poster { get; set; }
    //    }

    //    public class LastPoster
    //    {
    //        public int id { get; set; }
    //        public string username { get; set; }
    //        public string name { get; set; }
    //        public string avatar_template { get; set; }
    //    }

    //    public class LinkCount
    //    {
    //        public string url { get; set; }
    //        public bool @internal { get; set; }
    //        public bool reflection { get; set; }
    //        public string title { get; set; }
    //        public int clicks { get; set; }
    //    }

    //    public class Participant
    //    {
    //        public int id { get; set; }
    //        public string username { get; set; }
    //        public string name { get; set; }
    //        public string avatar_template { get; set; }
    //        public int post_count { get; set; }
    //        public object primary_group_name { get; set; }
    //        public object flair_name { get; set; }
    //        public object flair_url { get; set; }
    //        public object flair_color { get; set; }
    //        public object flair_bg_color { get; set; }
    //        public int trust_level { get; set; }
    //    }

    //    public class Post
    //    {
    //        public int id { get; set; }
    //        public string name { get; set; }
    //        public string username { get; set; }
    //        public string avatar_template { get; set; }
    //        public DateTime created_at { get; set; }
    //        public string cooked { get; set; }
    //        public int post_number { get; set; }
    //        public int post_type { get; set; }
    //        public DateTime updated_at { get; set; }
    //        public int reply_count { get; set; }
    //        public int? reply_to_post_number { get; set; }
    //        public int quote_count { get; set; }
    //        public int incoming_link_count { get; set; }
    //        public int reads { get; set; }
    //        public int readers_count { get; set; }
    //        public double score { get; set; }
    //        public bool yours { get; set; }
    //        public int topic_id { get; set; }
    //        public string topic_slug { get; set; }
    //        public string display_username { get; set; }
    //        public string primary_group_name { get; set; }
    //        public string flair_name { get; set; }
    //        public string flair_url { get; set; }
    //        public string flair_bg_color { get; set; }
    //        public string flair_color { get; set; }
    //        public int version { get; set; }
    //        public bool can_edit { get; set; }
    //        public bool can_delete { get; set; }
    //        public bool can_recover { get; set; }
    //        public bool can_wiki { get; set; }
    //        public List<LinkCount> link_counts { get; set; } = new List<LinkCount>();
    //        public bool read { get; set; }
    //        public string user_title { get; set; }
    //        public bool bookmarked { get; set; }
    //        public List<ActionsSummary> actions_summary { get; set; } = new List<ActionsSummary>();
    //        public bool moderator { get; set; }
    //        public bool admin { get; set; }
    //        public bool staff { get; set; }
    //        public int user_id { get; set; }
    //        public bool hidden { get; set; }
    //        public int trust_level { get; set; }
    //        public object deleted_at { get; set; }
    //        public bool user_deleted { get; set; }
    //        public object edit_reason { get; set; }
    //        public bool can_view_edit_history { get; set; }
    //        public bool wiki { get; set; }
    //        public bool can_accept_answer { get; set; }
    //        public bool can_unaccept_answer { get; set; }
    //        public bool accepted_answer { get; set; }
    //        public ReplyToUser reply_to_user { get; set; }
    //    }

    //    //public class Poster
    //    //{
    //    //    public string extras { get; set; }
    //    //    public string description { get; set; }
    //    //    public User user { get; set; }
    //    //}

    //    public class PostStream
    //    {
    //        public List<Post> posts { get; set; } = new List<Post>();
    //        public List<int> stream { get; set; } = new List<int>();
    //    }

    //    public class ReplyToUser
    //    {
    //        public string username { get; set; }
    //        public string name { get; set; }
    //        public string avatar_template { get; set; }
    //    }

    //    public class PostDetails
    //    {
    //        public PostStream post_stream { get; set; }
    //        public List<List<int>> timeline_lookup { get; set; } = new List<List<int>>();
    //        public List<SuggestedTopic> suggested_topics { get; set; } = new List<SuggestedTopic>();
    //        public List<object> tags { get; set; } = new();
    //        public TagsDescriptions tags_descriptions { get; set; }
    //        public int id { get; set; }
    //        public string title { get; set; }
    //        public string fancy_title { get; set; }
    //        public int posts_count { get; set; }
    //        public DateTime created_at { get; set; }
    //        public int views { get; set; }
    //        public int reply_count { get; set; }
    //        public int like_count { get; set; }
    //        public DateTime? last_posted_at { get; set; }
    //        public bool visible { get; set; }
    //        public bool closed { get; set; }
    //        public bool archived { get; set; }
    //        public bool has_summary { get; set; }
    //        public string archetype { get; set; }
    //        public string slug { get; set; }
    //        public int category_id { get; set; }
    //        public int word_count { get; set; }
    //        public object deleted_at { get; set; }
    //        public int user_id { get; set; }
    //        public object featured_link { get; set; }
    //        public bool pinned_globally { get; set; }
    //        public object pinned_at { get; set; }
    //        public object pinned_until { get; set; }
    //        public object image_url { get; set; }
    //        public int slow_mode_seconds { get; set; }
    //        public object draft { get; set; }
    //        public string draft_key { get; set; }
    //        public object draft_sequence { get; set; }
    //        public object unpinned { get; set; }
    //        public bool pinned { get; set; }
    //        public int current_post_number { get; set; }
    //        public int highest_post_number { get; set; }
    //        public object deleted_by { get; set; }
    //        public List<ActionsSummary> actions_summary { get; set; } = new List<ActionsSummary>();
    //        public int chunk_size { get; set; }
    //        public bool bookmarked { get; set; }
    //        public List<object> bookmarks { get; set; } = new();
    //        public object topic_timer { get; set; }
    //        public int message_bus_last_id { get; set; }
    //        public int participant_count { get; set; }
    //        public bool show_read_indicator { get; set; }
    //        public object thumbnails { get; set; }
    //        public object slow_mode_enabled_until { get; set; }
    //        public bool tags_disable_ads { get; set; }
    //        public Details details { get; set; }
    //    }

    //    public class SuggestedTopic
    //    {
    //        public int id { get; set; }
    //        public string title { get; set; }
    //        public string fancy_title { get; set; }
    //        public string slug { get; set; }
    //        public int posts_count { get; set; }
    //        public int reply_count { get; set; }
    //        public int highest_post_number { get; set; }
    //        public string image_url { get; set; }
    //        public DateTime created_at { get; set; }
    //        public DateTime last_posted_at { get; set; }
    //        public bool bumped { get; set; }
    //        public DateTime bumped_at { get; set; }
    //        public string archetype { get; set; }
    //        public bool unseen { get; set; }
    //        public bool pinned { get; set; }
    //        public object unpinned { get; set; }
    //        public bool visible { get; set; }
    //        public bool closed { get; set; }
    //        public bool archived { get; set; }
    //        public object bookmarked { get; set; }
    //        public object liked { get; set; }
    //        public List<string> tags { get; set; } = new List<string>();
    //        public TagsDescriptions tags_descriptions { get; set; }
    //        public int like_count { get; set; }
    //        public int views { get; set; }
    //        public int category_id { get; set; }
    //        public object featured_link { get; set; }
    //        public bool has_accepted_answer { get; set; }
    //        public List<Poster> posters { get; set; } = new List<Poster>();
    //    }

    //    //public class TagsDescriptions
    //    //{
    //    //}

    //    //public class User
    //    //{
    //    //    public int id { get; set; }
    //    //    public string username { get; set; }
    //    //    public string name { get; set; }
    //    //    public string avatar_template { get; set; }
    //    //}

    //    //Reply details
    //    public class ReplyDetails
    //    {
    //        public int id { get; set; }
    //        public string name { get; set; }
    //        public string username { get; set; }
    //        public string avatar_template { get; set; }
    //        public DateTime created_at { get; set; }
    //        public string cooked { get; set; }
    //        public int post_number { get; set; }
    //        public int post_type { get; set; }
    //        public DateTime updated_at { get; set; }
    //        public int reply_count { get; set; }
    //        public int reply_to_post_number { get; set; }
    //        public int quote_count { get; set; }
    //        public int incoming_link_count { get; set; }
    //        public int reads { get; set; }
    //        public int readers_count { get; set; }
    //        public double score { get; set; }
    //        public bool yours { get; set; }
    //        public int topic_id { get; set; }
    //        public string topic_slug { get; set; }
    //        public string display_username { get; set; }
    //        public object primary_group_name { get; set; }
    //        public object flair_name { get; set; }
    //        public object flair_url { get; set; }
    //        public object flair_bg_color { get; set; }
    //        public object flair_color { get; set; }
    //        public int version { get; set; }
    //        public bool can_edit { get; set; }
    //        public bool can_delete { get; set; }
    //        public bool can_recover { get; set; }
    //        public bool can_wiki { get; set; }
    //        public object user_title { get; set; }
    //        public ReplyToUser reply_to_user { get; set; }
    //        public bool bookmarked { get; set; }
    //        public List<ActionsSummary> actions_summary { get; set; }
    //        public bool moderator { get; set; }
    //        public bool admin { get; set; }
    //        public bool staff { get; set; }
    //        public int user_id { get; set; }
    //        public bool hidden { get; set; }
    //        public int trust_level { get; set; }
    //        public object deleted_at { get; set; }
    //        public bool user_deleted { get; set; }
    //        public object edit_reason { get; set; }
    //        public bool can_view_edit_history { get; set; }
    //        public bool wiki { get; set; }
    //        public bool can_accept_answer { get; set; }
    //        public bool can_unaccept_answer { get; set; }
    //        public bool accepted_answer { get; set; }
    //    }
    }

