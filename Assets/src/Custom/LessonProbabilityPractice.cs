using System;
using UnityEngine;


public class LessonProbabilityPractice : MonoBehaviour 
{
	Slides slides = null;
	
	void Start ()
	{
		slides = new Slides("LessonProbabilityPractice");
		
		slides.Add(new Slide(
			"Exercise 2: Discovering Probability\n\nIn the following exercise, you will practice calculating probability."
		));

		slides.Add (new Slide (
			"In this scenario, after a day of investigating fish, your boss wants you to report your findings to him!  We need to calcuate the probability of randomly selecting a fish that has been affected by oil!"
		));

		// ----------------------- Question Slide ---------------- //
		Slide qSlide = new Slide("");
		Question q = new Question();
		q.SetText("If 3 out of 10 fish had been affected by oil, what would the probability be of randomly selected a fish the has been affected by oil?");
		q.SetAnswers("70%", "50%", "0%", "30%");
		q.SetRightAnswer("30%");
		q.SetHint("Calculate 3/10 and then multiply by 100 to get the percentage for the probability.");
		q.SetDescriptionOfRightAnswer("Correct! The probability of selecting a fish that has been affected by oil is 30%, or 3/10.");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //

		// ----------------------- Question Slide ---------------- //
		qSlide = new Slide("");
		q = new Question();
		q.SetText("If 3 out of 10 fish had been affected by oil, what would the probability be of randomly selected a fish the has NOT been affected by oil?");
		q.SetAnswers("70%", "20%", "0%", "30%");
		q.SetRightAnswer("70%");
		q.SetHint("Remember that the total probability of selecting a fish that has been affected by oil and has not been affected by oil is 100%");
		q.SetDescriptionOfRightAnswer("Great! If the probability of selecting a fish that has been affected by oil is 30%, then 100% - 30% = 70%, which is the probability of selecting a fish that has NOT been affected by oil.");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //

		
		slides.Add(new Slide(
			"Your boss appreciates the work!"
		));
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
