using System;

public class ProjectFolderSaver : Saver
{
    public override void Save(string content)
    {
        string path = @"../../../";
        //string filename = "typedemo_03.txt";

        path = Path.GetFullPath(path);
        string path_file = Path.Combine(path, this.filename);
        
        Console.WriteLine($"Gemmer {content} i {path_file}");
        File.WriteAllText(path + filename, content);
    }
}

