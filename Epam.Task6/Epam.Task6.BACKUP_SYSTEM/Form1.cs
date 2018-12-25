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

        public static string Path { get; set; }

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

            Path = folderBrowserDialog1.SelectedPath;
            MessageBox.Show(text: $"You have chosen: {Path}");
            this.fileSystemWatcher1.Path = Path;
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
            if (!File.Exists(System.IO.Path.Combine(LogPath, "MainLog.txt")))
            {
                File.Create(System.IO.Path.Combine(LogPath, "MainLog.txt"));
            }

            button1.Enabled = false;

            button2.Enabled = false;

            button3.Enabled = true;
        }

        public void FileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            string dir = System.IO.Path.Combine(LogPath, System.IO.Path.GetDirectoryName(e.Name));
            
                DirectoryInfo directoryInfo = new DirectoryInfo(dir);
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }

            string p = System.IO.Path.Combine(LogPath, System.IO.Path.GetDirectoryName(e.Name), System.IO.Path.GetFileNameWithoutExtension(e.Name));
            MakingWithFile(e.FullPath, e.FullPath, p);
        }

        public void FileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            string oldName = System.IO.Path.Combine(LogPath, System.IO.Path.GetDirectoryName(e.Name), System.IO.Path.GetFileNameWithoutExtension(e.OldName));
            string newName = System.IO.Path.Combine(LogPath, System.IO.Path.GetDirectoryName(e.Name), System.IO.Path.GetFileNameWithoutExtension(e.Name));
            File.Move(oldName, newName);
            MakingWithFile(e.OldFullPath, e.FullPath, newName);
        }

        private static void MakingWithFile(string oldName, string newName, string logPath)
        {
            string[] str;
            Thread.Sleep(1000);
            str = File.ReadAllLines(newName);
            Thread.Yield();
            using (StreamWriter sr = File.AppendText(logPath))
            {
                sr.WriteLine(oldName);
                sr.WriteLine(newName);
                foreach (var item in str)
                {
                    sr.WriteLine(item);
                }

                sr.WriteLine(DateTime.Now.ToString("yyyyMMddhhmm"));
            }
        }

        private void FileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
        {
        }

        private void FileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            string p = System.IO.Path.Combine(LogPath, System.IO.Path.GetDirectoryName(e.Name), System.IO.Path.GetFileNameWithoutExtension(e.Name));
            string dir = System.IO.Path.Combine(LogPath, System.IO.Path.GetDirectoryName(e.Name));
            DirectoryInfo directoryInfo = new DirectoryInfo(dir);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            MakingWithFile(e.FullPath, e.FullPath, p);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            openFileDialog1.InitialDirectory = Path;

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
            string date = monthCalendar1.SelectionEnd.ToString("yyyyMMdd");
            string time = dateTimePicker1.Value.TimeOfDay.ToString("hhmm");
            string fullDate = string.Concat(date, time);
            long fromPicker = long.Parse(fullDate);
            string oldPath = openFileDialog1.FileName;
            string partPath = Recover.Substring(Path.Length + 1);
            string loP = System.IO.Path.Combine(LogPath, partPath.Substring(0, partPath.Length - 4));
            long numb;
            long min = 200;
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
                if (long.TryParse(lines.Pop(), out numb))
                {
                    if (Math.Abs(numb - fromPicker) < min)
                    {
                        min = numb;
                    }
                }

                break;
            }

            while (lines.Count != 0)
            {
                using (StreamWriter strWriter = File.CreateText(System.IO.Path.Combine(LogPath, "back.txt")))
                {
                    string words = lines.Pop();
                    if (!words.Contains(".txt"))
                    {
                        strWriter.WriteLine(words);
                    }
                }

                break;
            }

            string backPath = lines.Pop();
            File.Delete(oldPath);
            File.Move(System.IO.Path.Combine(LogPath, "back.txt"), backPath);
            MessageBox.Show("Backuped!!!!");
        }
    }
}
