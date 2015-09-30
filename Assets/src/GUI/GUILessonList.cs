using UnityEngine;
using System;
using System.Collections.Generic;

public class GUILessonList : GUIComponent
{
	private const int bufferSize = 5;
	private List<Lesson> lessons;
	private float buttonHeight;
	private GUIStyle guiStyle = new GUIStyle();
	
	public GUILessonList (List<Lesson> lessons)
	{
		this.lessons = lessons;
		this.guiStyle = GUIStyles.GetInstance().DEFAULT_LESSON_BUTTON_STYLE;
	}
	
	public override float RequestEstimatedHeight()
	{
		CalculateButtonHeight();
		
		return (this.buttonHeight + GUILessonList.bufferSize) * this.lessons.Count;
	}
	
	private void CalculateButtonHeight()
	{
		this.buttonHeight = Screen.height * 0.1f;
	}
	
	public override void OnGUI (GameObject gameObject)
	{
		// No need to call base
		// base.OnGUI (gameObject);
		
		Rect parentField = GetParentField();
		
		float margin = parentField.width * 0.05f;
		
		for (int i = 0; i < lessons.Count; i++)
		{
			Rect cR = new Rect(margin, i * (this.buttonHeight + GUILessonList.bufferSize), parentField.width - 2 * margin, this.buttonHeight);
			Rect imageRect = new Rect(
				parentField.width - 2 * margin, 
				i * (this.buttonHeight + GUILessonList.bufferSize) + this.buttonHeight * 0.25f, 
				this.buttonHeight * 0.5f, 
				this.buttonHeight * 0.5f);
			
			Texture tImage = GUIStyles.GetInstance().COMPLETED_SWATCH;
			Lesson lesson = lessons[i];
			switch ( lesson.GetCompletedness() )
			{
			case Lesson.COMPLETEDNESS.COMPLETE:
				tImage = GUIStyles.GetInstance().COMPLETED_SWATCH;
				break;
			case Lesson.COMPLETEDNESS.IN_PROGRESS:
				tImage = GUIStyles.GetInstance().IN_PROGRESS;
				break;
			default:
				tImage = GUIStyles.GetInstance().NOT_COMPLETED;
				break;
			}
			
			
			if (GUI.Button (cR, lesson.GetLessonName(), this.guiStyle))
			{
				SoundUtil.getInstance().buttonPlay(gameObject);

				FlowControl.SetLesson(lesson.GetSceneName());
				Application.LoadLevel ("Lesson_Loader");
			}
			
			// TODO show whether completed or not
			GUI.Label(imageRect, tImage);
		}
		
	}
}


