using Microsoft.Win32;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using static System.Windows.Forms.LinkLabel;
using Label = System.Windows.Forms.Label;
using System.Text.Json.Nodes;

namespace Shinterface
{
    public partial class Form1 : Form
    {

        List<Control> UserVariables = new List<Control>();
        List<string> UserStrings = new List<string>();
        List<int> UserInts = new List<int>();
        bool wtf = false;
        bool out1 = false;
        string last;
        string out2 = "";
        string res = "";
        bool ifelse = false;
        bool echo = true;
        string ip = "";
        string prgmName = "";
        string prgmVersion = "";
        string prgmAuthor = "";
        string prgmDesc = "";
        string basestr = "";
        string pathstr = "";

        public Form1()
        {
            InitializeComponent();
        

        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                TextBox textBox = sender as TextBox;
                if (textBox.Text.Length > 1)
                {
                    //textBox.Width = textBox.Text.Length * 9;
                    Size size = TextRenderer.MeasureText(textBox.Text, textBox.Font);
                    textBox.Width = size.Width;
                }
                else
                {
                    textBox.Width = flowLayoutPanel1.Width - 25;
                }

            }
        }

        private async void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(textBox1.Text))
            {
                e.Handled = true;
                await HandleCommands(textBox1.Text);
            }


        }

        private async Task HandleCommands(string input)
        {
            string raw = input.Trim();
            if (raw.StartsWith("//"))
            {
                return;
            }
            last = raw;
            string command = input.Trim();
            command = HandleStrings(command);
            if (!string.IsNullOrEmpty(command))
            {
                if (echo)
                {
                    await NewLine(command, Color.Gray, null);
                }
                if (command == "greet")
                {
                    await NewLine("Greetings World!", null, null);
                }
                else if (command == "hello world")
                {
                    await NewLine("Hello World!", null, null);
                }
                else if (command == "echo-on")
                {
                    echo = true;
                    await NewLine("Turned on echo", null, null);
                }
                else if (command == "echo-off")
                {
                    echo = false;
                    await NewLine("Turned off echo", null, null);
                }
                else if (command.StartsWith("say "))
                {
                    try
                    {
                        await NewLine(command.Substring(4), null, null);
                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }

                }
                else if (command.StartsWith("say-c-"))
                {
                    try
                    {
                        string[] s1 = command.Split(" ");
                        string s3 = s1[0].Substring(6);
                        Color color = Color.FromName(s3);
                        string s2 = command.Substring(s1[0].Length + 1);
                        await NewLine(s2, color, null);
                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }

                }
                else if (command == "colours")
                {
                    try
                    {
                        KnownColor[] colors = Enum.GetValues<KnownColor>();
                        foreach (KnownColor knowColor in colors)
                        {
                            Color color = Color.FromKnownColor(knowColor);
                            await NewLine(knowColor.ToString(), color, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }
                 
                }
                else if (command == "hack")
                {
                    Random rand = new Random();
                    for (int i = 0; i < 10; i++)
                    {
                        string abo = "";
                        for (int a = 0; a < this.Width; a++)
                        {
                            abo += rand.Next(0, 2).ToString();


                        }
                        await NewLine(abo, Color.Lime, null);
                    }

                }
                else if (command == "aquafetch")
                {
                    await NewLine(" Aquafetch -AquaCLI- ", Color.Aquamarine, null);
                    await NewLine("[-]", Color.Aquamarine, null);
                    await NewLine("   OS Platform : " + Environment.OSVersion.Platform.ToString(), Color.Aquamarine, null);
                    await NewLine("   OS Version : " + Environment.OSVersion.VersionString, Color.Aquamarine, null);
                    await NewLine("   OS SP : " + Environment.OSVersion.ServicePack, Color.Aquamarine, null);
                    await NewLine("   PC Name : " + Environment.MachineName, Color.Aquamarine, null);
                    await NewLine("   Is 64bit? : " + Environment.Is64BitOperatingSystem.ToString(), Color.Aquamarine, null);
                    await NewLine("[-]", Color.Aquamarine, null);


                }
                // -Projects-
                else if (command == "projects")
                {
                    await NewLine(" Project categories:", null, null);
                    await NewLine("[-]", Color.Red, null);
                    await NewLine("  \"projects aqua\" - projects owned by me", Color.Aquamarine, null);
                    await NewLine("  \"projects ad\" - projects I've made for the Anti-Depressant Dev Team", Color.LightGreen, null);
                    await NewLine("  \"projects mc\" - projects I've made for the Moscovium debloat software", Color.Purple, null);
                    await NewLine("  \"projects fr\" - projects I've made for the Freak-Lang development", Color.Pink, null);
                    await NewLine("[-]", Color.Red, null);
                    await NewLine(" You can open the web-links with the \"run <link>\" command!", Color.Fuchsia, null);
                }
                else if (command == "projects aqua")
                {
                    await NewLine("Universal-Relic-Game-Platform https://github.com/Megamer-studios/Universal-Relic-Game-Platform", Color.Aquamarine, null);
                    await NewLine("Gemini98 https://github.com/Megamer-studios/Gemini98", Color.Aquamarine, null);
                    await NewLine("Megamer-Shitware-Suite https://github.com/Megamer-studios/Megamer-Shitware-Suite", Color.Aquamarine, null);
                    await NewLine("Aqua-MP3-Player https://github.com/Megamer-studios/Aqua-MP3-Player", Color.Aquamarine, null);
                    await NewLine("Aquamarine-Calculator https://github.com/Megamer-studios/Aquamarine-Calculator", Color.Aquamarine, null);
                    await NewLine("AlterEgo-GEMINI https://github.com/Megamer-studios/AlterEgo-GEMINI", Color.Aquamarine, null);
                    await NewLine("Hope-s-Peak-Library https://github.com/Megamer-studios/Hope-s-Peak-Library", Color.Aquamarine, null);
                    await NewLine("AquamarinesYeahImporter https://github.com/Megamer-studios/AquamarinesYeahImporter", Color.Aquamarine, null);
                    await NewLine("AquamarineGenderSelector https://github.com/Megamer-studios/AquamarineGenderSelector", Color.Aquamarine, null);
                    await NewLine("AquamarIDE-Updated https://github.com/Megamer-studios/AquamarIDE-Updated", Color.Aquamarine, null);

                }
                else if (command == "projects ad")
                {
                    await NewLine("Notepad-Plus-Minus https://github.com/Anti-Depressants-Dev-Team/Notepad-Plus-Minus", Color.LightGreen, null);

                }
                else if (command == "projects mc")
                {
                    await NewLine("Moscovium-S https://github.com/Moscoviumdebloat/Moscovium-S", Color.Purple, null);
                    await NewLine("Moscovium-Lite https://github.com/Moscoviumdebloat/Moscovium/tree/Lite", Color.Purple, null);
                    await NewLine("Moscovium-2 https://github.com/Moscoviumdebloat/Moscovium/tree/V2", Color.Purple, null);
                    await NewLine("Moscovium-3 (main) https://github.com/Moscoviumdebloat/Moscovium - not made by me, but built on my code.", Color.Purple, null);
                }
                else if (command == "projects fr")
                {
                    await NewLine("FreakDocs https://freak-docs.vercel.app/", Color.Pink, null);
                    await NewLine("FREAK-Website https://freak-nine.vercel.app/", Color.Pink, null);

                }
                // -End Projects-
                else if (command.StartsWith("runps "))
                {

                    try
                    {
                        string link = command.Substring(6);
                        ProcessStartInfo processStartInfo = new ProcessStartInfo();
                        processStartInfo.CreateNoWindow = true;
                        processStartInfo.UseShellExecute = true;
                        processStartInfo.FileName = link;
                        Process.Start(processStartInfo);
                        await NewLine("Running: " + link, Color.LightSkyBlue, null);
                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }



                }
                else if (command.StartsWith("exec "))
                {

                    try
                    {
                        string link = command.Substring(5);
                        ProcessStartInfo psi = new ProcessStartInfo();
                        psi.Arguments = $"/c {link}";
                        psi.FileName = "cmd.exe";
                        Process.Start(psi);
                        await NewLine("Running: " + link, Color.LightSkyBlue, null);
                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }



                }
              
                else if (command.StartsWith("runscript "))
                {

                    try
                    {
                        string link = command.Substring(10).Replace("\"", " ");
                        await NewLine("Running script: " + link, Color.LightSkyBlue, null);
                        string[] lines = File.ReadAllLines(link);

                        foreach (string line in lines)
                        {
                            await HandleCommands(line.Trim());
                        }

                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }



                }
                else if (command.StartsWith("runscript-web "))
                {

                    try
                    {
                        string link = command.Substring(14);
                        await NewLine("Running script: " + link, Color.LightSkyBlue, null);
                        HttpClient client = new HttpClient();
                  string result = await client.GetStringAsync(link);

                        string[] lines = result.Split('\n');

                        foreach (string line in lines)
                        {
                            await HandleCommands(line.Trim());
                        }

                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }



                }
                else if (command.StartsWith("basicform "))
                {
                    bool horizontalbo = false;
                    try
                    {
                        Form form = new Form();
                        string s1 = command.Substring(10);
                        List<string> s2 = s1.Split(" ").ToList();
                        await NewLine("Creating new window!", Color.Green, Color.LightGray);
                        foreach (string line in s2)
                        {
                            await NewLine(line, Color.Green, Color.LightGray);
                        }
                        string title = s2[0].Replace("^", " ");
                        int wid = int.Parse(s2[1]);
                        int hei = int.Parse(s2[2]);
                        List<Control> controls = new List<Control>();
                        foreach (string line in s2)
                        {
                            if (line.StartsWith("label-"))
                            {
                                string text = line.Substring(6);
                                Label label = new Label();
                                label.Font = textBox1.Font;
                                label.Text = text.Replace("^", " ");
                                Size size = TextRenderer.MeasureText(label.Text, label.Font);
                                label.Size = size;
                                controls.Add(label);
                            }
                            else if (line.StartsWith("quit-form-button"))
                            {
                                Button button = new Button();
                                button.Text = "Exit";
                                button.Font = textBox1.Font;
                                button.Click += (o, e) => { form.Close(); };
                                Size size = TextRenderer.MeasureText(button.Text, button.Font);
                                button.Size = size;
                                controls.Add(button);
                            }
                            else if (line.StartsWith("quit-app-button"))
                            {
                                Button button = new Button();
                                button.Text = "Quit";
                                button.Font = textBox1.Font;
                                button.Click += (o, e) => { Debug.Close(); Application.Exit(); wtf = true; this.Close(); };
                                Size size = TextRenderer.MeasureText(button.Text, button.Font);
                                button.Size = size;
                                controls.Add(button);
                            }
                            else if (line.StartsWith("image-"))
                            {
                                string text = line.Substring(6);
                                PictureBox pictureBox = new PictureBox();
                                pictureBox.Image = Image.FromFile(text.Replace("^", " "));
                                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                pictureBox.Width = pictureBox.Image.Width;
                                pictureBox.Height = pictureBox.Image.Height;
                                controls.Add(pictureBox);
                            }
                            else if (line == "horizontal")
                            {
                                horizontalbo = true;
                            }
                            else if (line == "vars")
                            {
                                controls.AddRange(UserVariables);
                            }
                        }



                        //if (s1.Contains("button-"))
                        // {
                        //     string text = s2.Find(x => x.StartsWith("button-"));
                        //     s2.Remove(text);
                        //     text = text.Replace("button-", "");
                        //     Button button = new Button();
                        //     button.Text = text;
                        //     button.Width = 150;
                        //     button.Height = 50;
                        //     controls.Add(button);
                        // }
                        form.MaximizeBox = false;
                        form.Text = title;
                        form.Width = wid;
                        form.Height = hei;
                        form.FormBorderStyle = FormBorderStyle.Fixed3D;
                        FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel();
                        flowLayoutPanel2.Dock = DockStyle.Fill;
                        if (!horizontalbo)
                        {
                            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
                        }
                        flowLayoutPanel2.WrapContents = false;
                        if (controls != null)
                        {
                            foreach (Control control in controls)
                            {
                                flowLayoutPanel2.Controls.Add(control);

                            }
                            form.Controls.Add(flowLayoutPanel2);
                        }


                        form.ShowDialog(); // command handling is supressed until the form is closed

                        /* form.Show();*/ // uncomment this line and comment the line above for chaos!


                        //await  CreateForm(title, wid, hei, controls);

                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }



                }
                else if (command.StartsWith("interrupt "))
                {
                    string s1 = command.Substring(10);
                    await NewLine("Interrupting for " + s1 + " milliseconds...", Color.Red, null);
                    Thread.Sleep(int.Parse(s1));
                    await NewLine("Interruption over!", Color.Green, null);
                }
                else if (command.StartsWith("flowform "))
                {
                    bool horizontalbo = false;
                    try
                    {

                        Form form = new Form();
                        string s1 = command.Substring(9);
                        List<string> s2 = s1.Split(" ").ToList();
                        await NewLine("Creating new window!", Color.Green, Color.LightGray);
                        foreach (string line in s2)
                        {
                            await NewLine(line, Color.Green, Color.LightGray);
                        }
                        string title = s2[0].Replace("^", " ");
                        int wid = int.Parse(s2[1]);
                        int hei = int.Parse(s2[2]);
                        List<Control> controls = new List<Control>();
                        foreach (string line in s2)
                        {
                            if (line.StartsWith("label-"))
                            {
                                string text = line.Substring(6);
                                Label label = new Label();
                                label.Font = textBox1.Font;
                                label.Text = text.Replace("^", " ");
                                Size size = TextRenderer.MeasureText(label.Text, label.Font);
                                label.Size = size;
                                controls.Add(label);
                            }
                            else if (line.StartsWith("quit-form-button"))
                            {
                                Button button = new Button();
                                button.Text = "Exit";
                                button.Font = textBox1.Font;
                                button.Click += (o, e) => { form.Close(); };
                                Size size = TextRenderer.MeasureText(button.Text, button.Font);
                                button.Size = size;
                                controls.Add(button);
                            }
                            else if (line.StartsWith("quit-app-button"))
                            {
                                Button button = new Button();
                                button.Text = "Quit";
                                button.Font = textBox1.Font;
                                button.Click += (o, e) => { Debug.Close(); Application.Exit(); wtf = true; this.Close(); };
                                Size size = TextRenderer.MeasureText(button.Text, button.Font);
                                button.Size = size;
                                controls.Add(button);
                            }
                            else if (line.StartsWith("image-"))
                            {
                                string text = line.Substring(6);
                                PictureBox pictureBox = new PictureBox();
                                pictureBox.Image = Image.FromFile(text.Replace("^", " "));
                                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                pictureBox.Width = pictureBox.Image.Width;
                                pictureBox.Height = pictureBox.Image.Height;
                                controls.Add(pictureBox);
                            }
                            else if (line == "horizontal")
                            {
                                horizontalbo = true;
                            }
                            else if (line == "vars")
                            {
                                controls.AddRange(UserVariables);
                            }
                        }


                        //if (s1.Contains("button-"))
                        // {
                        //     string text = s2.Find(x => x.StartsWith("button-"));
                        //     s2.Remove(text);
                        //     text = text.Replace("button-", "");
                        //     Button button = new Button();
                        //     button.Text = text;
                        //     button.Width = 150;
                        //     button.Height = 50;
                        //     controls.Add(button);
                        // }
                        form.MaximizeBox = false;
                        form.Text = title;
                        form.Width = wid;
                        form.Height = hei;

                        form.FormBorderStyle = FormBorderStyle.Fixed3D;
                        FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel();
                        flowLayoutPanel2.Dock = DockStyle.Fill;

                        if (!horizontalbo)
                        {
                            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
                        }
                        flowLayoutPanel2.WrapContents = false;
                        if (controls != null)
                        {
                            foreach (Control control in controls)
                            {
                                flowLayoutPanel2.Controls.Add(control);

                            }
                            form.Controls.Add(flowLayoutPanel2);
                        }




                        form.Show();


                        //await  CreateForm(title, wid, hei, controls);

                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }



                }
                // -Wallpapers begin-
                else if (command.StartsWith("wlp-fill "))
                {
                    try
                    {
                        string s1 = command.Substring(9);
                        Wallpaper.Set(s1.Replace('"', ' '), "Fill");
                        await NewLine("Wallpaper(fill) set to : " + s1, null, null);
                    }
                    catch (Exception ex) {

                        await NewLine(ex.Message, null, null);
                            }
                   
                }
                else if (command.StartsWith("wlp-fit "))
                {try { 
                    string s1 = command.Substring(8);
                    Wallpaper.Set(s1.Replace('"', ' '), "Fit");
                    await NewLine("Wallpaper(fit) set to : " + s1, null, null);
                }
                    catch (Exception ex) {

                    await NewLine(ex.Message, null, null);
                }
            }
                else if (command.StartsWith("wlp-stretch "))
                {try { 

                    string s1 = command.Substring(12);
                    Wallpaper.Set(s1.Replace('"', ' '), "Stretch");
                    await NewLine("Wallpaper(stretch) set to : " + s1, null, null);
                }
                    catch (Exception ex) {

                    await NewLine(ex.Message, null, null);
                }
            }
                else if (command.StartsWith("wlp-tile "))
                {try { 
                    string s1 = command.Substring(9);
                    Wallpaper.Set(s1.Replace('"', ' '), "Tile");
                    await NewLine("Wallpaper(tile) set to : " + s1, null, null);
                }
                    catch (Exception ex) {

                    await NewLine(ex.Message, null, null);
                }
            }
                else if (command.StartsWith("wlp-span "))
                {
                    try { 
                    string s1 = command.Substring(9);
                    Wallpaper.Set(s1.Replace('"', ' '), "Span");
                    await NewLine("Wallpaper(span) set to : " + s1, null, null);
                }
                    catch (Exception ex) {

                    await NewLine(ex.Message, null, null);
                }
            }
                // -Wallpaper -end
                else if (command == "g-rundirec")
                {
                    await NewLine(Environment.ProcessPath, null, null);
                }
                else if (command == "hidecli")
                {
                    this.Hide();
                    await NewLine("Hid the terminal", null, null);

                }
                else if (command == "showcli")
                {
                    this.Show();
                    await NewLine("Unhid the terminal", null, null);

                }
                else if (command.StartsWith("get-text "))
                {
              string s1 = command.Substring(9);
                    await NewLine(File.ReadAllText(s1), null, null);

                }
                else if (command.StartsWith("get-text-lines "))
                {
                    string s1 = command.Substring(15);
                    string[] lines = File.ReadAllLines(s1);
                    foreach (string line in lines)
                    {
                        await NewLine(line, null, null);
                    }


                }
                else if (command == "runscript-gui")
                {

                    try
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog();

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string link = openFileDialog.FileName;
                            await NewLine("Running script: " + link, Color.LightSkyBlue, null);
                            string[] lines = File.ReadAllLines(link);

                            foreach (string line in lines)
                            {
                                await HandleCommands(line.Trim());
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }



                }

                else if (command == "quit" || command == "exit")
                {
                    await NewLine("Quitting application...", Color.Red, null);
                    Application.Exit();

                }
                // User-variables
                else if (command.StartsWith("#string "))
                {
                    try
                    {
                        string s1 = command.Substring(8);
                        string blya = s1;
                        UserStrings.Add(blya);
                   

                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }

                }
                else if (command.StartsWith("#int "))
                {
                    try
                    {
                        string s1 = command.Substring(5);
                        int blya = int.Parse(s1);
                        UserInts.Add(blya);


                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }

                }
                else if (command.StartsWith("$button "))
                {
                    try
                    {
                        string s1 = command.Substring(8);

                        Button button = new Button();
                        button.Font = textBox1.Font;
                        button.Text = s1;
                        button.Size = TextRenderer.MeasureText(s1, button.Font);
                        UserVariables.Add(button);

                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }

                }
                else if (command.StartsWith("$label "))
                {
                    try
                    {
                        string s1 = command.Substring(7);

                        Label label = new Label();
                        label.Font = textBox1.Font;
                        label.Text = s1;
                        label.Size = TextRenderer.MeasureText(s1, label.Font);
                        UserVariables.Add(label);

                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }

                }
                else if (command.StartsWith("$input "))
                {
                    try
                    {
                        string s1 = command.Substring(7);

                        TextBox label = new TextBox();
                        label.Font = textBox1.Font;
                        label.Text = s1;
                        label.Width = 100;
                        label.TextChanged += (o, s) =>
                        {
                            label.Text = label.Text;
                        };
                        UserVariables.Add(label);

                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }

                }
                //else if (command.StartsWith("$num "))
                //{
                //    try
                //    {
                //        string s1 = command.Substring(5);

                //        NumericUpDown label = new NumericUpDown();
                //        label.Font = textBox1.Font;
                //        label.Value = int.Parse(s1);
                //        label.Width = 100;
                //        UserVariables.Add(label);

                //    }
                //    catch (Exception ex)
                //    {
                //        await NewLine(ex.Message, Color.Red, null);
                //    }

                //}
                else if (command.StartsWith("$image "))
                {
                    try
                    {
                        string s1 = command.Substring(7);
                        string[] s2 = s1.Split(' ');
                        PictureBox picture = new PictureBox();

                        picture.Image = Image.FromFile(s2[0].Replace("\"", "").Replace("^", " "));
                        picture.Width = picture.Image.Width;
                        picture.Height = picture.Image.Height;
                        UserVariables.Add(picture);

                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }

                }
                else if (command.StartsWith("$imageweb "))
                {
                    try
                    {
                        string s1 = command.Substring(10);
             HttpClient client = new HttpClient();

                        PictureBox picture = new PictureBox();
                        Image image = Image.FromStream(await client.GetStreamAsync(s1));
                        picture.Image = image;
                        picture.Width = picture.Image.Width;
                        picture.Height = picture.Image.Height;
                        UserVariables.Add(picture);

                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }

                }
                else if (command.StartsWith("$b-"))
                {
                    try
                    {
                        string s1 = raw.Substring(3);
                        List<string> s2 = s1.Split(' ').ToList();
                        int a = int.Parse(s2[0]);

                        Button thisControl = (Button)UserVariables[a];
                        string arg = s1.Substring(s2[0].Length);

                        //s2.Remove(s2[0]);
                        //string arg ="";
                        //foreach (string s in s2)
                        //{
                        //    arg += s;
                        //}

                        List<string> cmnds = arg.Split(";").ToList();

                        foreach (string cmnd in cmnds)
                        {

                            await NewLine(cmnd, null, null);
                        }
                        thisControl.Click += async (o, s) =>
                        {
                            foreach (string cmnd in cmnds)
                            {
                                await HandleCommands(cmnd);
                            }
                        };
                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }





                }
                else if (command.StartsWith("$img-"))
                {
                    try
                    {
                        string s1 = command.Substring(5);
                        List<string> s2 = s1.Split(' ').ToList();
                        int a = int.Parse(s2[0]);

                        PictureBox thisControl = (PictureBox)UserVariables[a];
                        thisControl.Image = Image.FromFile(s1.Substring(s2[0].Length).Replace("\"", "").Replace("^", " "));
                        thisControl.Width = thisControl.Image.Width;
                        thisControl.Height = thisControl.Image.Height;
                    }

                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }
                }
                else if (command.StartsWith("$imgweb-"))
                {
                    try
                    {
                        string s1 = command.Substring(8);
                        List<string> s2 = s1.Split(' ').ToList();
                        int a = int.Parse(s2[0]);
                       
                        HttpClient client = new HttpClient();
                        PictureBox thisControl = (PictureBox)UserVariables[a];
                        Image image = Image.FromStream(await client.GetStreamAsync(s1.Substring(s2[0].Length)));
                        thisControl.Image = image;
                        thisControl.Width = thisControl.Image.Width;
                        thisControl.Height = thisControl.Image.Height;
                    }

                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }
                }
                else if (command.StartsWith("$l-"))
                {
                    try
                    {
                        string s1 = command.Substring(3);
                        List<string> s2 = s1.Split(' ').ToList();
                        int a = int.Parse(s2[0]);

                        Label thisControl = (Label)UserVariables[a];
                        thisControl.Text = s1.Substring(s2[0].Length); ;
                        thisControl.Size = TextRenderer.MeasureText(thisControl.Text, thisControl.Font);
                    }

                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }
                }
                else if (command.StartsWith("#s-"))
                {
                    try
                    {
                        string s1 = command.Substring(3);
                        List<string> s2 = s1.Split(' ').ToList();
                        int a = int.Parse(s2[0]);

                        UserStrings[a] = s1.Substring(s2[0].Length);


                    }

                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }
                }
                else if (command.StartsWith("#i-"))
                {
                    try
                    {
                        string s1 = command.Substring(3);
                        List<string> s2 = s1.Split(' ').ToList();
                        int a = int.Parse(s2[0]);

                        UserInts[a] = int.Parse(s1.Substring(s2[0].Length));


                    }

                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }
                }
                // end usr var
                else if (command.StartsWith("out "))
                {
                    try
                    {
                        string s1 = command.Substring(4);
                        out1 = true;
                        await HandleCommands(s1);
                        out1 = false;
                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }



                }
                else if (command == "clear-out")
                {
                    out2 = String.Empty;



                }
                else if (command.StartsWith("add "))
                {
                    try
                    {
                        string[] s1 = command.Split(" ");
                        int a = int.Parse(s1[1]);
                        int b = int.Parse(s1[2]);
                        int c = a + b;
                        await NewLine(c.ToString(), null, null);
                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }

                }
                else if (command.StartsWith("sub "))
                {
                    try
                    {
                        string[] s1 = command.Split(" ");
                        int a = int.Parse(s1[1]);
                        int b = int.Parse(s1[2]);
                        int c = a - b;
                        await NewLine(c.ToString(), null, null);
                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }

                }
                else if (command.StartsWith("div "))
                {
                    try
                    {
                        string[] s1 = command.Split(" ");
                        int a = int.Parse(s1[1]);
                        int b = int.Parse(s1[2]);
                        int c = a / b;
                        await NewLine(c.ToString(), null, null);
                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }
                }
                else if (command.StartsWith("mul "))
                {
                    try
                    {
                        string[] s1 = command.Split(" ");
                        int a = int.Parse(s1[1]);
                        int b = int.Parse(s1[2]);
                        int c = a * b;
                        await NewLine(c.ToString(), null, null);
                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }

                }
                else if (command.StartsWith("env-util "))
                {
                    try
                    {
                        string s1 = command.Substring(9);
                        HttpClient client = new HttpClient();
                        string result = await client.GetStringAsync(s1);
                        string[] lines = result.Split('\n');

                      
                        ip = lines[0];
                        prgmName = lines[1];
                        prgmAuthor = lines[2];
                        prgmVersion = lines[3];
                        prgmDesc = lines[4];
                        await NewLine("IP : " + ip, null, null);
                        await NewLine("Program Name : " + prgmName, null, null);
                        await NewLine("Program Author : " + prgmAuthor, null, null);
                        await NewLine("Program Version : " + prgmVersion, null, null);
                        await NewLine("Program Description : " + prgmDesc, null, null);

                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }

                }
                else if (command == ("env-clear"))
                {
                    try
                    {
                

                       
                        ip = string.Empty;
                        prgmName = string.Empty;
                        prgmAuthor = string.Empty;
                        prgmVersion = string.Empty;
                        prgmDesc = string.Empty;
        

                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }

                }
                else if (command == "usrvars")
                {
                    foreach (var control in UserVariables)
                    {
                        await NewLine(UserVariables.IndexOf(control).ToString() + " : " + control.ToString(), null, null);
                    }
                }
                else if (command == "clear-all")
                {
                    UserVariables.Clear();
                    UserStrings.Clear();
                    UserInts.Clear();
                    res = String.Empty;
                    out2 = String.Empty;
                    ip = String.Empty;
                    prgmAuthor = String.Empty;
                    prgmName = String.Empty;
                    prgmDesc = String.Empty;
                    prgmVersion = String.Empty;
                    basestr = String.Empty;
                    pathstr = String.Empty;
                }
                else if (command == "clear-http")
                {
                    basestr = String.Empty;
                    pathstr = String.Empty;
                }
                else if (command == "clear-within")
                {
                    UserVariables.Clear();
                    UserStrings.Clear();
                    UserInts.Clear();
             
                }
                else if (command == "clear-usrvars")
                {
                    UserVariables.Clear();
                }
                else if (command == "strings")
                {
                    foreach (var control in UserStrings)
                    {
                        await NewLine(UserStrings.IndexOf(control).ToString() + " : " + control, null, null);
                    }
                }
                else if (command == "clear-strings")
                {
                    UserStrings.Clear();
                }
                else if (command == "ints")
                {
                    foreach (var control in UserInts)
                    {
                        await NewLine(UserInts.IndexOf(control).ToString() + " : " + control.ToString(), null, null);
                    }
                }
                else if (command == "clear-ints")
                {
                    UserInts.Clear();
                }
                // HTTP
                else if (command.StartsWith("basestr "))
                {
                    string s1 = command.Substring(8);
                  basestr = s1;
                    await NewLine("Base string set to : " + basestr, null, null);
                }
                else if (command.StartsWith("pathstr "))
                {
                    string s1 = command.Substring(8);
                    pathstr = s1;
                    await NewLine("Path string set to : " + pathstr, null, null);
                }
                else if  (command.StartsWith("post "))
                {
                    try { 
                    string s1 = command.Substring(5).Trim().TrimStart('\uFEFF', '\u200B', '\u200D', '\uFEFE');

      
                      var content = new StringContent(s1, System.Text.Encoding.UTF8, "application/json");
                       HttpClient client = new HttpClient();
                      var response = await client.PostAsync(basestr + pathstr, content);
                     var responseString = await response.Content.ReadAsStringAsync();

                    await NewLine(responseString, null, null);
                    }
                    catch (Exception ex)
                    {

                        await NewLine(ex.Message, Color.Red, null);
                    }

                }
                else if (command == "get")
                {
                    try
                    {
                        HttpClient client = new HttpClient();

                        var response = await client.GetAsync(basestr + pathstr);
                        var responseString = await response.Content.ReadAsStringAsync();
                        await NewLine(responseString, null, null);
                    }
                    catch (Exception ex){ 
                    
                    await NewLine(ex.Message, Color.Red, null);
                    }
                }
              
                else
                {
                    await NewLine($"The command '{command}' is not recognized as a command!", Color.Red, Color.White);
                }
                textBox1.Text = string.Empty;

            }
        }

        private async Task NewLine(string text, Color? front, Color? back)
        {
            if (wtf)
            {
                Application.Exit();
                this.Close();
                Debug.Close();
            }
            TextBox textBox = new TextBox();
            textBox.Text = text;
            textBox.Font = textBox1.Font;
            textBox.ForeColor = textBox1.ForeColor;
            textBox.BackColor = textBox1.BackColor;
            if (front != null)
            {
                textBox.ForeColor = (Color)front;
            }
            if (back != null)
            {
                textBox.BackColor = (Color)back;
            }
            textBox.TextChanged += textBox1_TextChanged;
            textBox.BorderStyle = BorderStyle.None;
            Size size = TextRenderer.MeasureText(textBox.Text, textBox.Font);
            textBox.Width = size.Width;

            flowLayoutPanel1.Controls.Add(textBox);
            try
            {
                flowLayoutPanel1.Controls.SetChildIndex(textBox1, flowLayoutPanel1.Controls.Count);
            }
            catch (Exception ex)
            {
                {
                    await NewLine(ex.Message, Color.Red, null);
                }
            }
            res = text;
            if (out1)
            {
                out2 = text;
            }


        }
        public string HandleStrings(string a)
        {
            string FetchString = "   OS Platform : " + Environment.OSVersion.Platform.ToString() + "\n   OS Version : " + Environment.OSVersion.VersionString + "\n   OS SP : " + Environment.OSVersion.ServicePack + "\n   PC Name : " + Environment.MachineName + "\n   Is 64bit? : " + Environment.Is64BitOperatingSystem.ToString();
            a = a.Replace("{osplatform}", Environment.OSVersion.Platform.ToString());
            a = a.Replace("{osversion}", Environment.OSVersion.VersionString);
            a = a.Replace("{ossp}", Environment.OSVersion.ServicePack);
            a = a.Replace("{pcname}", Environment.MachineName.ToString());
            a = a.Replace("{fetchresult}", FetchString);
            a = a.Replace("{out}", out2);
            a = a.Replace("{res}", res);
            a = a.Replace("{ip}", ip);
            a = a.Replace("{name}", prgmName);
            a = a.Replace("{ver}", prgmVersion);
            a = a.Replace("{auth}", prgmAuthor);
            a = a.Replace("{desc}", prgmDesc);
            a = a.Replace("{basestr}", basestr);
            a = a.Replace("{pathstr}", pathstr);
            a = Regex.Replace(a, "\\{\\$\\s*(\\d+)\\s*\\}", match =>
            {
                if (int.TryParse(match.Groups[1].Value, out var idx) && idx >= 0 && idx < UserVariables.Count)
                {
                    return GetControlValue(UserVariables[idx]);
                }
                return match.Value;
            });
            a = Regex.Replace(a, "\\{\\#s\\s*(\\d+)\\s*\\}", match =>
            {
                if (int.TryParse(match.Groups[1].Value, out var idx) && idx >= 0 && idx < UserStrings.Count)
                {
                    return UserStrings[idx];
                }
                return match.Value;
            });
            a = Regex.Replace(a, "\\{\\#i\\s*(\\d+)\\s*\\}", match =>
            {
                if (int.TryParse(match.Groups[1].Value, out var idx) && idx >= 0 && idx < UserInts.Count)
                {
                    return UserInts[idx].ToString();
                }
                return match.Value;
            });
            return a;
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        string GetControlValue(Control ctrl)
        {

            switch (ctrl)
            {
                case TextBox tb: return tb.Text;
                case Label lb: return lb.Text;
                case Button btn: return btn.Text;
                case CheckBox cb: return cb.Checked.ToString();
                case PictureBox pb: return pb.ImageLocation ?? "";
                default: return ctrl.Text ?? string.Empty;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;
                textBox1.Text = last;
            }
        }

        private async void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string a = e.ToString();
            await NewLine(a, null, null);
        }

        private async void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            string a = e.ToString();
            await NewLine(a, null, null);
        }
        //private async Task CreateForm(string title, int width, int height, List<Control>? controls)
        //{
        //    Form form = new Form();
        //    form.Text = title;
        //    form.Width = width;
        //    form.Height = height;
        //    form.FormBorderStyle = FormBorderStyle.Fixed3D;
        //    FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel();
        //    flowLayoutPanel2.Dock = DockStyle.Fill;
        //    flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
        //    flowLayoutPanel2.WrapContents = false;
        //    if (controls != null)
        //    {
        //        foreach (Control control in controls)
        //        {
        //            flowLayoutPanel2.Controls.Add(control);

        //        }
        //        form.Controls.Add(flowLayoutPanel2);
        //    }

        //    form.ShowDialog();
        //}
    }
    public sealed class Wallpaper
    {
        public static string ErrorMessage;
        public static bool IsError;
        private const int SPI_SETDESKWALLPAPER = 20;
        private const int SPIF_UPDATEINIFILE = 1;
        private const int SPIF_SENDWININICHANGE = 2;



        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(
          int uAction,
          int uParam,
          string lpvParam,
          int fuWinIni);

        public static void Set(string file, string style)
        {
            using (Stream stream = (Stream)new MemoryStream(File.ReadAllBytes(file)))
            {
                Image image = Image.FromStream(stream);
                string lpvParam = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
                string filename = lpvParam;
                ImageFormat bmp = ImageFormat.Bmp;
                image.Save(filename, bmp);
                RegistryKey registryKey1 = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);
                if (style == "Fill")
                {
                    RegistryKey registryKey2 = registryKey1;
                    int num = 10;
                    string str1 = num.ToString();
                    registryKey2.SetValue("WallpaperStyle", (object)str1);
                    RegistryKey registryKey3 = registryKey1;
                    num = 0;
                    string str2 = num.ToString();
                    registryKey3.SetValue("TileWallpaper", (object)str2);
                }
                else if (style == "Fit")
                {
                    RegistryKey registryKey4 = registryKey1;
                    int num = 6;
                    string str3 = num.ToString();
                    registryKey4.SetValue("WallpaperStyle", (object)str3);
                    RegistryKey registryKey5 = registryKey1;
                    num = 0;
                    string str4 = num.ToString();
                    registryKey5.SetValue("TileWallpaper", (object)str4);
                }
                else if (style == "Strech")
                {
                    RegistryKey registryKey6 = registryKey1;
                    int num = 2;
                    string str5 = num.ToString();
                    registryKey6.SetValue("WallpaperStyle", (object)str5);
                    RegistryKey registryKey7 = registryKey1;
                    num = 0;
                    string str6 = num.ToString();
                    registryKey7.SetValue("TileWallpaper", (object)str6);
                }
                else if (style == "Tile")
                {
                    RegistryKey registryKey8 = registryKey1;
                    int num = 0;
                    string str7 = num.ToString();
                    registryKey8.SetValue("WallpaperStyle", (object)str7);
                    RegistryKey registryKey9 = registryKey1;
                    num = 1;
                    string str8 = num.ToString();
                    registryKey9.SetValue("TileWallpaper", (object)str8);
                }
                else if (style == "Center")
                {
                    RegistryKey registryKey10 = registryKey1;
                    int num = 0;
                    string str9 = num.ToString();
                    registryKey10.SetValue("WallpaperStyle", (object)str9);
                    RegistryKey registryKey11 = registryKey1;
                    num = 0;
                    string str10 = num.ToString();
                    registryKey11.SetValue("TileWallpaper", (object)str10);
                }
                else if (style == "Span")
                {
                    RegistryKey registryKey12 = registryKey1;
                    int num = 22;
                    string str11 = num.ToString();
                    registryKey12.SetValue("WallpaperStyle", (object)str11);
                    RegistryKey registryKey13 = registryKey1;
                    num = 0;
                    string str12 = num.ToString();
                    registryKey13.SetValue("TileWallpaper", (object)str12);
                }
                else
                {
                    ErrorMessage = "Wallpaper fitting option not recognized. Please choose another.";
                    IsError = true;


                }
                Wallpaper.SystemParametersInfo(20, 0, lpvParam, 3);
            }
        }

        public enum Style
        {
            Tiled,
            Centered,
            Stretched,
        }
    }
}
