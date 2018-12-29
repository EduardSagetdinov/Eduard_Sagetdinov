using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epam.Task6.BACKUP_SYSTEM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
            button3.Enabled = false;
        }

        public static string Paths { get; set; }

        public static string LogPath { get; set; }

        public static string NameDir { get; set; }

        public static string Pth { get; set; }

        public static string Recover { get; set; }
        
        public void Button1_Click(object sender, EventArgs e)
        {
            while (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show(text: "You haven't chosen some directory for observe!!!");
            }

            Paths = folderBrowserDialog1.SelectedPath;
            MessageBox.Show(text: $"You have chosen: {Paths}");
            this.fileSystemWatcher1.Path = Paths;
            fileSystemWatcher1.NotifyFilter = NotifyFilters.Size | NotifyFilters.FileName;
        }

        public void Button2_Click(object sender, EventArgs e)
        {
            while (folderBrowserDialog2.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show(text: "You haven't chosen some directory for logs!!!");
            }

            LogPath = folderBrowserDialog2.SelectedPath;
            MessageBox.Show(text: $"You logs will be in: {LogPath}");
            if (!File.Exists(Path.Combine(LogPath, "MainLog.txt")))
            {
                File.Create(Path.Combine(LogPath, "MainLog.txt"));
            }

            button1.Enabled = false;

            button2.Enabled = false;

            button3.Enabled = true;
        }

        public void FileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            string dir = Path.Combine(LogPath, Path.GetDirectoryName(e.Name));
            
                DirectoryInfo directoryInfo = new DirectoryInfo(dir);
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }

            string p = Path.Combine(LogPath, Path.GetDirectoryName(e.Name), Path.GetFileNameWithoutExtension(e.Name));
            this.MakingWithFile(e.FullPath, e.FullPath, p);
        }

        public void FileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            string oldName = Path.Combine(LogPath, Path.GetDirectoryName(e.Name), Path.GetFileNameWithoutExtension(e.OldName));
            string newName = Path.Combine(LogPath, Path.GetDirectoryName(e.Name), Path.GetFileNameWithoutExtension(e.Name));
            File.Move(oldName, newName);
            this.MakingWithFile(e.OldFullPath, e.FullPath, newName);
        }

        private void MakingWithFile(string oldName, string newName, string logPath)
        {
            fileSystemWatcher1.EnableRaisingEvents = false;
            string[] str;
            str = File.ReadAllLines(newName);
           
            using (StreamWriter sr = File.AppendText(logPath))
            {
                sr.WriteLine(oldName);
                sr.WriteLine(newName);
                foreach (var item in str)
                {
                    sr.WriteLine(item);
                }

                sr.WriteLine(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
                fileSystemWatcher1.EnableRaisingEvents = true;
            }
        }

        private void FileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
        {
        }

        private void FileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            string p = Path.Combine(LogPath, Path.GetDirectoryName(e.Name), Path.GetFileNameWithoutExtension(e.Name));
            string dir = Path.Combine(LogPath, Path.GetDirectoryName(e.Name));
            DirectoryInfo directoryInfo = new DirectoryInfo(dir);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            
            this.MakingWithFile(e.FullPath, e.FullPath, p);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            openFileDialog1.InitialDirectory = Paths;

            openFileDialog1.ShowDialog();
            Recover = openFileDialog1.FileName;
            if (Recover == "openFileDialog1")
            {
                MessageBox.Show(text: "You haven't chosen some file for backup!!!");
            }
            else
            {
                MessageBox.Show(Recover);
            }
        }
        
        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DateTime date = monthCalendar1.SelectionEnd.Date;
            TimeSpan time = dateTimePicker1.Value.TimeOfDay;
            DateTime fullDate = date.Add(time);
            
            string oldPath = openFileDialog1.FileName;
            string partPath = Recover.Substring(Paths.Length + 1);
            string loP = Path.Combine(LogPath, partPath.Substring(0, partPath.Length - 4));
            DateTime numb;
            this.fileSystemWatcher1.EnableRaisingEvents = false;
            Stack<string> lines = new Stack<string>();
            using (StreamReader reader = File.OpenText(loP))
            {
                string line;
                 while ((line = reader.ReadLine()) != null)
                 {
                    lines.Push(line);
                 }
            }
           
            while (lines.Count != 0)
            {
                string findDate = lines.Pop();
                
                if (DateTime.TryParse(findDate, out numb))
                {
                  if (Math.Abs(numb.Subtract(fullDate).TotalMinutes) < 2)
                    {
                      break;
                    }
                }
            }
            
            using (StreamWriter strWriter = File.CreateText(Path.Combine(LogPath, "back.txt")))
                {
                    while (lines.Count != 0)
                    {
                    string words = lines.Pop();
                    if (!words.Contains("txt"))
                        {
                        strWriter.WriteLine(words);
                        }
                        else
                        {
                        lines.Push(words);
                        break;
                        }
                    }
                }

            this.fileSystemWatcher1.EnableRaisingEvents = true;
            if (lines.Count != 0)
            {
                string backPath = lines.Pop();
                File.Delete(oldPath);
                File.Delete(loP);
                File.Move(Path.Combine(LogPath, "back.txt"), backPath);
                File.Delete(Path.Combine(LogPath, "back.txt"));
            }
            else
            {
                File.Delete(oldPath);
                File.Delete(loP);
                File.Delete(Path.Combine(LogPath, "back.txt"));
            }
            
            MessageBox.Show("Backuped!!!!");
        }
    }
}
