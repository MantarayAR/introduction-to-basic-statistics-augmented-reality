using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUILabel : GUIComponent
{
	private string text;
	private GUIStyle style;
	
	public GUILabel ()
	{
		this.text = "";
		this.style = GUIStyles.GetInstance().DEFAULT_WHITE_STYLE;
	}
	
	public GUILabel (string text)
	{
		this.text = text;
		this.style = GUIStyles.GetInstance().DEFAULT_WHITE_STYLE;
	}
	
	public override void OnGUI (GameObject gameObject)
	{
		this.CalculateField();
		
		GUI.Label(this.field, this.text, this.style);
		
		base.OnGUI (gameObject);
	}
	
	public GUIComponent SetStyle(GUIStyle style)
	{
		this.style = style;
		
		return this;
	}
}