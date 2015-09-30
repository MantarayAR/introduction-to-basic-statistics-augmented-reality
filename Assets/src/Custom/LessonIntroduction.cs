using System;
using UnityEngine;

public class LessonIntroduction : MonoBehaviour
{
	protected Slides slides = null;
	
	// Use this for initialization
	void Start ()
	{
		slides = new Slides ("LessonIntroduction");

		slides.Add (new Slide (
			"Welcome to Introduction to Basic Statistics!"
		));
		
		slides.Add (new Slide (
			//"Whenever you ask yourself \"What is the chance that I will roll a two on a six-sided dice\" or similar questions you are dealing with probability."
			"This application's purpose is to teach and reinforce the basic concepts of sampling, probability and variance through Augmented Reality."
		));
		
		slides.Add (new Slide (
			"In these lessons, we will explore what probability is, how to express it, and identifying some probabilities through an augmented reality investigation."
		));

		slides.Add (new Slide (
			"To advance through the lessons, use the \"continue\" and \"go back\" buttons. You can return to the Main Menu by clicking \"Go back to Main Menu\"."
		));
		
		slides.Add (new Slide (
			"This application requires you to download a set of images for the Augmented Reality part of the game.\n\n" +
			"You can download these images by clicking on \"Get the AR Targets for These Lessons\" from the main menu or by visiting our website at http://studysessions.mantarayar.com/."
		));

		slides.Add (new Slide(
			"In order to get the most out of this mobile application, you should have a firm understanding of basic math skills such as:\n" +
			"\u2022 Addition\n" +
			"\u2022 Subtraction\n" +
			"\u2022 Multiplication\n" +
			"\u2022 Division\n" +
			"\u2022 Fractions"
		));
		
		
		slides.Add (new Slide(
			"Upon completion of this course, you will be able to:\n" + 
			"\u2022 Obj 1: Build and describe a sample\n" + 
			"\u2022 Obj 2: Calculate a probability of a sample\n" + 
			"\u2022 Obj 3: Recognize the variability between samples\n" + 
			"\u2022 Obj 4: Describe the effect of sample size on how well a sample resembles a population\n" + 
			"\u2022 Obj 5: Explain the differences between sample and population distributions\n"
		));
	}
	
	void OnGUI ()
	{
		slides.OnGUI (gameObject);
	}
	
	void Update ()
	{
		slides.Update (gameObject);
	}
}

