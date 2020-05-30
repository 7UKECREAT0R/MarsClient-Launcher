using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsClientLauncher
{
    public partial class Settings_KeybindsControl : UserControl
    {
        public Settings_KeybindsControl()
        {
            InitializeComponent();
            picker.DrawItem += Picker_DrawItem;

            int curve = 10;
            Form1.SetBorderCurve(curve, addButton);
            Form1.SetBorderCurve(curve, deleteButton);
            Form1.SetBorderCurve(curve, editButton);
            Form1.SetBorderCurve(curve, confirmButton);
        }

        private void Picker_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.State == DrawItemState.Focus)
                e.DrawFocusRectangle();

            int i = e.Index;
            int c = picker.Items.Count;
            if (i < 0 || i >= c) return;
            object obj = picker.Items[i];
            string txt = (obj == null) ?
                "Null Object?" : obj.ToString();
            using(Brush b = new SolidBrush(e.ForeColor))
            {
                e.Graphics.TextRenderingHint = System.Drawing
                    .Text.TextRenderingHint.ClearTypeGridFit;
                e.Graphics.DrawString(txt, e.Font, b, e.Bounds);
            }
        }

        public bool enabled = false;
        Point enabledPos, disabledPos;
        Timer timer;

        private void Settings_KeybindsControl_Load(object sender, EventArgs e)
        {
            enabledPos = new Point(SettingsMenu.SETTINGS_TAB_X, 74);
            disabledPos = enabledPos;
            disabledPos.X += Size.Width;
            Location = disabledPos;
            timer = new Timer();
            timer.Interval = 16;
            timer.Tick += Timer_Tick;
            timer.Start();

            editButton.Enabled = false;
            deleteButton.Enabled = false;
            UpdateBox();
        }
        public static int Interpolate(int a, int b, double t)
        {
            return (int)((1 - t) * a + t * b);
        }

        private void UpdateBox()
        {
            picker.Items.Clear();
            if (Data.keybinds == null) return;
            foreach (var kb in Data.keybinds.keybinds)
                picker.Items.Add(kb);
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            Keybind toEdit = (Keybind)picker.SelectedItem;
            if (toEdit == null) return;
            using (SingleKeybindEditor edit = new SingleKeybindEditor(toEdit))
            {
                edit.ShowDialog();
                ApplyKeybindAfterEditing(edit, true, toEdit);
                editButton.Enabled = false;
                deleteButton.Enabled = false;
            }
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            Keybind toDelete = (Keybind)picker.SelectedItem;
            if (toDelete == null) return;
            Data.keybinds.DeleteKeybind(toDelete);
            if (Data.keybinds.keybinds.Count == 0)
            {
                editButton.Enabled = false;
                deleteButton.Enabled = false;
            }
            UpdateBox();
        }
        private void confirmButton_Click(object sender, EventArgs e)
        {
            enabled = false;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            using (SingleKeybindEditor edit = new SingleKeybindEditor())
            {
                edit.ShowDialog();
                ApplyKeybindAfterEditing(edit, false, null);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Animate left or right.
            Point loc = Location;
            int curX = loc.X;
            int goalX;
            if (enabled)
                goalX = enabledPos.X;
            else
                goalX = disabledPos.X;

            int n = Interpolate(curX, goalX, 0.2);
            loc.X = n;
            Location = loc;
        }
        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            editButton.Enabled = true;
            deleteButton.Enabled = true;
        }

        private void ApplyKeybindAfterEditing(SingleKeybindEditor editor, bool edited, Keybind toReplace)
        {
            if (!editor.confirmed) return;
            Keybind kb = editor.keybind;
            if (edited)
                Data.keybinds.ReplaceKeybind(toReplace, kb);
            else
                Data.keybinds.AddKeybind(kb);
            UpdateBox();
        }
    }
}
