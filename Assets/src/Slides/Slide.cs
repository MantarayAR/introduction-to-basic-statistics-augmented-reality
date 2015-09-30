using System;
using UnityEngine;
using System.Collections.Generic;
using Vuforia;

public class Slide
{
	private string text;
	private GUIStructure gui;
	private Slides parent;
	private Experience experience;
	private Question question;
	private SlideState state;
	private bool firstTime = true;
	private Box[] questionBoxes;
	private int currentAnswer = -1;
	private bool showHint = false;
	private bool showDescriptionOfRightAnswer = false;

	public Slide(Slide s) {
		this.text = s.text;
		this.gui = s.gui;
		this.parent = s.parent;
		s.experience.SetOwner (this);
		this.experience = (Experience) Activator.CreateInstance(s.experience.GetType(), s.experience);
		this.question = s.question;
		this.state = s.state;

		if (this.state == SlideState.DONE) {
			this.state = SlideState.AR;
		}
	}

	public Slide(string text)
	{
		state = SlideState.TEXT;
		this.text = text;	
		GUIFactory factory = new GUIFactory();
		
		// Go Back Button
		GUIButton backButton = new GUIButton();
		
		backButton.SetText("Go Back");
		backButton.SetBox(new Box()
			.SetMarginTop("auto")
			.SetMarginRight("auto")
			.SetMarginLeft(0.01f)
			.SetMarginBottom(0.01f)
			.SetWidth(Screen.width * 0.2 + "px")
			.SetHeight (0.1f));
		
		backButton.OnClick(FlowControl.PreviousSlide);
		
		// Go Forward Button
		GUIButton nextButton = new GUIButton();
		
		nextButton.SetText("Continue");
		nextButton.SetBox(new Box()
			.SetMarginTop("auto")
			.SetMarginLeft("auto")
			.SetMarginRight(0.01f)
			.SetMarginBottom(0.01f)
			.SetWidth(Screen.width * 0.2 + "px")
			.SetHeight (0.1f));
		
		nextButton.OnClick(FlowControl.NextSlide);
		
		GUIComponent c = factory
			.CreateLabel (text)
				.SetBox ((new Box ())
					.SetMarginTop (0.1f)
					.SetMarginRight (0.1f)
					.SetMarginBottom (0.1f)
					.SetMarginLeft (0.1f));
				
		GUILabel l = (GUILabel) c;
			
		l.SetStyle(GUIStyles.GetInstance().DEFAULT_SLIDE_STYLE);
		
		
		l.Append (nextButton);
		l.Append (backButton);
		
		gui = factory.Build();

		questionBoxes = new Box[4];

		questionBoxes [0] = new Box ();
		questionBoxes [0]
				.SetMarginTop (0.55f)
				.SetMarginRight (0.51f)
				.SetMarginBottom ("auto")
				.SetMarginLeft (0.01f)
				.SetHeight (0.1f);

		questionBoxes [1] = new Box ();
		questionBoxes [1]
				.SetMarginTop (0.55f)
				.SetMarginRight (0.01f)
				.SetMarginBottom ("auto")
				.SetMarginLeft (0.51f)
				.SetHeight (0.1f);

		questionBoxes [2] = new Box ();
		questionBoxes [2]
				.SetMarginTop (0.7f)
				.SetMarginRight (0.51f)
				.SetMarginBottom ("auto")
				.SetMarginLeft (0.01f)
				.SetHeight (0.1f);

		questionBoxes [3] = new Box ();
		questionBoxes [3]
				.SetMarginTop (0.7f)
				.SetMarginRight (0.01f)
				.SetMarginBottom ("auto")
				.SetMarginLeft (0.51f)
				.SetHeight (0.1f);

	}
	
	public void OnGUI(GameObject gameObject)
	{
		if (FlowControl.MenuState) {
			GUI.enabled = false;
		}

		DoGUI (gameObject);

		if (FlowControl.MenuState) {
			GUI.enabled = true;
		}

		if (FlowControl.MenuState) {
			FlowControl.DrawMenu(gameObject);
		}

	}
	
	public void Update(GameObject gameObject)
	{
		// Is this our first time?  ;)
		if (firstTime)
		{
			firstTime = false;
			
			Setup();
		}
		
		gui.Update(gameObject);
	}

