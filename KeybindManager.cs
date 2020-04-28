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
                gameInternalName = "solo_normal",
                gameName = "Skywars Solo Normal"
            });
            availableKeybinds.Add(new KeybindGame()
            {
                gameInternalName = "solo_insane",
                gameName = "Skywars Solo Insane"
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
            return game.gameName + " | " + key.ToString();
        }
    }
}
