using System;
using UnityEngine;


public class LessonVariability : MonoBehaviour 
{
	Slides slides = null;
	
	
	void Start ()
	{
		Slides slides = new Slides("LessonVariability");
		
		// Talk about how data points differ from each other
		slides.Add (new Slide (
			"Variability\n\n" +
			"Variability is how \"spread out\" a group of data points are. It is a way of expressing how data points differ from each other."
		));

		// Talk about different kinds of variability: Range, mean, variance, and standard deviation.
		slides.Add(new Slide(
			"There are different ways of measuring variability: range, mean, variance, and standard deviation."
		));

		// Range
		slides.Add(new Slide(
			"Range is a measure of how far apart the furthest data points are from each other, and it is the simplest measure of variability to calculate.\n\n" + 
			"Simply take the largest data point and subtract the value of the lowest data point.\n\n" +
			"Take the group of numbers 2, 4, 6. The range is 6 - 2, which is 4."
		));

		// Mean
		slides.Add(new Slide(
			"The mean is a measure of what the average data point is.  Simply sum all of your data points and divide by the number of data points you have.\n\n" + 
			"Take the group of numbers 2, 4, 6. The average is (2 + 4 + 6) / 3, which is 4."
		));

		// Variance
		slides.Add(new Slide(
			"Variance is a measure of how close the data points are to the average.\n\n" + 
			"To calculate the variance, you will need the means from the sample.\n\n" +
			"Then, subtract the data point from that mean, and square the result (the squared difference). Then work out the average of those squared differences."
		));

		slides.Add (new Slide (
			"Take the group of numbers 2, 4, 6. First, calculate the mean of these numbers, (2 + 4 + 6)/3 = 6.\n\n" + 
			"The variance of these three numbers is the difference from the mean squared deviation from this average." +
			"These deviations are (2–6) = –4, (4–6) = –2, (6–6) = 0.\n\n" +
			"Thus the variance of the four numbers is [(2 – 4)2 + (4 - 4) 2 + (6 - 4) 2]/3 = [(-2) 2 + (0) 2 + (2) 2 ]/3 = (4 + 0 + 4) / 3 = 8/3 = 2.67"
		));


		// TODO Talk about histograms, what they are

		// TODO Talk about histograms, how to read them
		
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
