using System;
using UnityEngine;

public class LessonSampling : MonoBehaviour
{
	Slides slides = null;
	
	void Start ()
	{
		Slides slides = new Slides ("LessonSampling");

		slides.Add (new Slide (
			"Introduction to Statistical Sampling\n\n" +
			"In statistics, sampling is concerned with the selection of a subset of individuals from within a statistical population to estimate characteristics of the whole population."
		));

		slides.Add (new Slide (
			"By conducting a statistical sample, our workload can be cut down immensely. Rather than tracking the behaviors of billions or millions, we only need to examine those of thousands or hundreds."
		));

		slides.Add (new Slide (
			"Types of Sampling\n\n" + 
			"There are many different types of sampling, but the most common is simple random sampling. Random sampling is one in which any member of the population is equally likely to be selected for the sample."
		));

		slides.Add (new Slide (
			"With random sampling, being random helps eliminate bias when we make statistical conclusions in which any member of the population is equally likely to be selected for the sample."
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