	public void DoGUI(GameObject gameObject) {
		switch (this.state) {
		case SlideState.AR:
			this.experience.OnGUI (gameObject);
			
			// Check if we have found a target!
			GameObject targetGameObject = this.experience.GetTarget ();
			bool found = false;
			TrackableBehaviour mTrackableBehaviour = targetGameObject.GetComponent<TrackableBehaviour> ();
		
			ImageTargetAbstractBehaviour b = this.experience.GetTarget ().GetComponent<ImageTargetAbstractBehaviour> ();
			if (b != null && b.ImageTarget != null) {
				String name = b.ImageTarget.Name;

				foreach (GameObject o in this.experience.GetGameObjects()) {			
					foreach (Renderer component in targetGameObject.GetComponentsInChildren<Renderer>(true)) {
						if (component.enabled && mTrackableBehaviour.TrackableName == name)
							found = true;
					}

					foreach (Collider component in targetGameObject.GetComponentsInChildren<Collider>(true)) {
						if (component.enabled && mTrackableBehaviour.TrackableName == name)
							found = true;
					}
				}
			}
			
			// If NOT found, show GUI text
			if (!found) {
				GUIFactory factory = new GUIFactory ();
				factory.CreateLabel (this.text)
					.SetBox (new Box ()
					        .SetMarginTop (0.01f)
					        .SetMarginLeft (0.3f)
					        .SetMarginRight (0.3f)
					        .SetHeight (0.1f));
				
								factory.Build ().OnGUI (gameObject);
						}
			
						break;
				case SlideState.QUESTION:
			// ------------------- Construct GUI for Question ---------------------- \\
			
			// -------------------------------- QUESTION GUI --------------------------------- \\
						GUIFactory qFactory = new GUIFactory ();
			
			// Go Back Button
			GUIButton backButton = new GUIButton ();

			backButton.SetText ("Go Back");
			backButton.SetBox (new Box ()
                  .SetMarginTop ("auto")
                  .SetMarginRight ("auto")
                  .SetMarginLeft (0.01f)
                  .SetMarginBottom (0.01f)
                  .SetWidth (Screen.width * 0.2 + "px")
                  .SetHeight (0.1f));

			backButton.OnClick (FlowControl.PreviousSlide);

			GUIComponent c;
			if (this.showDescriptionOfRightAnswer) {
					c = new GUILabel (question.GetDescriptionOfRightAnswer ());
					qFactory.Append (c);
					c.SetBox ((new Box ())
	          .SetMarginTop (0.1f)
	          .SetMarginRight (0.1f)
	          .SetMarginBottom (0.1f)
	          .SetMarginLeft (0.1f));
	
					GUILabel z = (GUILabel)c;
					z.SetStyle (GUIStyles.GetInstance ().DEFAULT_SLIDE_STYLE);
	
					GUIButton continueButton = new GUIButton ();
					continueButton.SetText ("Continue");
					continueButton.SetBox (new Box ()
	                      .SetMarginTop ("auto")
	                      .SetMarginLeft ("auto")
	                      .SetMarginRight (0.01f)
	                      .SetMarginBottom (0.01f)
	                      .SetWidth (Screen.width * 0.2 + "px")
	                      .SetHeight (0.1f));
	
					continueButton.OnClick (Continue);
	
					c.Append (continueButton);
	
			} else {
					if (this.showHint) {
							c = new GUIButton ();
							qFactory.Append (c);
							c.SetBox ((new Box ())
		          .SetMarginTop (0.1f)
		          .SetMarginRight (0.1f)
		          .SetMarginBottom (0.1f)
		          .SetMarginLeft (0.1f));
		
							GUIButton z = (GUIButton)c;
							z.SetStyle (GUIStyles.GetInstance ().DEFAULT_SLIDE_STYLE);
							z.SetText (question.GetHint () + "\n\n(Click to hide hint)");
							z.OnClick (HideHint);
		
		
					} else {
							c = qFactory
			.CreateLabel (question.GetText ())
				.SetBox ((new Box ())
				         .SetMarginTop (0.1f)
				         .SetMarginRight (0.1f)
				         .SetMarginBottom (0.1f)
				         .SetMarginLeft (0.1f));
		
							GUILabel l = (GUILabel)c;
		
							l.SetStyle (GUIStyles.GetInstance ().DEFAULT_SLIDE_STYLE);
					}
					if (currentAnswer != -1) {
							// We have a selected answer, show the "next" button
							GUIButton submitAnswerButton = new GUIButton ();
							submitAnswerButton.SetText ("Submit Answer");
							submitAnswerButton.SetBox (new Box ()
		                          .SetMarginTop ("auto")
		                          .SetMarginLeft ("auto")
		                          .SetMarginRight (0.01f)
		                          .SetMarginBottom (0.01f)
		                          .SetWidth (Screen.width * 0.2 + "px")
		                          .SetHeight (0.1f));
		
							submitAnswerButton.OnClick (SubmitAnswer);
		
							c.Append (submitAnswerButton);
					}
	
					for (int i = 0; i < this.question.GetAnswers().Length; i++) {
		
							GUIButton button = new GUIButton ();
		
							button.SetText (this.question.GetAnswers () [i]);
							button.SetBox (questionBoxes [i]);
		
							if (currentAnswer == i) {
									button.SetPressed (true);
							}
		
							switch (i) {
							case 0:
									button.OnClick (QuestionAnswerA);
									break;
							case 1:
									button.OnClick (QuestionAnswerB);
									break;
							case 2:
									button.OnClick (QuestionAnswerC);
									break;
							case 3:
									button.OnClick (QuestionAnswerD);
									break;
							default:
									break;
							}
		
							c.Append (button);
					}
	
					c.Append (backButton);
			}

			GUIStructure questionGUI = qFactory.Build ();
			questionGUI.OnGUI (gameObject);

			break;
	case SlideState.TEXT:
			gui.OnGUI (gameObject);
			break;
	case SlideState.DONE:
			FlowControl.NextSlide ();
			break;
	default:
			break;
	}
}
	
