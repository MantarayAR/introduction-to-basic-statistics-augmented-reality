using System;
using UnityEngine;

public class GUIScrollArea : GUIComponent
{
	Vector2 scrollPosition = Vector2.zero;
	private Rect insideField;
	private float scrollWidth = 20; // TODO calculate this some how
	
	// Internal variables for managing touches and drags
	public float inertiaDuration = 0.75f;
	
	public GUIScrollArea ()
	{
	}
	
	public override void Update(GameObject gameObject)
    {
		
		foreach (Touch touch in Input.touches) 
		{
	        if (touch.phase == TouchPhase.Moved)
	        {
	        	scrollPosition.y += touch.deltaPosition.y;        // dragging
	        }
		}
	}
	
	public override void OnGUI(GameObject gameObject)
	{
		this.CalculateField();
		
		this.CalculateInsideField();		
		
		Rect outsideField = new Rect(this.field);
		outsideField.x -= 5;
		outsideField.y -= 5;
		outsideField.width += 5 * 2;
		outsideField.height += 5 * 2;
		
		GUI.Label(outsideField, new GUIContent(""), GUIStyles.GetInstance().DEFAULT_WHITE_STYLE);
		
		
		// SCROLL BAR
		scrollPosition = GUI.BeginScrollView (field,
			scrollPosition, insideField, false, true);
		
		// Fake the child's percieved parent's size:
		Rect tempField = this.field;
		this.field = insideField;
		
		// Children will be called!
		base.OnGUI (gameObject);
		
		// End the scroll view that we began above.
		GUI.EndScrollView ();
		
		this.field = tempField;
	}
	
	protected void CalculateInsideField()
	{
		
		this.insideField = new Rect (0, 0, this.field.width - this.scrollWidth, this.children[0].RequestEstimatedHeight() );
	}

}

