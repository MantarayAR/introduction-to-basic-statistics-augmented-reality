using System;
using System.Collections.Generic;
using UnityEngine;

public class Slides
{
	private List<Slide> slides;
	private GUIStructure gui;
	private GUIStructure guiNoBackground;
	private int index = 0;
	private string currentSceneName;
	
	public Slides (string currentSceneName)
	{
		this.currentSceneName = currentSceneName;
		this.slides = new List<Slide>();
		
		
		
		// -------------------------   Build no background ------------------------ \\
		// Create Go Back to Menu Button
		GUIButton goBack = new GUIButton ();
		goBack
			.SetText(GUIConst.goBack)
			.OnClick(FlowControl.GoToLessonScreen)
				.SetBox((new Box())
				.SetMarginTop (0.0f)
				.SetMarginRight (0.0f)
				.SetMarginBottom (0.0f)
				.SetMarginLeft (0.0f));
		
		GUIFactory factory = new GUIFactory ();
		
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
		
		
		guiNoBackground = factory.Build();
		// ------------------------------------------------------------------------ //
		// -------------------------   Build Regular GUI -------------------------- \\
		// Create Go Back to Menu Button
		goBack = new GUIButton ();
		goBack
			.SetText(GUIConst.goBack)
			.OnClick(FlowControl.GoToLessonScreen)
				.SetBox((new Box())
				.SetMarginTop (0.0f)
				.SetMarginRight (0.0f)
				.SetMarginBottom (0.0f)
				.SetMarginLeft (0.0f));
		
		factory = new GUIFactory ();
		
		// Create "Help" Button
	    helpButton = new GUIButton ();
		helpButton
			.SetText(GUIConst.helpButtonText)
			.OnClick(FlowControl.ShowHelpMenu)
				.SetBox((new Box())
				.SetMarginTop (0.0f)
				.SetMarginRight (0.0f)
				.SetMarginBottom (0.0f)
				.SetMarginLeft (0.0f));
		
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
		
		factory
			.Prepend(new GUIImage("splash-background"));
		
		// Build
		gui = factory.Build();
		
		
		FlowControl.SetCurrentSlides(this);
	}
	
	public void Add(Slide s)
	{
		this.slides.Add(s);
		
	}
	
	public void OnGUI(GameObject gameObject)
	{
		if (CurrentSlide().GetSlideState() == Slide.SlideState.AR)
		{
			guiNoBackground.OnGUI(gameObject);
		}
		else
		{
			gui.OnGUI (gameObject);
		}
		
		
		CurrentSlide().OnGUI(gameObject);	
	}
	
	public void Update(GameObject gameObject)
	{
		CurrentSlide().Update(gameObject);
		
		gui.Update(gameObject);
	}
	
	public Slide CurrentSlide ()
	{
		if (this.index < 0) {
		 	FlowControl.PreviousLesson();
			return new Slide("");
		}
		else if (this.index < slides.Count)
			return slides[this.index];
		else if (this.index == slides.Count)
			return this.DefaultSlide();
		else {
			FlowControl.NextLesson();
			return new Slide("");
		}
	}
	
	public void NextSlide() 
	{
		this.index++;
	}
	
	public void PreviousSlide() 
	{
		this.index--;

		if (CurrentSlide ().GetSlideState () == Slide.SlideState.DONE) {
			this.slides[index] = new Slide(CurrentSlide ());
			this.slides[index].Setup();
		}
	}
	
	public Slide DefaultSlide ()
	{
		// Mark this lesson as complete
		PlayerPrefs.SetInt (this.currentSceneName, 1);
		PlayerPrefs.Save ();

		return new Slide("You have completed this lesson!  Click continue to go to the next lesson.");
	}
	
	public string GetSceneName()
	{
		return this.currentSceneName;
	}
}