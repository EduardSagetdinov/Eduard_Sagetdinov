using System;
using System.IO;
using System.Threading;

namespace IRO.Task.BackupSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = null;
            if (args.Length > 1)
            {
                logger = new Logger(args[0], args[1]);
            }
            else if (args.Length > 0)
            {
                logger = new Logger(args[0]);
            }
            else
            {
                Console.WriteLine("Using:\nITO.Task.BackupSystem.exe [path] [backupPath]");
                return;
            }
            logger.Start();
        }
    }

    class Logger
    {
        FileSystemWatcher watcher;
        bool enabled = true;
        string backupDir;
        object obj = new Object();

        public Logger(string Path, string BackupPath = @".\backup\")
        {
            watcher = new FileSystemWatcher(Path);
            watcher.Deleted += Watcher_Deleted;
            watcher.Created += Watcher_Created;
            watcher.Changed += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;
            watcher.IncludeSubdirectories = true;
            backupDir = BackupPath;
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (IsBackupPath(e.FullPath))
                return;
            string pathType = GetPathType(e.FullPath);
            if (pathType == "file")
                Backup(e.FullPath, e.OldFullPath);
            Log("renamed into " + e.FullPath, e.OldFullPath, pathType);
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (IsBackupPath(e.FullPath))
                return;
            string pathType = GetPathType(e.FullPath);
            if (pathType == "file")
                Backup(e.FullPath);
            Log("changed", e.FullPath, pathType);
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            if (IsBackupPath(e.FullPath))
                return;
            string pathType = GetPathType(e.FullPath);
            if (pathType == "file")
                Backup(e.FullPath);
            Log("created", e.FullPath, pathType);
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (IsBackupPath(e.FullPath))
                return;
            string pathType = "file or folder";
            Log("deleted", e.FullPath, pathType);
        }

        private void Log(string fileEvent, string filePath, string pathType)
        {
            var dateTime = DateTime.Now;
            Console.WriteLine($"{dateTime.ToString()} {pathType} {filePath} was {fileEvent}.");
        }

        private void Backup(string filePath, string oldFilePath = null)
        {
            int i = 0;
            var dateTime = DateTime.Now;

            var dir = Path.GetDirectoryName(filePath);
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var fileExtension = Path.GetExtension(filePath);

            var oldFileName = Path.GetFileNameWithoutExtension(oldFilePath);
            var oldFileExtension = Path.GetExtension(oldFilePath);

            string newPath = null;
            string newDir = backupDir + $"{dateTime.Year}\\{dateTime.Month}\\{dateTime.Day}\\"; ;

            if (oldFilePath != null)
                newPath = newDir + $"{fileName}-{oldFileName}({oldFileExtension})";
            else
                newPath = newDir + $"{fileName}";

            var isWritten = false;

            do
            {
                try
                {
                    Directory.CreateDirectory(newDir);
                    File.Copy(filePath, newPath + (i == 0 ? null : $"({i})") + fileExtension);
                    isWritten = true;
                }
                catch (IOException)
                {
                    i++;
                }
            }
            while (!isWritten);
        }

        private string GetPathType(string path)
        {
            string pathType = "file";
            if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                pathType = "folder";
            return pathType;
        }

        private bool IsBackupPath(string path)
        {
            return Path.GetFullPath(path).Contains(Path.GetFullPath(backupDir));
        }
    }
}
