using System;
using UnityEngine;


public class LessonAboutThisApp : MonoBehaviour 
{
	Slides slides = null;
	
	
	void Start ()
	{
		Slides slides = new Slides("LessonAboutThisApp");
		
		
		slides.Add(new Slide(
			"To advance through the lessons, use the \"continue\" and \"go back\" buttons. You can return to the Main Menu by clicking \"Go back to Main Menu\"."
		));
		
		slides.Add(new Slide(
			"This application requires you to download a set of images for the Augmented Reality part of the game. You can download these images by clicking on \"Get the AR Targets for These Lessons\" from the main menu or by visiting our website at http://studysessions.mantarayar.com/."
		));
		
		this.slides = slides;
	}
	
	void OnGUI () 
	{
		slides.OnGUI(gameObject);
	}
	
	void Update () 
	{
		slides.Update(gameObject);
	}
}
