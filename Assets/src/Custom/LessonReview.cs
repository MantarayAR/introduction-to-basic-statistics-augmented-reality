using System;
using UnityEngine;

public class LessonReview : MonoBehaviour
{
	Slides slides = null;
	
	void Start ()
	{
		Assets assets = Assets.GetInstance ();
		Slides slides = new Slides ("LessonReview");

		slides.Add (new Slide (
			"Review\n\n" +
			"In the previous lessons, we have learned that probability is the chance of an event occurring."
		));

		slides.Add (new Slide (
			"By tallying fish, we can determine what percentage of fish have been affected by pollution. That is called sampling."
		));
				
		slides.Add (new Slide (
			"By using that percentage, we can make a guess at the probability on a larger scale without having to tally every fish possible."
		));

		slides.Add (new Slide (
			"Probabilities can be expressed in different ways such as fractions, ratios and percentages.\n\n" +
			"The following calculations are all the same representation of the same probability:\n" +
			"\u2022 1/3\n" +
			"\u2022 1:2\n" +
			"\u2022 33%"
		));

		slides.Add (new Slide (
			"We can measure variability between our samples by using different measurements of the \"spread\" of our data.\n\n" +
			"The following are some ways to measure variability:\n" +
			"\u2022 Range\n" +
			"\u2022 Mean\n" +
			"\u2022 Variance"
		));


		// TODO [Something about reading histograms]
		
		this.slides = slides;
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
