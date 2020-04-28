using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TitanixClient___Forms
{
    public partial class SingleKeybindEditor : Form
    {
        public bool confirmed = false;
        public Keybind keybind;
        bool loaded = false;
        public SingleKeybindEditor()
        {
            InitializeComponent();
            PopulateComboBoxes();
            keybind = new Keybind()
            {
                game = null,
                key = 0
            };
            loaded = true;
        }
        public SingleKeybindEditor(Keybind pre)
        {
            InitializeComponent();
            PopulateComboBoxes();
            keybind = pre;
            gameBox.SelectedItem = pre.game;
            keyBox.SelectedItem = pre.key;
            loaded = true;
        }
        void PopulateComboBoxes()
        {
            foreach (var game in Data.keybinds.availableKeybinds)
            {
                gameBox.Items.Add(game);
            }
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                keyBox.Items.Add(key);
            }
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            confirmed = false;
            Close();
        }
        private void confirm_Click(object sender, EventArgs e)
        {
            if(keybind.key == 0)
            {
                MessageBox.Show("Please pick a key!", "Invalid keybind.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (keybind.game == null)
            {
                MessageBox.Show("Please pick a game!", "Invalid keybind.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            confirmed = true;
            Close();
        }

        private void gameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            keybind.game = (KeybindGame)gameBox.SelectedItem;
        }

        private void keyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            keybind.key = (Keys)keyBox.SelectedItem;
        }
    }
}
