using UnityEngine;

public class GUIImage : GUIComponent
{
	private Texture2D image;
	private string filename;
	private ScaleMode scaleMode = ScaleMode.ScaleAndCrop;
	
	public GUIImage(string filename)
	{
		this.filename = filename;
	}
	
	public override void OnGUI (GameObject gameObject) 
	{
		if (filename == null) 
			return;
		
		if (image == null) {
			this.image = Resources.Load(filename) as Texture2D;
		}
		
		base.OnGUI(gameObject);
		
		Rect parentField = GetParentField();
		GUI.DrawTexture (parentField, image, this.scaleMode, true, (float)image.width / (float)image.height);
	}
	
	public GUIImage SetScaleMode (ScaleMode scaleMode)
	{
		this.scaleMode = scaleMode;
		return this;
	}
}