using System.Diagnostics;
using System.Net;

namespace Shinterface
{
    public partial class Form1 : Form
    {
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
            string command = input.Trim();
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
                        string link = command.Substring(10);
                        await NewLine("Running script: " + link, Color.LightSkyBlue, null);
                        string[] lines = File.ReadAllLines(link);
                        
                        foreach (string line in lines) { 
                        await HandleCommands(line);
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
                else
                {
                    await NewLine($"The command '{command}' is not recognized as a command!", Color.Red, Color.White);
                }
                textBox1.Text = string.Empty;

            }
        }

        private async Task NewLine(string text, Color? front, Color? back)
        {
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
            flowLayoutPanel1.Controls.SetChildIndex(textBox1, flowLayoutPanel1.Controls.Count);
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
