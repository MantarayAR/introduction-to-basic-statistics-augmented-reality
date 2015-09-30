using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FlowControl
{
	private static Slides currentSlides;
	private static string currentLesson = "";
	public static bool MenuState = false;
	public static GUIStructure gui;

	static FlowControl() {
		// Draw Panel
		
		// Draw buttons:
		// Create "Start a Lesson" Button
		GUIButton startALessonButton = new GUIButton();
		startALessonButton
			.SetText("Pick A Lesson")
				.OnClick(FlowControl.GoToLessonScreen)
				.SetBox((new Box())
				        .SetMarginTop (0.0f)
				        .SetMarginRight (0.0f)
				        .SetMarginBottom (0.80f)
				        .SetMarginLeft (0.0f));
		
		// Create "Visit Mantaray AR Website" Button
		GUIButton getARTargets = new GUIButton();
		getARTargets
			.SetText(GUIConst.getARTargets)
				.OnClick(FlowControl.GetTargets)
				.SetBox((new Box())
				        .SetMarginTop (0.25f)
				        .SetMarginRight (0.0f)
				        .SetMarginBottom (0.55f)
				        .SetMarginLeft (0.0f));
		
		// Create "Visit Mantaray AR Website" Button
		GUIButton visitMantarayARWebsiteButton = new GUIButton();
		visitMantarayARWebsiteButton
			.SetText(GUIConst.visitMantarayARWebsiteText)
				.OnClick(FlowControl.GoToWebsite)
				.SetBox((new Box())
				        .SetMarginTop (0.50f)
				        .SetMarginRight (0.0f)
				        .SetMarginBottom (0.30f)
				        .SetMarginLeft (0.0f));

		// Create "Return" Button
		GUIButton exitMenuButton = new GUIButton();
		exitMenuButton
			.SetText("Go Back")
				.OnClick(FlowControl.ExitMenu)
				.SetBox((new Box())
				        .SetMarginTop (0.75f)
				        .SetMarginRight (0.0f)
				        .SetMarginBottom (0.05f)
				        .SetMarginLeft (0.0f));
		
		// Build the GUI
		GUIFactory factory = new GUIFactory ();
		
		factory
			.Append(new GUIImage("dark-transparent-swatch").SetScaleMode(ScaleMode.StretchToFill));
		
		
		factory
			.CreateContainer ()
				.SetBox ((new Box ())
				         .SetMarginTop (0.2f)
				         .SetMarginRight (0.2f)
				         .SetMarginBottom (0.2f)
				         .SetMarginLeft (0.2f))
				.Append (startALessonButton)
				.Append (getARTargets)
				.Append (visitMantarayARWebsiteButton)
				.Append (exitMenuButton);
		
		FlowControl.gui = factory.Build();
	}

	public static void ExitMenu() {
		FlowControl.MenuState = false;
	}

	public static void DrawMenu(GameObject gameObject) {
		FlowControl.gui.OnGUI (gameObject);
	}

	public static void ShowHelpMenu () 
	{
		FlowControl.MenuState = true;
	}
	
	public static void GoToWebsite () 
	{
		FlowControl.MenuState = false;
		Application.OpenURL ("http://www.mantarayar.com");
	}
	
	public static void GoToLessonScreen ()
	{
		FlowControl.MenuState = false;
		Application.LoadLevel ("Lesson_Scene");
	}
	
	public static void GetTargets ()
	{
		FlowControl.MenuState = false;
		Application.OpenURL (GUIConst.targetsURL);
	}
	
	public static void ShowMainMenu ()
	{
		Application.LoadLevel ("Title_Scene");
	}
	
	public static void NextSlide()
	{
		FlowControl.MenuState = false;
		if (FlowControl.currentSlides != null)
		{
			FlowControl.currentSlides.NextSlide();
		}
	}
	
	public static void SetCurrentSlides(Slides s)
	{
		FlowControl.currentSlides = s;
	}

	public static Slides GetCurrentSlides()
	{
		return FlowControl.currentSlides;
	}
	
	public static void PreviousSlide()
	{
		FlowControl.MenuState = false;
		if (FlowControl.currentSlides != null)
		{
			FlowControl.currentSlides.PreviousSlide();
		}
		
	}
	
	public static void NextLesson()
	{
		FlowControl.MenuState = false;
		List<Lesson> lessons = CustomLessons.GetInstance().GetLessons();
		
		int index = -1;
		
		for (int i = 0; i < lessons.Count; i++)
		{
			if (lessons[i].GetSceneName().Equals (currentSlides.GetSceneName())) {
				index = i;
				break;
			}
		}
		
		if (index != -1 && index + 1 < lessons.Count)
		{
			//FlowControl.SetLesson(lessons[index+1].GetSceneName());
			//Application.LoadLevel ("Lesson_Loader");
			GoToLessonScreen();
		} else {
			GoToLessonScreen();
		}
		
	}
	
	public static void PreviousLesson()
	{
		/*List<Lesson> lessons = CustomLessons.GetInstance().GetLessons();
		
		int index = -1;
		
		for (int i = 0; i < lessons.Count; i++)
		{
			if (lessons[i].GetSceneName().Equals (currentSlides.GetSceneName())) {
				index = i;
				break;
			}
		}
		
		if (index != -1 && index - 1 >= 0 )
		{
			Application.LoadLevel (lessons[index-1].GetSceneName());
		} else {*/
		FlowControl.MenuState = false;
			GoToLessonScreen();
		//}
	}

	public static void SetLesson(string lessonName) {
		FlowControl.currentLesson = lessonName;
	}

	public static string GetLesson() {
		return FlowControl.currentLesson;
	}
}

