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
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnExport.Enabled = false;
            btnDelete.Enabled = false;
            btnImport.Enabled = false;
            btnMoveDown.Enabled = false;
            btnMoveUp.Enabled = false;
            btnBackup.Enabled = false;

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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json";
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Import Character(s)";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                int successCount = 0;
                List<string> failedFiles = new List<string>();

                foreach (var file in openFileDialog.FileNames)
                {
                    try
                    {
                        string jsonText = File.ReadAllText(file);
                        JObject importedChar = JObject.Parse(jsonText);

                        var name = importedChar["SelectedFeats"]?["Root:Identity"]?["Name"]?.ToString();

                        if (string.IsNullOrEmpty(name))
                            throw new Exception("Character has no name.");

                        // Check for duplicates
                        bool nameExists = profiles.Any(p =>
                            p["SelectedFeats"]?["Root:Identity"]?["Name"]?.ToString() == name);

                        if (nameExists)
                        {
                            DialogResult result = MessageBox.Show(
                                $"Character \"{name}\" already exists. Import anyway?",
                                "Duplicate Character",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );
                            if (result != DialogResult.Yes)
                            {
                                continue;
                            }
                        }

                        profiles.Add(importedChar);
                        lstCharacters.Items.Add(name);
                        successCount++;
                    }
                    catch
                    {
                        failedFiles.Add(Path.GetFileName(file));
                    }
                }

                characterLibrary["Profiles"] = profiles;
                File.WriteAllText(libraryPath, characterLibrary.ToString(Formatting.Indented));

                // Summary dialog
                string summary = $"Successfully imported: {successCount}\n";
                if (failedFiles.Count > 0)
                {
                    summary += $"Failed to import {failedFiles.Count} file(s):\n- {string.Join("\n- ", failedFiles)}";
                }

                MessageBox.Show(summary, "Import Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblStatus.Text = $"Imported {successCount} character(s).";
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
                        btnBackup.Enabled = true;

                        DialogResult result = MessageBox.Show(
    $"Loaded {profiles.Count} character(s).\nChanges are made immediately, so consider backing up your library file first.\n\nWould you like to back it up now?",
    "Library Loaded",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question
);

                        if (result == DialogResult.Yes)
                        {
                            BackupLibrary(); // Replace this with your actual backup method
                        }
                        lblStatus.Text = $"Loaded {profiles.Count} character(s).";
                    }
                    else
                    {
                        MessageBox.Show("Selected file is not a Character Library or contains 0 characters.","Error");
                        lblStatus.Text = "";
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

            // Display character info

            if (index < 0 || index >= profiles.Count) return;

            JObject character = (JObject)profiles[index];

            try
            {
                var feats = character["SelectedFeats"] as JObject;
                if (feats == null) return;

                var identity = feats["Root:Identity"] as JObject;
                var ancestry = feats["Root:Ancestry"] as JObject;
                var classFeat = feats["Root:Class"] as JObject;

                string name = identity?["Name"]?.ToString() ?? "Unknown";
                string ancestryName = ancestry?["MainFeat"]?.ToString() ?? "Unknown";
                string className = classFeat?["MainFeat"]?.ToString() ?? "Unknown";
                int maxLevel = character.Value<int?>("MaximumLevel") ?? 0;

                lblName.Text = $"{name}";
                txtDetails.Text = $"Class: {className}\r\nAncestry: {ancestryName}\r\nMax level: {maxLevel}" +
                    "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading character details:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private void BackupLibrary()
        {
            try
            {
                string directory = Path.GetDirectoryName(libraryPath);
                string fileName = Path.GetFileNameWithoutExtension(libraryPath);
                string extension = Path.GetExtension(libraryPath);

                // Generate timestamped file name
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                string backupPath = Path.Combine(directory, $"{fileName}_backup_{timestamp}{extension}");

                // Copy the file
                File.Copy(libraryPath, backupPath);

                MessageBox.Show($"Backup created at:\n{backupPath}", "Backup Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Backup failed:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(libraryPath) || !File.Exists(libraryPath))
            {
                MessageBox.Show("No character library file is currently loaded.", "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Create a backup of the current library?", "Confirm Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                BackupLibrary();
            }
        }
    }
}
