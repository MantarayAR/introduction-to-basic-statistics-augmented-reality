using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GUIComponent : ICloneable
{
	/**
	 * Notes:
	 * 
	 * Box is a relative position to the container's parent.
	 * 
	 * Field is an absolute position to the screen's position.
	 * 
	 * Field is calculated from the Box given.
	 */
	protected List<GUIComponent> children = new List<GUIComponent>();
	protected GUIComponent parent;
	protected Box box = new Box();
	// Calculated
	protected Rect field = new Rect(-1f, -1f, -1f, -1f);
	protected Rect NOTSETFIELD = new Rect(-1f, -1f, -1f, -1f);
	
	/**
	 * Implement ICloneable Interface
	 */
	public object Clone()
    {
    	GUIComponent c = new GUIComponent();
		
		if (children.Count > 0)
			c.children =  Extensions.Clone<GUIComponent>(this.children);
		
		c.box = new Box(this.box);
		c.parent = this.parent;
		
        return c;
    }
		
	public GUIComponent SetBox (Box box)
	{
		this.box = box;
		return this;
	}
			
	public GUIComponent Append (GUIComponent component)
	{
		component.SetParent(this);
		this.children.Add(component);
		return this;
	}
	
	public void SetParent(GUIComponent component) 
	{
		this.parent = component;
	}
	
	/**
	 * When you override this, you must call BASE.
	 */
	public virtual void OnGUI (GameObject gameObject) 
	{
		CalculateField ();
		
		foreach (GUIComponent child  in children)
		{
			child.OnGUI (gameObject);
		}
	}
	
	public virtual void Update(GameObject gameObject)
	{
		foreach (GUIComponent child  in children)
		{
			child.Update (gameObject);
		}
	}
	
	public Rect GetField ()
	{
		CalculateField();
		return this.field;
	}
	
	public void CalculateField ()
	{
		if (this.field.Equals (NOTSETFIELD)) 
		{
			Rect parentField = GetParentField();
			
			
			// Default case FILL CONTAINER
			float x = parentField.x;
			float y = parentField.y;
			float width = parentField.width;
			float height = parentField.height;
			
			// Left, will auto calculate right
			CalculateLeft(ref x, ref y, ref width, ref height, parentField);
			
				
			
			// Top, will auto calculate bottom
			CalculateTop(ref x, ref y, ref width, ref height, parentField);
			
			// Assignment
			this.field = new Rect(x, y, width, height);
		}
		
	}
	
	public void CalculateLeft(ref float x, ref float y, ref float width, ref float height, Rect parentField)
	{
		if (this.box.GetMarginLeftType() == Box.MarginType.PERCENTAGE) 
		{
			x += parentField.width * this.box.GetMarginLeft();
			width -= parentField.width * this.box.GetMarginLeft();
		}
		else if (this.box.GetMarginLeftType() == Box.MarginType.PIXEL) 
		{
			x += this.box.GetMarginLeft();
			width -= this.box.GetMarginLeft();
		} 
		else if (this.box.GetMarginLeftType() == Box.MarginType.AUTO)
		{
			width = this.box.GetWidth();
			
			
			if (this.box.GetMarginRightType () == Box.MarginType.AUTO)
			{
				// Look at the right, if it is also auto, center the box.
				
				float marginSize = (parentField.width - this.box.GetWidth()) / 2;
				
				x += marginSize;
				
			}
			else
			{
				float preWidth = width;
				// If the right is NOT auto, calculate the right FIRST
				CalculateRight(ref x, ref y, ref width, ref height, parentField);
				
				// The left is then the remainder of the parent width - (boxwidth + marginright)
				
				x += parentField.width - preWidth;
				
				// Break ref
				return;
			}
			
		}
		
		CalculateRight(ref x, ref y, ref width, ref height, parentField);
	}
	
	public void CalculateRight(ref float x, ref float y, ref float width, ref float height, Rect parentField)
	{
		if (this.box.GetMarginRightType() == Box.MarginType.PERCENTAGE) 
		{
			width -= parentField.width * this.box.GetMarginRight();
		}
		else if (this.box.GetMarginRightType() == Box.MarginType.PIXEL) 
		{
			width -= this.box.GetMarginRight();
		}
		else if (this.box.GetMarginRightType() == Box.MarginType.AUTO)
		{
			if (this.box.GetWidthType() == Box.SizeType.PERCENTAGE)
			{
				width = parentField.width * this.box.GetWidth();
			}
			else 
			{
				width = this.box.GetWidth();
			}
		}
	}
	
	public void CalculateTop(ref float x, ref float y, ref float width, ref float height, Rect parentField)
	{
		if (this.box.GetMarginTopType() == Box.MarginType.PERCENTAGE) 
		{
			y += parentField.height * this.box.GetMarginTop();
			height -= parentField.height * this.box.GetMarginTop();
		}
		else if (this.box.GetMarginTopType() == Box.MarginType.PIXEL) 
		{
			y += this.box.GetMarginTop();
			height -= this.box.GetMarginTop();
		}
		else if (this.box.GetMarginTopType() == Box.MarginType.AUTO)
		{
			if (this.box.GetHeightType() == Box.SizeType.PERCENTAGE)
			{
				height = parentField.height *  this.box.GetHeight();
			}
			else if (this.box.GetHeightType() == Box.SizeType.PIXEL)
			{
				height = this.box.GetHeight ();
			}
			
			
			if (this.box.GetMarginBottomType ()  == Box.MarginType.AUTO)
			{
				// Look at the bottom, if it is also auto, center the box.
				
				float marginSize = (parentField.height - this.box.GetHeight()) / 2;
				
				y += marginSize;
				
			}
			else
			{
				// If the right is NOT auto, calculate the right FIRST
				float preHeight = height;
				CalculateBottom(ref x, ref y, ref width, ref height, parentField);
				
				// The left is then the remainder of the parent width - (boxwidth + marginright)
				
				y += parentField.height - preHeight;
				
				// Break ref
				return;
			}
			
		}
		
		// Calculate the bottom last
		CalculateBottom(ref x, ref y, ref width, ref height, parentField);
	}
	
	public void CalculateBottom(ref float x, ref float y, ref float width, ref float height, Rect parentField)
	{
		if (this.box.GetMarginBottomType() == Box.MarginType.PERCENTAGE) 
		{
			height -= parentField.height * this.box.GetMarginBottom();
		}
		else if (this.box.GetMarginBottomType() == Box.MarginType.PIXEL) 
		{
			height -= this.box.GetMarginBottom();
		}
		else if (this.box.GetMarginBottomType() == Box.MarginType.AUTO)
		{
			if (this.box.GetHeightType() == Box.SizeType.PERCENTAGE)
			{
				height = parentField.height * this.box.GetHeight();
			}
			else 
			{
				height = this.box.GetHeight();
			}
		}
	}
	
	public Rect GetParentField()
	{
		Rect parentField;
		if (this.parent != null)
		{
			parentField = this.parent.GetField();
		}
		else
		{
			parentField = new Rect(0, 0, Screen.width, Screen.height);
		}
		
		return parentField;
	}
	
	public virtual float RequestEstimatedHeight()
	{
		return 0.0f;
	}
}