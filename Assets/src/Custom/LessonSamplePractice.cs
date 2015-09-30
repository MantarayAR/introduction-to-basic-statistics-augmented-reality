using System;
using UnityEngine;


public class LessonSamplePractice : MonoBehaviour 
{
	Slides slides = null;
	
	void Start ()
	{
		Assets assets = Assets.GetInstance();
		Slides slides = new Slides("LessonSamplePractice");

		slides.Add (new Slide (
			"Let's discover first hand what probability is and how we can use it in real world situations."
		));

		slides.Add (new Slide (
			"Here is a scenario: An oil spill has caused fish in a bay area to become sick. You have been tasked to figure out the effects of that oil spill on the first population of fish."
		));

		slides.Add (new Slide (
			"Begin by taking a tally of how many fish you can find that have been affected by the pollution."
		));

		slides.Add (new Slide (
			"Let's practice:\n" +
			"1. To begin, locate the first area of water, called the Bay Area.\n" +
			"2. Point the camera on your mobile device at the Bay Area.\n" +
			"3. Take a sample of the 10 fish in the water by tapping the fish on the screen."
		));

		slides.Add (new Slide (
			"4. To determine if a fish is infected by oil, look for oil streaks.\n" +
			"5. Once you’ve looked at all 10 fish, calculate the percentage of fish affected by pollution and answer any related questions. If you need help, tap “hint” for more information.\n" +
			"6. After answering all the questions for the area of water, tap [finished]."
		));
			
		// --------------------- Experience Slide ---------------- // 
		Slide arSlide = new Slide(
			"Point your device at Pier Area."
		);
		
		FishExperience e = new FishExperience(typeof(FishBehavior), arSlide);
		e.SetTarget(GameObject.Find (assets.PierArea));
		e.AddGameObject(assets.RandomHealthyFish());
		e.AddGameObject(assets.RandomHealthyFish());
		e.AddGameObject(assets.RandomHealthyFish());
		e.AddGameObject(assets.RandomHealthyFish());
		e.AddGameObject(assets.RandomHealthyFish());
		e.AddGameObject(assets.RandomHealthyFish());
		e.AddGameObject(assets.RandomHealthyFish());
		e.AddGameObject(assets.RandomSickFish());
		e.AddGameObject(assets.RandomSickFish());
		e.AddGameObject(assets.RandomSickFish());
		e.SetTotalNumberOfFish (10);
		
		arSlide.AttachExperience(e);
		
		slides.Add(arSlide);
		// -------------------------------------------------------- //

		slides.Add (new Slide (
			"Results\n\n" +
			"It looks like you sampled 3 out of 10 fish that have been affected by the oil spill."
		));

		slides.Add (new Slide (
			"In other words, 30 percent of the fish have been affected by the oil spill.\n\n" +
			"Based on that, we can assume that of the next 10 fish we randomly select from the lake, 3 will also be affected by the pollution."
		));


		// ----------------------- Question Slide ---------------- //
		Slide qSlide = new Slide("");
		Question q = new Question();
		q.SetText("You have observed that 3 of 10 fish have been affected by pollution for this sample. How many fish would you expect to be affected by the oil spill if you sampled a total of 100 fish from the same lake?");
		q.SetAnswers("10", "30", "50", "100");
		q.SetRightAnswer("30");
		q.SetHint("Take the number of fish that have been affected by oil and divide it by the total number of fish and multiply by 100.");
		q.SetDescriptionOfRightAnswer("By calculating that 30% of your sample was infected, you can make an estimation that 30% of the 100 fish will also be affected by the oil spill, which is 30 fish.");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //

		slides.Add (new Slide (
			"That is how you take a sample of a population."
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

