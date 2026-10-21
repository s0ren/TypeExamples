using System;
using System.Collections.Generic;
using System.Text;

namespace TypeExamples
{
    public class UserFolderSaver : Saver
    {
        public override void Save(string content)
        {
            //// Source - https://stackoverflow.com/a/19329696
            //// Posted by xxbbcc, modified by community. See post 'Timeline' for change history
            //// Retrieved 2026-10-18, License - CC BY-SA 3.0

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            path = Path.Combine(path, "typedemo_03.txt");

            File.AppendAllText(path, $"\n{content}");
        }
    }
}
