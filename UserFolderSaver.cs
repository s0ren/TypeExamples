using System;
using System.ComponentModel;


public class UserFolderSaver : Saver
{
    public UserFolderSaver() : base()
    {
        // Source - https://stackoverflow.com/a/19329696
        // Posted by xxbbcc, modified by community. See post 'Timeline' for change history
        // Retrieved 2026-10-18, License - CC BY-SA 3.0

        //string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string path = "C:\\Users\\smag"; // Sørens hjemme mappe
        this.savePath = path;
    }

}

