using System;
using UnityEngine;
using System.Collections.Generic;

public class Assets
{
	private static Assets assets = null;
	private System.Random random;
	
	public String ShallowArea;
	public String PierArea;
	public String TributaryArea;
	public List<GameObject> HealthyFish = new List<GameObject>();
	public  List<GameObject> SickFish = new List<GameObject>();
	
	private Assets ()
	{
		HealthyFish.Add(Resources.Load("ModelPrefabs/asp") as GameObject);
		HealthyFish.Add(Resources.Load("ModelPrefabs/barbel") as GameObject);
		HealthyFish.Add(Resources.Load("ModelPrefabs/bream") as GameObject);
		HealthyFish.Add(Resources.Load("ModelPrefabs/brooktrout") as GameObject);
		HealthyFish.Add(Resources.Load("ModelPrefabs/burbot") as GameObject);
		HealthyFish.Add(Resources.Load("ModelPrefabs/eel") as GameObject);
		HealthyFish.Add(Resources.Load("ModelPrefabs/nase") as GameObject);
		HealthyFish.Add(Resources.Load("ModelPrefabs/normalfish") as GameObject);
		HealthyFish.Add(Resources.Load("ModelPrefabs/perch") as GameObject);
		HealthyFish.Add(Resources.Load("ModelPrefabs/pike") as GameObject);
		HealthyFish.Add(Resources.Load("ModelPrefabs/prussiancarb") as GameObject);
		HealthyFish.Add(Resources.Load("ModelPrefabs/tench") as GameObject);
		
		SickFish.Add(Resources.Load("ModelPrefabs/asp_affected") as GameObject);
		SickFish.Add(Resources.Load("ModelPrefabs/barbel_affected") as GameObject);
		SickFish.Add(Resources.Load("ModelPrefabs/bream_affected") as GameObject);
		SickFish.Add(Resources.Load("ModelPrefabs/brooktrout_affected") as GameObject);
		SickFish.Add(Resources.Load("ModelPrefabs/burbot_affected") as GameObject);
		SickFish.Add(Resources.Load("ModelPrefabs/eel_affected") as GameObject);
		SickFish.Add(Resources.Load("ModelPrefabs/nase_affected") as GameObject);
		SickFish.Add(Resources.Load("ModelPrefabs/normalfish_affected") as GameObject);
		SickFish.Add(Resources.Load("ModelPrefabs/perch_affected") as GameObject);
		SickFish.Add(Resources.Load("ModelPrefabs/pike_affected") as GameObject);
		SickFish.Add(Resources.Load("ModelPrefabs/prussiancarb_affected") as GameObject);
		SickFish.Add(Resources.Load("ModelPrefabs/tench_affected") as GameObject);

		// TODO update images
		ShallowArea = "ShallowImageTarget";
		PierArea  = "PierImageTarget";
		TributaryArea  = "TributaryImageTarget";
		
		this.random = new System.Random();
	}
	
	public static Assets GetInstance()
	{
		if (Assets.assets == null)
		{
			Assets.assets = new Assets();
		}
		
		return Assets.assets;
	}
	
	public GameObject RandomHealthyFish()
	{
		int index = random.Next(HealthyFish.Count);
		return HealthyFish[index];
	}
	
	public GameObject RandomSickFish()
	{
		int index = random.Next(SickFish.Count);
		return SickFish[index];
	}
}

