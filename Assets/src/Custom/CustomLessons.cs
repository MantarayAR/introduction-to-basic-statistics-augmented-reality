using System;
using System.Collections;
using System.Collections.Generic;

/**
 * Custom Lesson Class.  Put the custom lessons here.  Just add it to the list!  The list is ORDERED!
 */
public class CustomLessons
{
	private List<Lesson> customLessons = new List<Lesson>();
	private static CustomLessons instance;
	
	/**
	 * Private Constructor, Singleton class.
	 * The lessons are only added once.
	 */
	private CustomLessons ()
	{
		this.customLessons.Add(new Lesson(
			"LessonIntroduction", "Introduction to Probability and Sampling"
		));

		this.customLessons.Add(new Lesson(
			"LessonSampling", "Sampling"
		));

		this.customLessons.Add(new Lesson(
			"LessonSamplePractice", "Exercise 1: Practice Taking a Sample"
		));

		this.customLessons.Add (new Lesson (
			"LessonProbability", "Probability"
		));

		this.customLessons.Add(new Lesson(
			"LessonProbabilityPractice", "Exercise 2: Discovering Probability"
		));

		this.customLessons.Add (new Lesson (
			"LessonVariability", "Variability"
		));

		this.customLessons.Add (new Lesson (
			"LessonExploringVariability", "Exercise 3: Exploring Variability"
		));

		this.customLessons.Add(new Lesson(
			"LessonReporting", "Reporting and Understanding Data"
		));

		this.customLessons.Add (new Lesson (
			"LessonReview", "Review"
		));

		this.customLessons.Add(new Lesson(
			"LessonCheckYourKnowledge", "Check Your Knowledge"
		));
	}
	
	/**
	 * Get the Singleton instance of CustomLessons
	 */
	public static CustomLessons GetInstance()
	{
		if (CustomLessons.instance == null)
		{
			CustomLessons.instance = new CustomLessons();
		}
		
		return CustomLessons.instance;
	}
	
	/**
	 * Get the list of custom lessons
	 */
	public List<Lesson> GetLessons()
	{
		return this.customLessons;
	}
}


