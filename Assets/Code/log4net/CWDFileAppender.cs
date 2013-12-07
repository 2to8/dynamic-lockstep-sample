using UnityEngine;
using log4net.Appender;
using System.IO;

class CWDFileAppender : FileAppender
{
    public override string File
    {
        set
        {
			string path;
			if(Application.isEditor) {
				path = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
			} else {
				path = Path.Combine(Application.dataPath, "Logs");
				//uncomment for persistent storage of logs
				//path = Path.Combine(Application.persistentDataPath, "Logs");
			}
            base.File = Path.Combine(path, value);
        }
    }
}
