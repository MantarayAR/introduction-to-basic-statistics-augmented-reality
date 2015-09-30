using System;
using UnityEngine;

public class GUIStyles
{
	public GUIStyle DEFAULT_BUTTON_STYLE = new GUIStyle();
	public GUIStyle DEFAULT_WHITE_STYLE = new GUIStyle();
	public GUIStyle DEFAULT_LESSON_BUTTON_STYLE = new GUIStyle();
	public GUIStyle SCROLL_BAR_STYLE = new GUIStyle();
	public GUIStyle DEFAULT_SLIDE_STYLE = new GUIStyle();
	
	public Texture2D DARK_ORANGE_SWATCH = Resources.Load ("dark-orange-swatch") as Texture2D;
	public Texture2D COMPLETED_SWATCH = Resources.Load ("completed") as Texture2D;
	public Texture2D IN_PROGRESS = Resources.Load ("in-progress") as Texture2D;
	public Texture2D NOT_COMPLETED = Resources.Load ("not-completed") as Texture2D;
	
	private static GUIStyles instance;
	
	private GUIStyles ()
	{
		DEFAULT_BUTTON_STYLE.normal.background = Resources.Load ("orange-swatch") as Texture2D;
		DEFAULT_BUTTON_STYLE.border.bottom = 1;
		DEFAULT_BUTTON_STYLE.border.top = 1;
		DEFAULT_BUTTON_STYLE.border.left = 1;
		DEFAULT_BUTTON_STYLE.border.right = 1;
		DEFAULT_BUTTON_STYLE.padding.left = 0;
		DEFAULT_BUTTON_STYLE.alignment = TextAnchor.MiddleCenter;
		DEFAULT_BUTTON_STYLE.normal.textColor = Color.white;	
		DEFAULT_BUTTON_STYLE.fontSize =  (int) Math.Round (Screen.height * 0.03785f);
		
		DEFAULT_WHITE_STYLE.normal.background = Resources.Load ("white-box") as Texture2D;
		DEFAULT_WHITE_STYLE.border.bottom = 1;
		DEFAULT_WHITE_STYLE.border.top = 1;
		DEFAULT_WHITE_STYLE.border.left = 1;
		DEFAULT_WHITE_STYLE.border.right = 1;
		DEFAULT_WHITE_STYLE.padding.left = 0;
		DEFAULT_WHITE_STYLE.alignment = TextAnchor.MiddleCenter;
		DEFAULT_WHITE_STYLE.normal.textColor = Color.black;	
		DEFAULT_WHITE_STYLE.fontSize =  (int) Math.Round (Screen.height * 0.03785f);
		
		DEFAULT_SLIDE_STYLE.normal.background = Resources.Load ("white-box") as Texture2D;
		DEFAULT_SLIDE_STYLE.border.bottom = 1;
		DEFAULT_SLIDE_STYLE.border.top = 1;
		DEFAULT_SLIDE_STYLE.border.left = 1;
		DEFAULT_SLIDE_STYLE.border.right = 1;
		DEFAULT_SLIDE_STYLE.padding.left = (int) (Screen.height * 0.05f);
		DEFAULT_SLIDE_STYLE.padding.top = (int) (Screen.height * 0.05f);
		DEFAULT_SLIDE_STYLE.padding.right = (int) (Screen.height * 0.05f);
		DEFAULT_SLIDE_STYLE.alignment = TextAnchor.UpperLeft;
		DEFAULT_SLIDE_STYLE.normal.textColor = Color.black;	
		DEFAULT_SLIDE_STYLE.fontSize =  (int) Math.Round (Screen.height * 0.05f);
		DEFAULT_SLIDE_STYLE.wordWrap = true;
		
		DEFAULT_LESSON_BUTTON_STYLE.normal.background = Resources.Load ("orange-swatch") as Texture2D;
		DEFAULT_LESSON_BUTTON_STYLE.border.bottom = 1;
		DEFAULT_LESSON_BUTTON_STYLE.border.top = 1;
		DEFAULT_LESSON_BUTTON_STYLE.border.left = 1;
		DEFAULT_LESSON_BUTTON_STYLE.border.right = 1;
		DEFAULT_LESSON_BUTTON_STYLE.padding.left = 0;
		DEFAULT_LESSON_BUTTON_STYLE.alignment = TextAnchor.MiddleLeft;
		DEFAULT_LESSON_BUTTON_STYLE.padding.left = 10;
		DEFAULT_LESSON_BUTTON_STYLE.normal.textColor = Color.white;	
		DEFAULT_LESSON_BUTTON_STYLE.fontSize = (int) Math.Round (Screen.height * 0.03785f);
		
		SCROLL_BAR_STYLE.normal.background = Resources.Load ("orange-swatch") as Texture2D;
		SCROLL_BAR_STYLE.border.bottom = 1;
		SCROLL_BAR_STYLE.border.top = 1;
		SCROLL_BAR_STYLE.border.left = 1;
		SCROLL_BAR_STYLE.border.right = 1;
		SCROLL_BAR_STYLE.padding.left = 0;
		SCROLL_BAR_STYLE.alignment = TextAnchor.MiddleCenter;
		SCROLL_BAR_STYLE.normal.textColor = Color.white;	
		SCROLL_BAR_STYLE.fontSize =  (int) Math.Round (Screen.height * 0.03785f);
		
	}
	
	public static GUIStyles GetInstance()
	{
		if (GUIStyles.instance == null)
		{
			GUIStyles.instance = new GUIStyles();
		}
		
		return GUIStyles.instance;
	}
}

