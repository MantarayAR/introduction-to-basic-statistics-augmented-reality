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
			"Take the group of numbers 2, 4, 6. The range is 6 - 4, which is 2."
		));

		// Mean
		slides.Add(new Slide(
			"The mean is a measure of what the average data point is.  Simply sum all of your data points and divide by the number of data points you have.\n\n" + 
			"Take the group of numbers 2, 4, 6. The average is (2 + 4 + 6) / 2, which is 4."
		));

		// Variance
		slides.Add(new Slide(
			"Variance is a measure of how close the data points are to the average.\n\n" + 
			"To calculate the variance, you will need the mean, μ (pronounced \"mu\").\n\n" +
			"Then take each point and substract μ from it. Square these values and add them all together. Then divide by the number of data points."
		));

		slides.Add (new Slide (
			"Take the group of numbers 2, 4, 6. The average is (2 + 4 + 6) / 2, which is 4.\n\n" + 
			"Then, we subtract μ from each value, and square the result: (2 - 4)*(2 - 4), (4 - 4)*(4 - 4), and (6 - 4)*(6 - 4).\n\n" +
			"We then take the sum of the squares, and divide by the number of data points: (2 + 0 + 2)/3 = 1.333"
		));

		// Variance continued
		slides.Add(new Slide(
			"The equation to calculate variance (σ²) is: ∑(X - μ)²/N.\n\n" + 
			"Where X is the value of each data point, N is the number of data points, and ∑ means sum all of the values (X - μ)² for each data point."
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
