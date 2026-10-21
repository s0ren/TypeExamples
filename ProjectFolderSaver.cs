using System;
using System.Collections.Generic;
using System.Text;

namespace TypeExamples
{
    public class ProjectFolderSaver : Saver
    {
        public override void Save(string content) 
        {
            string path = @"..\..\..\";

            path = Path.Combine(path, "typedemo_03.txt");

            File.AppendAllText(path, $"\n{content}");
        }
    }
}
