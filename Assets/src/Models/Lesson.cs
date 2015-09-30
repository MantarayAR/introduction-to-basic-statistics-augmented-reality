using System;
using UnityEngine;


public class Lesson
{
	private string sceneName;
	private string lessonName;
	private COMPLETEDNESS completedness = COMPLETEDNESS.NOT_STARTED;
	
	public Lesson (string sceneName, string lessonName)
	{
		this.sceneName = sceneName;
		this.lessonName = lessonName;

		int i = PlayerPrefs.GetInt (sceneName, -1);

		if (i == -1) {
			completedness = COMPLETEDNESS.NOT_STARTED;
		} else if (i == 0) {
			completedness = COMPLETEDNESS.IN_PROGRESS;
		} else if (i == 1) {
			completedness = COMPLETEDNESS.COMPLETE;
		}
	}
	
	public string GetLessonName()
	{
		return this.lessonName;
	}
	
	public string GetSceneName()
	{
		return this.sceneName;
	}
	
	public COMPLETEDNESS GetCompletedness ()
	{
		int i = PlayerPrefs.GetInt (sceneName, -1);
		
		if (i == -1) {
			completedness = COMPLETEDNESS.NOT_STARTED;
		} else if (i == 0) {
			completedness = COMPLETEDNESS.IN_PROGRESS;
		} else if (i == 1) {
			completedness = COMPLETEDNESS.COMPLETE;
		}
		return this.completedness;
	}
	
	public enum COMPLETEDNESS 
	{
		COMPLETE,
		IN_PROGRESS,
		NOT_STARTED
	};
}


