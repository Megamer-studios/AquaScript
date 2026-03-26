using System.Diagnostics;
using System.Net;
using System.Reflection.Emit;
using static System.Windows.Forms.LinkLabel;
using Label = System.Windows.Forms.Label;

namespace Shinterface
{
    public partial class Form1 : Form
    {

        List<Control> UserVariables = new List<Control>();
        bool wtf = false;
        public Form1(string[] args)
        {
            InitializeComponent();
            if (args.Length >= 1) { 
            HandleCommands("run " + args[1]).Wait();
            }
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
            string command = input.Trim();
            command = VariableHandler.HandleStrings(command);
            if (!string.IsNullOrEmpty(command))
            {
                await NewLine(command, Color.Gray, null);
                if (command == "greet")
                {
                    await NewLine("Greetings World!", null, null);
                }
                else if (command == "hello world")
                {
                    await NewLine("Hello World!", null, null);
                }
                else if (command.StartsWith("say "))
                {
                    try
                    {
                        await NewLine(command.Substring(4), null, null);
                    }
                    catch (Exception ex) { 
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
                    await NewLine(" Project categories:",null, null);
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
                else if (command.StartsWith("run "))
                {
                    
                    try
                    {
                        string link = command.Substring(4);
                        ProcessStartInfo processStartInfo = new ProcessStartInfo();
                        processStartInfo.CreateNoWindow = true;
                        processStartInfo.UseShellExecute = true;
                        processStartInfo.FileName = link;
                        Process.Start(processStartInfo);
                        await NewLine("Running: "+ link, Color.LightSkyBlue, null);
                    }catch(Exception ex) 
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
                        
                        foreach (string line in lines) { 
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
                        foreach (string line in s2) {
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

                        /* form.Show();*/ // uncomment this line and comment line 282 for chaos!


                        //await  CreateForm(title, wid, hei, controls);

                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }



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
                else if (command.StartsWith("$button "))
                {
                    try
                    {
                        string s1 = command.Substring(8);
                        string[] s2 = s1.Split(' ');
                        Button button = new Button();
                        button.Font = textBox1.Font;
                        button.Text = s2[0].Replace("^", " ");
                        button.Size = TextRenderer.MeasureText(s2[0], button.Font);
                        UserVariables.Add(button);
                        
                    }
                    catch (Exception ex) {
                        await NewLine(ex.Message, Color.Red, null);
                    }
                    
                }
                else if (command.StartsWith("$label "))
                {
                    try
                    {
                        string s1 = command.Substring(7);
                        string[] s2 = s1.Split(' ');
                        Label label = new Label();
                        label.Font = textBox1.Font;
                        label.Text = s2[0].Replace("^", " ");
                        label.Size = TextRenderer.MeasureText(s2[0], label.Font);
                        UserVariables.Add(label);

                    }
                    catch (Exception ex)
                    {
                        await NewLine(ex.Message, Color.Red, null);
                    }

                }
                else if (command.StartsWith("$image "))
                {
                    try
                    {
                        string s1 = command.Substring(7);
                        string[] s2 = s1.Split(' ');
                        PictureBox picture = new PictureBox();
                      
                        picture.Image = Image.FromFile(s2[0].Replace("\"", "").Replace("^"," "));
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
                        string s1 = command.Substring(3);
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

                        foreach (string cmnd in cmnds) {
                          
                            await NewLine(cmnd, null, null);
                        }
                        thisControl.Click += async (o, s) =>
                        {
                            foreach (string cmnd in cmnds) { 
                            await HandleCommands(cmnd);
                            }
                        };
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
                else if (command == "usrvars")
                {
                    foreach (var control in UserVariables)
                    {
                        await NewLine( UserVariables.IndexOf(control).ToString() + " : "+control.ToString(), null, null);
                    }
                }
                else if (command == "clear-usrvars")
                {
                    UserVariables.Clear();
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
           
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
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
}
