using UnityEngine;

public class FishExperience : Experience
{
	private int total = 0;
	private int affectedTally = 0;
	private int tally = 0;
	private GUIStyle s;

	public FishExperience (FishExperience e) : base( e.GetBehavior(), e.GetOwner()) {
		this.SetTarget (e.GetTarget ());
		this.SetGameObjects (e.GetGameObjects ());
		this.SetTotalNumberOfFish (e.GetGameObjects ().Count);
		s = new GUIStyle (GUIStyles.GetInstance ().DEFAULT_SLIDE_STYLE);
		s.fontSize = (int)(s.fontSize * 0.75);
	}

	public FishExperience (System.Type behaviour, Slide owner) : base(behaviour, owner)
	{
		s = new GUIStyle (GUIStyles.GetInstance ().DEFAULT_SLIDE_STYLE);
		s.fontSize = (int)(s.fontSize * 0.75);
	}

	public override void OnGUI(GameObject gameObject) {
		base.OnGUI(gameObject);

		GUIFactory f = new GUIFactory ();

		GUIComponent c = f.CreateLabel ("Total : " + total + 
		                                "\n" +
		                                "Affected : " + affectedTally)
			.SetBox(new Box()
			        .SetMarginLeft(0.01f)
			        .SetMarginTop(0.01f)
			        .SetWidth(0.2f)
			        .SetHeight (0.2f)
			        );

		GUILabel l = (GUILabel) c;

		l.SetStyle(s);
		
		f.Build ().OnGUI (gameObject);


	}

	public void SetTotalNumberOfFish(int num) {
		this.total = num;
	}

	public void TallyFish(bool affected) {
		if (affected) {
			this.affectedTally++;
		} 

		this.tally++;

		// If the tally is equal to the total, we are done!
		// Give word to the Slide to move on!
		if (this.tally >= this.total) {
			this.owner.Done();
		}

	}

}