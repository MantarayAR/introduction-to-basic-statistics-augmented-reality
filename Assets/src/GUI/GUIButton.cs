using UnityEngine;
using System.Collections;

/**
 * GUIButton contains Styles and methods for creating GUI buttons.
 * They should be attached to a GUIFactory, otherwise, you will need
 * to manually call OnGUI.
 * 
 * @author Ivan Montiel
 */
public class GUIButton : GUIComponent
{
	// Private variables
	private bool isClicked = false;
	private string text = "";
	private ActionUtil.Run action = null;
	private GUIStyle guiStyle = new GUIStyle();
	private Texture2D clickedTexture;
	private int pressedTimer = 0;
	private bool pressed = false;
	
	/**
	 * Constructor
	 */
	public GUIButton() {
		guiStyle = GUIStyles.GetInstance().DEFAULT_BUTTON_STYLE;
		clickedTexture = GUIStyles.GetInstance().DARK_ORANGE_SWATCH;
	}
	
	/**
	 * OnGUI should be called when you want the GUI to update.  This will
	 * handle button presses and OnClick actions.
	 */
	public override void OnGUI (GameObject gameObject) {
		CalculateField ();
		
		// If the pressed timer is reset and the GUI Button is clicked
		if (pressedTimer == 0 && GUI.Button (this.field, this.text, this.guiStyle)) 
		{
			SoundUtil.getInstance().buttonPlay(gameObject);
			this.isClicked = true;
			Event.current.Use ();
		}
		
		// Are we clicked?
		if (this.isClicked)
		{
			// Increment the timer
			pressedTimer++;
			
			Texture2D temp = this.guiStyle.normal.background;
			this.guiStyle.normal.background = clickedTexture;
			
			// Render the clicked texture
			GUI.Button (this.field, this.text, this.guiStyle);
			
			// Do the associated action if it is defined
			if (this.action != null && pressedTimer == 1)
			{
				this.action();
			}
			
			// Reset the timer when it hits 100
			if (pressedTimer == 100)
			{
				pressedTimer = 0;
				this.isClicked = false;
			}
			
			this.guiStyle.normal.background = temp;
		}

		// Are we pressed?
		if (this.pressed) {
			Texture2D temp = this.guiStyle.normal.background;
			this.guiStyle.normal.background = clickedTexture;
			
			// Render the clicked texture
			GUI.Button (this.field, this.text, this.guiStyle);

			this.guiStyle.normal.background = temp;
		}

		base.OnGUI(gameObject);
	}
			
	/**
	 * Sets the text of the button
	 */
	public GUIButton SetText (string s)
	{
		this.text = s;
		return this;
	}
	
	/**
	 * Sets the onclick action using the ActionUtil.Run delegate
	 */
	public GUIButton OnClick (ActionUtil.Run r)
	{
		this.action = r;
		return this;
	}

	public void SetPressed(bool b) {
		this.pressed = b;
	}

	public GUIComponent SetStyle(GUIStyle style)
	{
		this.guiStyle = style;
		
		return this;
	}


}