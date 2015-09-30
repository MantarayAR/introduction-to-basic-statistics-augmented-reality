using System;
using UnityEngine;

public class LessonCheckYourKnowledge : MonoBehaviour
{
	public LessonCheckYourKnowledge ()
	{
	}

	Slides slides = null;
	
	void Start ()
	{
		Slides slides = new Slides("Lesson9");
		
		slides.Add(new Slide(
			"Probability Quiz\n\nTo check your knowledge, please answer the following 10 questions. Good luck!"
			));
		// ----------------------- Question Slide 1 ---------------- //
		Slide qSlide = new Slide("");
		Question q = new Question();
		q.SetText("If something is likely to happen, than it should have a probability of...");
		q.SetAnswers("0", "0.5", "0.2", "1");
		q.SetRightAnswer("1");
		q.SetHint("The closer to 1 of probability the more likely it is to happen.");
		q.SetDescriptionOfRightAnswer("The closer to 1 of probability the more likely it is to happen.");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //

		// ----------------------- Question Slide 2 ---------------- //
		qSlide = new Slide("");
		q = new Question();
		q.SetText("If something is likely to happen, than it should have a probability of between...");
		q.SetAnswers("0 and 0.5", "0.5 and 1", "1 and 2", "None of the above");
		q.SetRightAnswer("0.5 and 1");
		q.SetHint("The closer to 1 a probabiltiy, the more likely it is to happen.");
		q.SetDescriptionOfRightAnswer("The closer to 1 a probabiltiy, the more likely it is to happen.");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //


		// ----------------------- Question Slide 3 ---------------- //
		qSlide = new Slide("");
		q = new Question();
		q.SetText("We have a box of jelly beans with 3 orange, 1 lemon, and 2 cherry jelly beans inside it.  \n\nWhat is the probability of randomly selecting an orange jelly bean?");
		q.SetAnswers("3 out of 6", "1 out of 6", "2 out of 6", "4 out of 6");
		q.SetRightAnswer("3 out of 6");
		q.SetHint("Count the number of orange jelly beans and the total number of jelly beans.");
		q.SetDescriptionOfRightAnswer("Good job!  By counting the total of the orange jelly beans and to the total amount of jelly beans, we can determine that 3 out of 6 of the jelly beans are orange.");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //
		
		// ----------------------- Question Slide 4 ---------------- //
		qSlide = new Slide("");
		q = new Question();
		q.SetText("We have a box of jelly beans with 3 orange, 1 lemon, and 2 cherry jelly beans inside it.  \n\nWhat is the probability of randomly selecting a lemon jelly bean?");
		q.SetAnswers("3 out of 6", "1 out of 6", "2 out of 6", "4 out of 6");
		q.SetRightAnswer("1 out of 6");
		q.SetHint("Count the number of lemon jelly beans and the total number of jelly beans.");
		q.SetDescriptionOfRightAnswer("Good job!  By counting the total of the lemon jelly beans and to the total amount of jelly beans, we can determine that 1 out of 6 of the jelly beans are lemon.");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //

		// ----------------------- Question Slide 5 ---------------- //
		qSlide = new Slide("");
		q = new Question();
		q.SetText("We have a box of jelly beans with 3 orange, 1 lemon, and 2 cherry jelly beans inside it.  \n\nWhat is the probability of randomly selecting a cherry jelly bean?");
		q.SetAnswers("3 out of 6", "1 out of 6", "2 out of 6", "4 out of 6");
		q.SetRightAnswer("2 out of 6");
		q.SetHint("Count the number of cherry jelly beans and the total number of jelly beans.");
		q.SetDescriptionOfRightAnswer("Good job!  By counting the total of the cherry jelly beans and to the total amount of jelly beans, we can determine that 2 out of 6 of the jelly beans are cherry.");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //

		// ----------------------- Question Slide 6 ---------------- //
		qSlide = new Slide("");
		q = new Question();
		q.SetText("We have a box of jelly beans with 3 orange, 1 lemon, and 2 cherry jelly beans inside it.  \n\nWhich flavor would have the largest probability of being randomly selected?");
		q.SetAnswers("Cherry", "Lemon", "Orange", "All equal");
		q.SetRightAnswer("Orange");
		q.SetHint("Count which flavor has the highest amount.");
		q.SetDescriptionOfRightAnswer("Good job!");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //

		// ----------------------- Question Slide 7 ---------------- //
		qSlide = new Slide("");
		q = new Question();
		q.SetText("We have a box of jelly beans with 3 orange, 1 lemon, and 2 cherry jelly beans inside it.  \n\nWhich flavor would have the lowest probability of being randomly selected?");
		q.SetAnswers("Cherry", "Lemon", "Orange", "All equal");
		q.SetRightAnswer("Lemon");
		q.SetHint("Count which flavor has the lowest amount.");
		q.SetDescriptionOfRightAnswer("Good job!");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //


		// ----------------------- Question Slide 8 ---------------- //
		qSlide = new Slide("");
		q = new Question();
		q.SetText("A fair coin is tossed 10 times. It lands on heads 8 times and lands on tails 2 times. What is the probability that the coin will land on heads with the next throw?");
		q.SetAnswers("80%", "20%", "10%", "50%");
		q.SetRightAnswer("50%");
		q.SetHint("Don't be fooled into thinking that the past coin flips influence future coin flips.");
		q.SetDescriptionOfRightAnswer("Good job! Past coin flips do not influence future coin flips.");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //

			
		// ----------------------- Question Slide 9 ---------------- //
		qSlide = new Slide("");
		q = new Question();
		q.SetText("The weatherman reported that there was a 70% chance of rain tomorrow. How else could we show this amount?");
		q.SetAnswers("7:3", "7/10", "0.7", "All of the above");
		q.SetRightAnswer("All of the above");
		q.SetHint("There is more than one way to represent a probability.");
		q.SetDescriptionOfRightAnswer("Great! Probabilities can be represented as fractions, ratios, decimals, as well as percentages.");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //		
				
				
		// ----------------------- Question Slide 10 ---------------- //
		qSlide = new Slide("");
		q = new Question();
		q.SetText("A recipe calls for 2 cups of milk for every 3 cups of cake mix. How can we show this as a ratio of milk to cake mix?");
		q.SetAnswers("2:3", "3:2", "0:5", "5:0");
		q.SetRightAnswer("2:3");
		q.SetHint("There is more than one way to represent a probability.");
		q.SetDescriptionOfRightAnswer("Great! Probabilities can be represented as fractions, ratios, decimals, as well as percentages.");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //

		slides.Add(new Slide(
			"Congrats on finishing the probability quiz! Now that you've learned what probability is, check out our other mobile learning applications!"
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

