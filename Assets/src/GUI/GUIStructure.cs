using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIStructure
{
	private List<GUIComponent> components;
	
	public GUIStructure (List<GUIComponent> components)
	{
		this.components = components;
	}
	
	public void OnGUI(GameObject gameObject)
	{
		foreach (GUIComponent component in components) 
		{
			component.OnGUI(gameObject);
		}
	}
	
	public void Update(GameObject gameObject)
	{
		foreach (GUIComponent component in components) 
		{
			component.Update(gameObject);
		}
	}
}