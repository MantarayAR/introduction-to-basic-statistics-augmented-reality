using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour
{
	GUIStructure gui = null;

	// Use this for initialization
	void Start ()
	{
		// Bootstrap Assets
		Assets.GetInstance();
		
		// Create "Start a Lesson" Button
		GUIButton startALessonButton = new GUIButton();
		startALessonButton
			.SetText(GUIConst.startALessonText)
			.OnClick(FlowControl.GoToLessonScreen)
			.SetBox((new Box())
				.SetMarginTop (0.0f)
				.SetMarginRight (0.0f)
				.SetMarginBottom (0.70f)
				.SetMarginLeft (0.0f));
		
		// Create "Visit Mantaray AR Website" Button
		GUIButton getARTargets = new GUIButton();
		getARTargets
			.SetText(GUIConst.getARTargets)
			.OnClick(FlowControl.GetTargets)
			.SetBox((new Box())
				.SetMarginTop (0.35f)
				.SetMarginRight (0.0f)
				.SetMarginBottom (0.35f)
				.SetMarginLeft (0.0f));
		
		// Create "Visit Mantaray AR Website" Button
		GUIButton visitMantarayARWebsiteButton = new GUIButton();
		visitMantarayARWebsiteButton
			.SetText(GUIConst.visitMantarayARWebsiteText)
			.OnClick(FlowControl.GoToWebsite)
			.SetBox((new Box())
				.SetMarginTop (0.70f)
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
		
		// Build the GUI
		GUIFactory factory = new GUIFactory ();
		
		factory
			.Append(new GUIImage("splash-background"));
		
		((GUILabel)factory
			.CreateLabel ())
				.SetStyle (new GUIStyle())
				.SetBox ((new Box ())
					.SetMarginTop (0.1f)
					.SetMarginRight (0.05f)
					.SetMarginBottom ("auto")
					.SetMarginLeft (0.05f)
					.SetHeight (0.45f))
				.Append ((new GUIImage("splash-logo")).SetScaleMode(ScaleMode.ScaleToFit));
		
		factory
			.CreateContainer ()
				.SetBox ((new Box ())
					.SetMarginTop ("auto")
					.SetMarginRight (0.2f)
					.SetMarginBottom (0.1f)
					.SetMarginLeft (0.2f)
					.SetHeight (0.4f))
				.Append (startALessonButton)
				.Append (getARTargets)
				.Append (visitMantarayARWebsiteButton);
		
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
					
		gui = factory.Build();
	}
	
	
	void OnGUI () {
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
}