	public void AttachExperience(Experience e) 
	{
		this.experience = e;
		this.state = SlideState.AR;

		GameObject target = experience.GetTarget ();
	}
	
	public void AttachQuestion(Question q)
	{
		this.question = q;
		this.state = SlideState.QUESTION;
	}
	
	public enum SlideState 
	{
		TEXT,
		AR,
		QUESTION,
		DONE
	}
	
	public SlideState GetSlideState()
	{
		return this.state;
	}
	
	public void Setup()
	{
		// if this slide has been setup before, we have some cleaning up to do
		if (!ReferenceEquals(this.experience, null))
		{
			// Set up Target
			GameObject targetGameObject = this.experience.GetTarget();
			targetGameObject.SetActive(false);
			
			// Set up Objects
			foreach (Transform child in  targetGameObject.transform)
			{		
				if (child.gameObject.GetComponent<ImageTargetAbstractBehaviour>() == null) {
					UnityEngine.Object.Destroy(child.gameObject);
				}
			}
			
		}

		// Let's set up our augmented reality if we need it!
		
		if (!ReferenceEquals(this.experience, null))
		{
			// Set up Target
			GameObject targetGameObject = this.experience.GetTarget();
			targetGameObject.SetActive(true);
			
			// Set up Objects
			foreach (GameObject o in this.experience.GetGameObjects())
			{			
				GameObject modelGameObject = GameObject.Instantiate(o) as GameObject;
				modelGameObject.AddComponent<CharacterController>();			
				modelGameObject.AddComponent<ARModel>();
				(modelGameObject.GetComponent<ARModel>() as ARModel).SetExperience(this.experience);
				modelGameObject.AddComponent(this.experience.GetBehavior());
				modelGameObject.transform.parent = targetGameObject.transform;
				
				// Disable all renderers and colliders until they are manually enabled by the target being tracked
				foreach (Renderer component in targetGameObject.GetComponentsInChildren<Renderer>(true))
				{
					component.enabled = false;
				}
				
				foreach (Collider component in targetGameObject.GetComponentsInChildren<Collider>(true))
				{
					component.enabled = false;
				}
			}
			
		}
	}

	/**
	 * Override whatever the slide is doing and let it know that we are done with it!
	 */
	public void Done ()
	{
		// We've been given word that the slide is done!
		this.state = SlideState.DONE;
	}

	public void QuestionAnswerA() {
		currentAnswer = 0;
	}

	public void QuestionAnswerB() {
		currentAnswer = 1;
	}

	public void QuestionAnswerC() {
		currentAnswer = 2;
	}

	public void QuestionAnswerD() {
		currentAnswer = 3;
	}

	public void SubmitAnswer() {
		// get the current answer
		if (this.question.GetAnswers () [this.currentAnswer].Equals (this.question.GetRightAnswer())) {
			// The user has selected the right answer!
			this.showDescriptionOfRightAnswer = true;

		} else {
			// The user has NOT selected the right answer!
			this.showHint = true;
		}
	}

	public void HideHint() {
		this.showHint = false;
	}

	public void Continue() {
		this.showDescriptionOfRightAnswer = false;
		FlowControl.NextSlide();
	}
}