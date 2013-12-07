/// <summary>
/// Scene manager. This is intended to be a singleton class.
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using log4net.Config;

public class SceneManager : MonoBehaviour {
	
	public static SceneManager Manager;
	
	public List<IHasGameFrame> GameFrameObjects;
	
	void Awake() {
		SetupLog ();
		Manager = this;
		GameFrameObjects = new List<IHasGameFrame>();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/// <summary>
	/// Reads in the log configuration for log4net.
	/// </summary>
	void SetupLog() {
		
		object obj = Resources.Load ("logConfig");
		if(obj != null) {
			TextAsset configText = obj as TextAsset;
			if(configText != null) {
				MemoryStream memStream = new MemoryStream(configText.bytes);
				XmlConfigurator.Configure(memStream);	
			}
		}
	}
}
