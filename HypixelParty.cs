using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsClientLauncher
{
    class HypixelParty
    {
        public bool inParty = false;
        public List<string> members = new List<string>();
        public bool unknownUsers = false;

        public HypixelParty() { }

        public string GetPartyString()
        {
            if (!inParty) return "Not in a party.";
            if (unknownUsers) return "In a party with unknown people.";

            string[] users;
            bool more = false;
            if(members.Count >= 5)
            {
                users = new string[]
                {
                    members.ElementAt(0),
                    members.ElementAt(1),
                    members.ElementAt(2),
                    members.ElementAt(3)
                };
                more = true;
            } else
            {
                users = members.ToArray();
                string last = users[users.Length - 1];
                last = "and " + last;
                users[users.Length - 1] = last;
            }
            string ustring = string.Join(", ", users);
            string final = "In a party with " + ustring;
            if(more)
            {
                final += " and " + (members.Count - 4) + " more...";
            }
            return final;
        }
    }
    class HypixelParsedUser
    {
        public bool HasRank { get; private set; }
        public string Name { get; private set; }
        public string Rank { get; private set; }
        public string FullName { get; private set; }

        public HypixelParsedUser(string fullname)
        {
            FullName = fullname;
            string user = fullname.Trim();
            HasRank = user.Contains(' ');
            if (HasRank)
            {
                string[] spl = user.Split(' ');
                Name = spl[1]; // [VIP] Hypix__L
                Rank = spl[0];
            }
            else
                Name = user; // cwxzyy
        }
    }
    class HypixelGame
    {
        public string gameName = "Main Lobby";

        public static readonly Dictionary<string, string>
            gameDetectionStrings = new Dictionary<string, string>();
        static HypixelGame()
        {
            gameDetectionStrings.Add("Gather resources and equipment on your island", "Skywars");
            gameDetectionStrings.Add(" joined the lobby!", "Main Lobby");
            gameDetectionStrings.Add("[CHAT]                              The Bridge Duel", "The Bridge 1v1");
            gameDetectionStrings.Add("[CHAT]                          SkyWars Duel", "Skywars 1v1");
            gameDetectionStrings.Add("[CHAT]                       SkyWars Doubles", "Skywars 2v2");
            gameDetectionStrings.Add("[CHAT]                          Blitz Survival Games", "Blitz SG");
            gameDetectionStrings.Add("Build something relevant to the theme:", "Build Battle");
            gameDetectionStrings.Add("Protect your bed and destroy the enemy beds.", "Bed Wars");

            // Arcade Games
            gameDetectionStrings.Add(" finished the game.", "Hypixel Says");
            gameDetectionStrings.Add("[CHAT]           Avoid players with TNT on their heads! If", "TNT Tag");
        }

        public override string ToString()
        {
            return "In " + gameName;
        }
    }
}