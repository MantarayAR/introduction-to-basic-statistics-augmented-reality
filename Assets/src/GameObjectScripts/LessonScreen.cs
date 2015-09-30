using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LessonScreen : MonoBehaviour {
	
	GUIStructure gui = null;
	
	// Use this for initialization
	void Start () 
	{
		// Create a list of lessons
		List<Lesson> lessons = CustomLessons.GetInstance().GetLessons();
		
		// Create Go Back to Menu Button
		GUIButton goBack = new GUIButton ();
		goBack
			.SetText("Go Back to Main Menu")
			.OnClick(FlowControl.ShowMainMenu)
				.SetBox((new Box())
				.SetMarginTop (0.0f)
				.SetMarginRight (0.0f)
				.SetMarginBottom (0.0f)
				.SetMarginLeft (0.0f));
		
		// Create "Help" Button
		GUIButton helpButton = new GUIButton ();
		helpButton
			.SetText(GUIConst.helpButtonText)
			.OnClick(FlowControl.ShowHelpMenu)
				.SetBox((new Box())
				.SetMarginTop (0.0f)
				.SetMarginRight (0.0f)
				.SetMarginBottom (0.0f)
				.SetMarginLeft (0.0f));
		
		GUIFactory factory = new GUIFactory ();
		
		factory
			.Append(new GUIImage("splash-background"));
		
		// Attach them to a "Lesson Scroll Area"
		factory
			.CreateScrollArea ()
				.SetBox((new Box())
					.SetMarginBottom(0.1f)
					.SetMarginTop(0.1f)
					.SetMarginLeft(0.1f)
					.SetMarginRight(0.1f))
				.Append(new GUILessonList(lessons));
		
		factory.CreateContainer()
			.SetBox ((new Box())
				.SetMarginTop ("auto")
				.SetMarginLeft ("5px")
				.SetMarginBottom ("5px")
				.SetMarginRight ("auto")
				.SetHeight (0.08f)
				.SetWidth(0.4f)).Append (goBack);
		
		factory
			.CreateContainer ()
				.SetBox ((new Box())
					.SetMarginTop ("auto")
					.SetMarginLeft ("auto")
					.SetMarginBottom ("5px")
					.SetMarginRight ("5px")
					.SetHeight (0.08f)
					.SetWidth("32px"))
				.Append(helpButton);
	
		// Build
		gui = factory.Build();
	}
	
	void OnGUI () 
	{
		if (FlowControl.MenuState) {
			GUI.enabled = false;
		}
		
		gui.OnGUI(gameObject);
		
		if (FlowControl.MenuState) {
			GUI.enabled = true;
		}
		
		if (FlowControl.MenuState) {
			FlowControl.DrawMenu(gameObject);
		}

	}
	
	void Update () 
	{
		gui.Update(gameObject);
	}
	
}
