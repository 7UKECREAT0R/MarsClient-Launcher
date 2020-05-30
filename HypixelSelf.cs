using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsClientLauncher
{
    class HypixelSelf
    {
        List<HypixelFriend> friends;

        public HypixelSelf()
        {
            friends = new List<HypixelFriend>();
        }
        public void AddFriend(HypixelFriend friend)
        {
            friends.Add(friend);
        }
        public void RemoveFriendByUsername(string username)
        {
            friends = friends
                .Where(f => !f.name.Equals(username))
                .ToList();
        }
        public void RemoveFriendByUUID(string UUID)
        {
            friends = friends
                .Where(f => !f.UUID.Equals(UUID))
                .ToList();
        }
        public HypixelFriend[] GetFriends()
        {
            return friends.ToArray();
        }

        public HypixelFriend? GetNextNeededUsername()
        {
            if (friends.Any(f => f.loaded == false))
                return friends.First(f => f.loaded == false);
            else
                return null;
        }
        public void SetNextNeededUsername(HypixelFriend friend)
        {
            HypixelFriend? nullable = GetNextNeededUsername();
            if (nullable.HasValue)
            {
                friends.Remove(nullable.Value);
                friends.Add(friend);
            }
            else
                friends.Add(friend);
            return;
        }

        public string Serialize()
        {
            StringBuilder json = new StringBuilder();
            json.AppendLine("[");
            foreach(HypixelFriend f in friends)
                json.AppendLine(f.AsJSON());
            json.Append("\n]");
            return json.ToString();
        }
        public static HypixelSelf Deserialize(string dat)
        {
            JArray json = JArray.Parse(dat);
            HypixelSelf self = new HypixelSelf();
            foreach (JToken obj in json)
            {
                string UUID = obj.Value<string>("UUID");
                string name = obj.Value<string>("name");
                bool loaded = obj.Value<bool>("loaded");

                HypixelFriend f = new HypixelFriend(UUID);
                if (loaded)
                    f.SetName(name);

                self.AddFriend(f);
            }
            return self;
        }
    }
    struct HypixelFriend
    {
        public string UUID;
        public string name;
        public bool loaded;

        public HypixelFriend(string UUID)
        {
            this.UUID = UUID;
            name = "Loading...";
            loaded = false;
        }
        public void SetName(string name)
        {
            this.name = name;
            loaded = true;
        }
        public string AsJSON()
        {
            return
"  {\n"+
"        \"UUID\":\"" + UUID + "\",\n" +
"        \"name\":\"" + name + "\",\n" +
"        \"loaded\":" + loaded + "\n" +
"    }";
        }
    }
}
