using System;
using UnityEngine;


public class LessonExploringVariability : MonoBehaviour 
{
	Slides slides = null;
	
	
	void Start ()
	{
		Assets assets = Assets.GetInstance();
		Slides slides = new Slides("LessonExploringVariability");

		slides.Add(new Slide(
			"Comparing Different Samples\n\n" +
			"Let's discover first hand what variability is and how we can use it in real world situations."
		));

		slides.Add (new Slide (
			"HWe return to the area of the oil spill that has caused fish to become sick.\n\n" +
			"Let's compare the results we took from the Pier and compare them with new data from the Shallow Area of the lake."
		));
		
		// --------------------- Experience Slide ---------------- // 
		Slide arSlide = new Slide(
			"Point your device at the Shallow Area."
		);
		
		FishExperience e = new FishExperience(typeof(FishBehavior), arSlide);
		e.SetTarget(GameObject.Find (assets.ShallowArea));
		e.AddGameObject(assets.RandomHealthyFish());
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
		e.AddGameObject(assets.RandomSickFish());
		e.SetTotalNumberOfFish (12);
		
		arSlide.AttachExperience(e);
		
		slides.Add(arSlide);
		// -------------------------------------------------------- //
		
		// ----------------------- Question Slide ---------------- //
		Slide qSlide = new Slide("");
		Question q = new Question();
		q.SetText("What fraction of fish have been affected by oil based on the 12 fish you have investigated (there were 8 fish that were not affected by oil)?");
		q.SetAnswers("1/12", "3/12", "4/12", "7/12");
		q.SetRightAnswer("4/12");
		q.SetHint("Take the number of fish that have been affected by oil and divide it by the total number of fish.");
		q.SetDescriptionOfRightAnswer("Great!  Dividing the number of affected fish by the total number of fish, we can derive that 4/12ths of the fish have been affected by pollution!");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //
		
		
		// ----------------------- Question Slide ---------------- //
		qSlide = new Slide("");
		q = new Question();
		q.SetText("What is 4/12ths as a percentage?");
		q.SetAnswers("10%", "33.3%", "66.7%", "100%");
		q.SetRightAnswer("33.3%");
		q.SetHint("The probability that the next fish is affected by oil is the same as the observed fraction of fish that have been affected by oil.");
		q.SetDescriptionOfRightAnswer("That's correct!  4/12 = 1/3, which is 33.3%.");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //
		
		// ----------------------- Question Slide ---------------- //
		qSlide = new Slide("");
		q = new Question();
		q.SetText("Last time, we noticed that 3/10 fish were affected.  Is that a higher or lower percentage of fish than this time (which was 4/12)?");
		q.SetAnswers("Higher", "Lower", "The Same", "");
		q.SetHint ("Calculate what 3/10ths is and calculate what 4/12ths is as a percentage.");
		q.SetRightAnswer("Lower");
		//q.SetHint("The probability that the next fish is affected by oil is the same as the observed fraction of fish that have been affected by oil.");
		q.SetDescriptionOfRightAnswer("That's right!  By counting more fish, we have discovered that the percentage of fish is actually lower than we originally estimated.");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //

		slides.Add (new Slide (
			"Let's collect one more data set from a Tributary of the lake before we look into the variability of the data we have collected."
		));
		
		// --------------------- Experience Slide ---------------- // 
		arSlide = new Slide(
			"Point your device at the Tributary Area."
		);
		
		e = new FishExperience(typeof(FishBehavior), arSlide);
		e.SetTarget(GameObject.Find (assets.TributaryArea));
		e.AddGameObject(assets.RandomHealthyFish());
		e.AddGameObject(assets.RandomHealthyFish());
		e.AddGameObject(assets.RandomHealthyFish());
		e.AddGameObject(assets.RandomHealthyFish());
		e.AddGameObject(assets.RandomHealthyFish());
		e.AddGameObject(assets.RandomSickFish());
		e.AddGameObject(assets.RandomSickFish());
		e.AddGameObject(assets.RandomSickFish());
		e.AddGameObject(assets.RandomSickFish());
		e.AddGameObject(assets.RandomSickFish());
		e.SetTotalNumberOfFish (10);
		
		arSlide.AttachExperience(e);
		
		slides.Add(arSlide);
		// -------------------------------------------------------- //

		// ----------------------- Question Slide ---------------- //
		qSlide = new Slide("");
		q = new Question();
		q.SetText("So far, we have collected the following sets of data of the percentage of fish that have been affected: 30%, 33.3%, and 50%.\n\n"  +
		          "What is the range of this data?");
		q.SetAnswers("20", "33.3", "30", "50");
		q.SetHint ("Remember that the range is the value of the largest data point minus the smallest data point.");
		q.SetRightAnswer("20");
		q.SetDescriptionOfRightAnswer("That's right! By taking the largest data point (50%) and subtracting the smallest data point (30%), we get 20 as the range!");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //

		// ----------------------- Question Slide ---------------- //
		qSlide = new Slide("");
		q = new Question();
		q.SetText("If you were to estimate the mean of 30%, 33.3%, and 50%, what would your approximation be?");
		q.SetAnswers("20% - 30%", "35% - 40%", "50% - 60%", "0% - 10%");
		q.SetHint ("If you are having trouble calculating the mean, try to visually imagine where the middle of 30, 33 and 50 would be.");
		q.SetRightAnswer("35% - 40%");
		q.SetDescriptionOfRightAnswer("Good job!  The exact mean is 37.7%!");
		
		qSlide.AttachQuestion(q);
		slides.Add (qSlide);
		// -------------------------------------------------------- //

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
