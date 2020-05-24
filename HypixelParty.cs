using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitanixClient___Forms
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
            string ustring = string.Join(", ", members);
            string final = "In a party with " + ustring;
            if(more)
            {
                final += " and " + (members.Count - 4) + " more...";
            }
            return final;
        }
    }
    class HypixelUser
    {
        public bool hasRank { get; private set; }
        public string name { get; private set; }
        public string rank { get; private set; }
        public string fullName { get; private set; }

        public HypixelUser(string fullname)
        {
            fullName = fullname;
            string user = fullname.Trim();
            hasRank = user.Contains(' ');
            if (hasRank)
            {
                string[] spl = user.Split(' ');
                name = spl[1]; // [VIP] Hypix__L
                rank = spl[0];
            }
            else
                name = user; // cwxzyy
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