using System;

public class Saver
{
	string savePath { get; set; } = @"..\..\..";

    public Saver() { }

	public Saver(string savePath)
	{
		this.savePath = savePath;
	}

	public virtual void Save(string content)
    {
        File.WriteAllText(savePath, content);
    }	
}
