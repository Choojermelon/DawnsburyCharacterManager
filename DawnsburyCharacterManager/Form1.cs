using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DawnsburyCharacterManager
{
    public partial class Form1 : Form
    {
        private string libraryPath = "characterLibrary.json";
        private JObject characterLibrary;
        private JArray profiles;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnExport.Enabled = false;
            btnDelete.Enabled = false;
            btnImport.Enabled = false;
            btnMoveDown.Enabled = false;
            btnMoveUp.Enabled = false;

            lblStatus.Text = "Open a Character Library to begin!";
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (lstCharacters.SelectedIndex == -1)
            {
                MessageBox.Show("Select a character first.");
                return;
            }

            var selectedName = lstCharacters.SelectedItem.ToString();

            var profile = profiles.FirstOrDefault(p => p["SelectedFeats"]?["Root:Identity"]?["Name"]?.ToString() == selectedName);

            if (profile == null)
            {
                MessageBox.Show("Character not found.");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "JSON Files (*.json)|*.json",
                FileName = $"{selectedName}.json"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveDialog.FileName, JsonConvert.SerializeObject(profile, Formatting.Indented));
                lblStatus.Text = $"Exported {selectedName}.";
            }
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "JSON Files (*.json)|*.json"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                var json = File.ReadAllText(openDialog.FileName);
                var newProfile = JObject.Parse(json);

                string newName = newProfile["SelectedFeats"]?["Root:Identity"]?["Name"]?.ToString();
                if (string.IsNullOrWhiteSpace(newName))
                {
                    MessageBox.Show("Invalid character file (no name found).");
                    return;
                }

                bool exists = profiles.Any(p => p["SelectedFeats"]?["Root:Identity"]?["Name"]?.ToString() == newName);
                if (exists)
                {
                    var result = MessageBox.Show(
                   $"A character named \"{newName}\" already exists. Import duplicate?",
                   "Duplicate Character",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning
               );

                    if (result == DialogResult.No)
                    {
                        lblStatus.Text = $"Import canceled.";
                        return;
                    }
                }

                profiles.Add(newProfile);
                characterLibrary["Profiles"] = profiles;

                File.WriteAllText(libraryPath, characterLibrary.ToString(Formatting.Indented));
                lstCharacters.Items.Add(newName);

                lblStatus.Text = $"Imported {newName}.";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstCharacters.SelectedIndex;

            if (selectedIndex < 0 || selectedIndex >= profiles.Count)
            {
                MessageBox.Show("Please select a valid character to delete.");
                return;
            }

            // Get the selected character name for confirmation display
            string selectedName = lstCharacters.SelectedItem.ToString();

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete \"{selectedName}\"?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                // Remove by index
                profiles.RemoveAt(selectedIndex);
                characterLibrary["Profiles"] = profiles;

                // Save updated JSON
                File.WriteAllText(libraryPath, characterLibrary.ToString(Formatting.Indented));

                // Update UI
                lstCharacters.Items.RemoveAt(selectedIndex);
                lblStatus.Text = $"Deleted {selectedName}.";
            }
        }

        private void btnOpenLibrary_Click(object sender, EventArgs e)
        {
            string defaultPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "Dawnsbury"
    );

            OpenFileDialog openDialog = new OpenFileDialog
            {
                Title = "Select characterLibrary.json",
                Filter = "JSON Files (*.json)|*.json",
                InitialDirectory = Directory.Exists(defaultPath) ? defaultPath : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                FileName = "characterLibrary.json"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                libraryPath = openDialog.FileName;

                try
                {
                    string json = File.ReadAllText(libraryPath);
                    characterLibrary = JObject.Parse(json);
                    profiles = (JArray)(characterLibrary["Profiles"] ?? new JArray());

                    lstCharacters.Items.Clear();

                    foreach (var profile in profiles)
                    {
                        var name = profile["SelectedFeats"]?["Root:Identity"]?["Name"]?.ToString();
                        lstCharacters.Items.Add(string.IsNullOrWhiteSpace(name) ? "[Unnamed Character]" : name);
                    }

                    if (profiles.Count > 0)
                    {
                        // Enable buttons now that a library is loaded
                        btnExport.Enabled = true;
                        btnDelete.Enabled = true;
                        btnImport.Enabled = true;
                        btnMoveDown.Enabled = true;
                        btnMoveUp.Enabled = true;

                        lblStatus.Text = $"Loaded {profiles.Count} character(s).";
                    }
                    else
                    {
                        MessageBox.Show("Selected file is not a Character Library or contains 0 characters.","Error");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading character library: " + ex.Message);
                    lblStatus.Text = "Failed to load character file.";
                }
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            int index = lstCharacters.SelectedIndex;
            if (index > 0)
            {
                // Swap profiles in JArray
                var tempProfile = profiles[index];
                profiles[index] = profiles[index - 1];
                profiles[index - 1] = tempProfile;

                // Swap names in ListBox
                var tempName = lstCharacters.Items[index];
                lstCharacters.Items[index] = lstCharacters.Items[index - 1];
                lstCharacters.Items[index - 1] = tempName;

                // Select the moved item
                lstCharacters.SelectedIndex = index - 1;

                // Save changes
                characterLibrary["Profiles"] = profiles;
                File.WriteAllText(libraryPath, characterLibrary.ToString(Formatting.Indented));

                lblStatus.Text = $"Moved character '{tempName}' up.";

            }
        }
        private void lstCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstCharacters.SelectedIndex;
            btnMoveUp.Enabled = index > 0;
            btnMoveDown.Enabled = index >= 0 && index < lstCharacters.Items.Count - 1;
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            int index = lstCharacters.SelectedIndex;
            if (index >= 0 && index < lstCharacters.Items.Count - 1)
            {
                // Swap profiles in JArray
                var tempProfile = profiles[index];
                profiles[index] = profiles[index + 1];
                profiles[index + 1] = tempProfile;

                // Swap names in ListBox
                var tempName = lstCharacters.Items[index];
                lstCharacters.Items[index] = lstCharacters.Items[index + 1];
                lstCharacters.Items[index + 1] = tempName;

                // Select the moved item
                lstCharacters.SelectedIndex = index + 1;

                // Save changes
                characterLibrary["Profiles"] = profiles;
                File.WriteAllText(libraryPath, characterLibrary.ToString(Formatting.Indented));

                lblStatus.Text = $"Moved character '{tempName}' down.";

            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.ShowDialog(); // Modal popup
        }
    }
}
