using System;
using UnityEngine;

public class LessonProbability : MonoBehaviour
{
	Slides slides = null;
	
	void Start ()
	{
		slides = new Slides ("LessonProbability");

		slides.Add (new Slide (
			"What is Probability?\n\nProbability deals with chance."
		));

		slides.Add(new Slide(
			"Whenever you ask yourself \"what is the chance that I will roll a 2 on a six-sided dice\" or a similar question, you are dealing with probability. Probability is the chance of something happening."
		));

		slides.Add (new Slide (
			"In this lesson, you will learn what probability is, how to use it, and some of the related vocabulary associated with it. Click \"continue\" to get started."
		));

		slides.Add (new Slide(
			"What is probability?\n\n" +
			"Probability is the extent to which something is probable; the likelihood of something happening or being the case."
		));

		slides.Add (new Slide (
			"Fractions, Decimals, and Percentages\n\n" +
			"So far, we have expressed probability in the form of a percentage. However, probability can be expressed in the form of ratios and fractions."
		));

		slides.Add (new Slide(
			"Ratios\n\n" +
			"We'll first talk about ratios. A ratio is a comparison often expressed in the form of two numbers with a colon in between like 1:2 or 3:4. " +
			"These are read as \"1 to 2\" or \"3 to 4\", and referred to as \"the odds of an event occurring.\""
		));

		slides.Add (new Slide (
			"Let's look at an example. If we have 3 sick fish out of 10, we would say that 30% of the fish are sick.\n\n" +
			"With ratios however, you compare the sick fish to the not sick fish. The ratio of sick fish to healthy fish is 3:7 (read as 3 to 7). In other words, the odds that a fish is affected from this sample is 3 to 7."
		));

		slides.Add (new Slide(
			"While confusing at first, ratios are commonly used in everyday life. For instance, a cake recipe may call for \"3 parts flour to 1 part milk\", or in other words, 75% flour to 25 % milk."
		));

		slides.Add (new Slide(
			"It is much easier to multiply amounts using ratios than percentages. If you wanted to make two batches of the cake recipe, you could simply multiply the ratio by two to get 6 parts flour to 2 parts milk, or 6:2."
		));
	
		slides.Add (new Slide(
			"Now that we have discussed probability, you are ready for the next lesson. Tap “continue” to go to the next lesson."
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
