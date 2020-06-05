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
        List<HypixelFriend> fakeFriends;
        List<HypixelFriend> friends;
        public bool loaded = false;

        public HypixelSelf()
        {
            friends = new List<HypixelFriend>();
        }
        public void AddFriend(HypixelFriend friend)
        {
            if(!friend.loaded && fakeFriends != null)
            {
                // Check fakeFriends to find a possibly loaded name.
                if(fakeFriends.Any(f => f.UUID.Equals(friend.UUID)))
                {
                    // If found, apply to friend object.
                    HypixelFriend fake = fakeFriends.First
                        (f => f.UUID.Equals(friend.UUID));
                    if(fake.loaded)
                        friend.SetName(fake.name);
                }
            }

            if (!friends.Any(f => f.UUID.Equals(friend.UUID))
            && !friend.UUID.Equals(Data.mcUUID))
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
        public int Count() { return friends.Count; }
        public int LoadedCount() { return friends.Count(f => f.loaded); }

        public string Serialize()
        {
            StringBuilder json = new StringBuilder();
            json.AppendLine("[");
            int i = -1;
            if (loaded)
            {
                foreach (HypixelFriend f in friends)
                {
                    i++;
                    if ((i - 1) >= friends.Count)
                        json.AppendLine(f.AsJSON());
                    else
                        json.AppendLine(f.AsJSON() + ",");
                }
            } else if(fakeFriends != null)
            {
                foreach (HypixelFriend f in fakeFriends)
                {
                    i++;
                    if((i-1) >= fakeFriends.Count)
                        json.AppendLine(f.AsJSON());
                    else
                        json.AppendLine(f.AsJSON() + ",");
                }
            }
            json.Append("\n]");
            string fin = json.ToString();
            return fin;
        }
        public static HypixelSelf Deserialize(string dat)
        {
            JArray json = JArray.Parse(dat);
            HypixelSelf self = new HypixelSelf();
            self.fakeFriends = new List<HypixelFriend>();
            foreach (JToken obj in json)
            {
                string UUID = obj.Value<string>("UUID");
                string name = obj.Value<string>("name");
                bool loaded = bool.Parse(obj.Value<string>("loaded"));

                HypixelFriend f = new HypixelFriend(UUID);
                if (loaded)
                    f.SetName(name);

                self.fakeFriends.Add(f);
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
"        \"loaded\":\"" + loaded + "\"\n" +
"    }";
        }
    }
}