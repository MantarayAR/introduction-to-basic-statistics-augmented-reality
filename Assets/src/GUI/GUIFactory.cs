using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * GUI Factory
 */
public class GUIFactory
{
	private List<GUIComponent> components = new List<GUIComponent>();
	
	public GUIComponent CreateLabel()
	{
		GUIComponent component = new GUILabel();
		
		this.components.Add(component);
		
		return component;
	}
	
	public GUIComponent CreateLabel(string text)
	{
		GUIComponent component = new GUILabel(text);
		
		this.components.Add(component);
		
		return component;
	}
		
	public GUIComponent CreateContainer ()
	{
		GUIComponent component = new GUIContainer();
		
		this.components.Add(component);
		
		return component;
	}
	
	public GUIComponent CreateScrollArea ()
	{
		GUIComponent component = new GUIScrollArea ();
		
		this.components.Add (component);
		
		return component;
	}
	
	public void Append(GUIComponent c)
	{
		this.components.Add (c);
	}
	
	public void Prepend(GUIComponent c)
	{
		this.components.Insert(0, c);
	}
	
	/**
	 * Build the GUIFactory into a GUIStructure
	 */
	public GUIStructure Build ()
	{
		
		return new GUIStructure(this.components);
	}
}