using UnityEngine;
using log4net.Appender;
using log4net.Core;

public class Unity3DConsoleAppender : AppenderSkeleton{
	
	protected override void Append(LoggingEvent loggingEvent)
    {
		Debug.Log (loggingEvent.RenderedMessage);
	}
}
