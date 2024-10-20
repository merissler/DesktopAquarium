using Newtonsoft.Json;

using DesktopAquarium.Fish;
using DesktopAquarium.Settings;
using System.Reflection;

namespace DesktopAquarium
{
    public partial class frmMain : Form
    {
        private AquariumSettings _settings;
        private BaseSettings? _newSettings;
        private JsonSerializerSettings _serializerSettings;
        private ImageHelper _imageHelper;
        private ImageList _fishImages;

        private int _currentFishID;

        private const string SettingsFilePath = @"C:\ProgramData\AquariumSettings.json";

        public delegate void KillFishEventHandler(int fishID);
        public event KillFishEventHandler KillFish;

        public frmMain()
        {
            InitializeComponent();

            _imageHelper = new ImageHelper();
            _currentFishID = 0;

            _fishImages = new ImageList();
            _fishImages.ImageSize = new Size(32, 32);

            _serializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };

            var fishTypes = Enum.GetValues(typeof(FishType)).Cast<FishType>().ToList();
            fishTypes.Insert(0, (FishType)(-1));
            cmbFishType.DataSource = fishTypes;
            cmbFishType.SelectedIndex = -1;
            cmbFishType.Format += cmbFishType_Format;

            if (File.Exists(SettingsFilePath))
            {
                string raw = File.ReadAllText(SettingsFilePath);
                AquariumSettings? settings = JsonConvert.DeserializeObject<AquariumSettings>(raw, _serializerSettings);
                if (settings != null && settings.FishList.Count > 0)
                {
                    _settings = settings;
                    foreach (BaseSettings fish in settings.FishList)
                    {
                        _currentFishID = Math.Max(_currentFishID, fish.FishID + 1);
                        AddFishToList(fish);
                    }
                }
                else
                    _settings = new();
            }
            else
                _settings = new();
        }

        private void AddFishToList(BaseSettings fish)
        {
            if (fish == null)
                return;

            _fishImages.Images.Add(fish.Name ?? fish.FishType.ToString(), GetIconForFish(fish.FishType));

            lvFishList.SmallImageList = _fishImages;
            lvFishList.Items.Add(new ListViewItem()
            {
                Text = fish.Name ?? fish.FishType.ToString(),
                Tag = fish.FishID,
                ImageKey = fish.Name ?? fish.FishType.ToString()
            });
        }

        private Image GetIconForFish(FishType fish)
        {
            switch (fish)
            {
                case FishType.Shark:
                    return _imageHelper.LoadImageFromBytes(Properties.Resources.SharkIcon);
                default:
                    return _imageHelper.LoadImageFromBytes(Properties.Resources.NullIcon);
            }
        }

        private void llRemoveFish_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvFishList.SelectedItems.Count == 0)
                return;

            if (!int.TryParse(lvFishList.SelectedItems[0].Tag?.ToString(), out int fishID))
                fishID = -1;

            KillFish?.Invoke(fishID);

            lvFishList.Items.Remove(lvFishList.SelectedItems[0]);
        }

        private void CreateControlsForFish(BaseSettings settings, FlowLayoutPanel panel)
        {
            Type objType = settings.GetType();
            panel.Controls.Clear();

            foreach (PropertyInfo property in objType.GetProperties())
            {
                if (property.Name == "FishID")
                    continue;

                if (property.PropertyType == typeof(int))
                {
                    Label label = new Label
                    {
                        Text = property.Name,
                        AutoSize = true,
                    };
                    panel.Controls.Add(label);
                    NumericUpDown numericUpDown = new NumericUpDown
                    {
                        Name = property.Name,
                        Minimum = 0,
                        Maximum = 10000,
                        Value = (int?)property.GetValue(settings, null) ?? 0
                    };
                    panel.Controls.Add(numericUpDown);
                }
                else if (property.PropertyType == typeof(bool))
                {
                    CheckBox checkBox = new()
                    {
                        Name = property.Name,
                        Text = property.Name,
                        AutoSize = true,
                        Checked = (bool?)property.GetValue(settings, null) ?? false
                    };
                    panel.Controls.Add(checkBox);
                }
                else if (property.PropertyType != typeof(FishType))
                {
                    Label label = new Label
                    {
                        Text = property.Name,
                        AutoSize = true,
                    };
                    panel.Controls.Add(label);
                    TextBox textBox = new() 
                    { 
                        Name = property.Name,
                        Text = (string?)property.GetValue(settings, null),
                    };
                    panel.Controls.Add(textBox);
                }
            }
        }

        private void CreateNewFish(BaseSettings settingsToUse)
        {
            if (_newSettings == null)
                return;

            _newSettings = GetSettingsFromControls(_newSettings, flpNewSettings);
            
            AddFishToList(settingsToUse);

            if (_newSettings.GetType() == typeof(SharkSettings))
            {
                var frm = new Shark((SharkSettings)_newSettings);
                frm.Show();
            }

            _newSettings = null;
        }

        public BaseSettings GetSettingsFromControls(BaseSettings settings, FlowLayoutPanel panel)
        {
            // Iterate through all controls on the form
            foreach (Control ctrl in panel.Controls)
            {
                // Check if the control is a NumericUpDown (for integer properties)
                if (ctrl is NumericUpDown numericUpDown)
                {
                    // Use the control's name to find the corresponding property in Settings
                    var property = settings.GetType().GetProperty(numericUpDown.Name);
                    if (property != null && property.PropertyType == typeof(int))
                    {
                        // Set the value of the property
                        property.SetValue(settings, (int)numericUpDown.Value);
                    }
                }
                // Check if the control is a CheckBox (for boolean properties)
                else if (ctrl is CheckBox checkBox)
                {
                    var property = settings.GetType().GetProperty(checkBox.Name);
                    if (property != null && property.PropertyType == typeof(bool))
                    {
                        property.SetValue(settings, checkBox.Checked);
                    }
                }
                // Check if the control is a TextBox (for string or other properties)
                else if (ctrl is TextBox textBox)
                {
                    var property = settings.GetType().GetProperty(textBox.Name);
                    if (property != null && property.PropertyType == typeof(string))
                    {
                        property.SetValue(settings, textBox.Text);
                    }
                }
            }

            return settings;
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var settingsString = JsonConvert.SerializeObject(_settings, Formatting.Indented);
            File.WriteAllText(SettingsFilePath, settingsString);
        }

        private void cmbFishType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_newSettings != null)
            {
                if (MessageBox.Show("This new fish has not been saved. Are you sure you want to lose your changes?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CreateNewFish(_newSettings);
                }
                else
                { 
                    _newSettings = null; 
                }
            }
            FishType? type = cmbFishType.SelectedItem as FishType?;
            if (type == null)
                return;

            switch (type)
            {
                case FishType.Shark:
                    _newSettings = new SharkSettings();
                    CreateControlsForFish(_newSettings, flpNewSettings);
                    break;
                default:
                    return;
            }
        }

        private void cmbFishType_Format(object? sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem != null && (FishType)e.ListItem == (FishType)(-1))
            {
                e.Value = "No Option Selected";
            }
            else
            {
                e.Value = e.ListItem?.ToString(); // Display the enum value as the default
            }
        }

        private void btnCreateFish_Click(object sender, EventArgs e)
        {
            FishType? type = cmbFishType.SelectedItem as FishType?;
            if (type == null)
                return;

            if (type == (FishType)(-1) || _newSettings == null)
            {
                MessageBox.Show("There is no new fish loaded.");
                return;
            }

            CreateNewFish(_newSettings);
        }
    }
}
