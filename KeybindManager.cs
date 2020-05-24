using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TitanixClient___Forms
{
    public class KeybindManager
    {
        public List<KeybindGame> availableKeybinds = new List<KeybindGame>();
        public List<Keybind> keybinds = new List<Keybind>();
        public KeybindManager()
        {
            availableKeybinds.Add(new KeybindGame() {
                gameInternalName = "play solo_normal",
                gameName = "Skywars - Solo Normal"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play solo_insane",
                gameName = "Skywars - Solo Insane"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play teams_normal",
                gameName = "Skywars - Teams Normal"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play teams_insane",
                gameName = "Skywars - Teams Insane"
            });



            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play blitz_solo_normal",
                gameName = "Blitz SG - Solo"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play blitz_teams_normal",
                gameName = "Blitz SG - Teams"
            });



            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play bedwars_eight_one",
                gameName = "Bed Wars - Solo"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play bedwars_eight_one",
                gameName = "Bed Wars - Doubles"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play bedwars_four_three",
                gameName = "Bed Wars - 3v3v3v3"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play bedwars_four_four",
                gameName = "Bed Wars - 4v4v4v4"
            });



            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play sb",
                gameName = "Skyblock"
            });



            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play duels_classic_duel",
                gameName = "Duels - Solo Classic"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play duels_sw_duel",
                gameName = "Duels - Solo Skywars"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play duels_uhc_duel",
                gameName = "Duels - Solo UHC"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play duels_op_duel",
                gameName = "Duels - Solo OP"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play duels_sumo_duel",
                gameName = "Duels - Sumo"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play duels_bridge_duel",
                gameName = "Duels - Solo The Bridge"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play duels_classic_doubles",
                gameName = "Duels - Doubles Classic"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play duels_sw_doubles",
                gameName = "Duels - Doubles Skywars"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play duels_uhc_doubles",
                gameName = "Duels - Doubles UHC"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play duels_op_doubles",
                gameName = "Duels - Doubles OP"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play duels_bridge_doubles",
                gameName = "Duels - Doubles The Bridge"
            });



            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play murder_classic",
                gameName = "Murder Mystery - Classic"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play murder_assassins",
                gameName = "Murder Mystery - Assassins"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "play murder_infection",
                gameName = "Murder Mystery - Infection"
            });



            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "tipall",
                gameName = "GENERAL KEYBINDS - Tip All"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "pl",
                gameName = "GENERAL KEYBINDS - Party List"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "fl",
                gameName = "GENERAL KEYBINDS - Friends List"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "fl",
                gameName = "GENERAL KEYBINDS - Friends List"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "fl",
                gameName = "GENERAL KEYBINDS - Friends List"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "chat a",
                gameName = "GENERAL KEYBINDS - All Chat Mode"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "chat p",
                gameName = "GENERAL KEYBINDS - Party Chat Mode"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "p warp",
                gameName = "GENERAL KEYBINDS - Warp Party"
            });
        }
        public void AddKeybind(string gameName, Keys key)
        {
            KeybindGame game = null;
            foreach(var test in availableKeybinds)
            {
                if (test.gameName.Equals(gameName))
                {
                    game = test; break;
                }
            }
            if (game == null) return;
            keybinds.Add(new Keybind()
            {
                game = game,
                key = key
            });
        }
        public void AddKeybind(Keybind kb)
        {
            keybinds.Add(kb);
        }
        public void ReplaceKeybind(Keybind a, Keybind b)
        {
            Keybind[] arr = keybinds.ToArray();
            for(int i = 0; i < arr.Length; i++)
            {
                Keybind current = arr[i];
                if(current.Equals(a))
                    arr[i] = b;
            }
            keybinds = arr.ToList();
        }
        public void DeleteKeybind(Keybind k)
        {
            keybinds.Remove(k);
        }

        public string Serialize()
        {
            List<string> serialized = new List<string>();
            foreach(Keybind kb in keybinds)
                serialized.Add(kb.game.gameName + "|" + ((int)kb.key));
            return string.Join("#", serialized);
        }
        public static KeybindManager Deserialize(string input)
        {
            KeybindManager mgr = new KeybindManager();
            string[] kbs = input.Split(new char[]{ '#' },
                StringSplitOptions.RemoveEmptyEntries);
            foreach(string kb in kbs)
            {
                string[] parts = kb.Split('|');
                string gameName = parts[0];
                Keys key = (Keys)int.Parse(parts[1]);
                mgr.AddKeybind(gameName, key);
            }
            return mgr;
        }
    }
    public class KeybindGame
    {
        public string gameName;
        public string gameInternalName;
        public override string ToString()
        {
            return gameName;
        }
    }
    public class Keybind
    {
        public Keys key;
        public KeybindGame game;
        public override string ToString()
        {
            return "(" + game.ToString() + "), CTRL+" + key.ToString();
        }
    }
}
