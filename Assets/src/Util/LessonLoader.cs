using UnityEngine;
using System;
using Vuforia;

public class LessonLoader : MonoBehaviour {
	public Camera c;
	private string currentLesson;

	void Start() {
		currentLesson = FlowControl.GetLesson ();
		if (currentLesson == null || "".Equals (currentLesson)) {
				currentLesson = "Lesson1";
		}

		this.gameObject.AddComponent (Type.GetType (currentLesson));

		if (c != null) {
			TurnOffAR();
		}
	}

	public void TurnOffAR() {
		//c.GetComponentInParent<VuforiaBehaviour> ().enabled = false;
		//c.GetComponentInParent<QCARBehaviour>().enabled = false;
	}

	public void TurnOnAR () {
		//c.GetComponentInParent<VuforiaBehaviour> ().PrimaryCamera = c;
		//c.GetComponentInParent<VuforiaBehaviour> ().enabled = true;
//		c.GetComponentInParent<QCARBehaviour> ().PrimaryCamera = c;
//		c.GetComponentInParent<QCARBehaviour> ().enabled = true;
	}

	void OnGUI() {
		Slides currentSlides = FlowControl.GetCurrentSlides ();
		if (currentSlides.CurrentSlide ().GetSlideState () == Slide.SlideState.AR) {
			TurnOnAR ();
		} else {
			TurnOffAR ();
		}
	}

	public void Reload() {
		Start ();
	}
}
