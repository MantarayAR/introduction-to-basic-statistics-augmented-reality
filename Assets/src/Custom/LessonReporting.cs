using System;
using UnityEngine;

public class LessonReporting : MonoBehaviour
{
	Slides slides = null;
	
	void Start ()
	{
		Slides slides = new Slides ("LessonReporting");

		slides.Add (new Slide (
			"Reporting Your Data\n\n" +
			"After a day of investigating fish, your boss wants you to report your findings to her. Let’s convert some of your findings to make it easier to understand."
		));
		
		// ----------------------- Question Slide 1 ---------------- //
		Slide qSlide = new Slide("");
		Question q = new Question();
		q.SetText("We have observed that 3 of 10 fish have been affected by pollution from one of our samples. How do we express that as a ratio of affected fish to not affected fish?");
		q.SetAnswers("3:7", "7:3", "1:3","7:1");
		q.SetRightAnswer("3:7");
		q.SetHint("Make sure to pay attention to the order of the numbers in the wording.");
		q.SetDescriptionOfRightAnswer("Correct. If we have 3 affected fish, then that means we have 7 not affected fish. Thus, the ratio is 3 to 7.");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //

		// ----------------------- Question Slide 2 ---------------- //
		qSlide = new Slide("");
		q = new Question();
		q.SetText("You observed that 20% of fish have been affected by pollution from the total of the two samples. How do you express this as a ratio of affected fish to not affected fish?");
		q.SetAnswers("1:5", "20:1", "2:5", "2:8");
		q.SetRightAnswer("2:8");
		q.SetHint("TMake sure to pay attention to the order of the numbers in the wording. Remember that percentages are different than ratios.");
		q.SetDescriptionOfRightAnswer("Correct. If we have 2 affected fish, then that means we have 8 not affected fish. Thus, the ratio is 2 to 8.");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //		

		slides.Add (new Slide (
			"Your boss appreciates your work! Converting your data to make it easy to understand is not very hard. However, your work is not done. "
			// TODO support histograms
			/*  + "Next, you will need to create a chart of your results..." */
		));



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
