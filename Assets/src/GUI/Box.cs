using UnityEngine;
using System.Text.RegularExpressions;

public class Box
{
	/**
	 * Possible values for Margins:
	 * 
	 * "auto"
	 * "[int]px"
	 * float between 0 and 1 inclusive
	 */
	private MarginType marginTypeTop = MarginType.AUTO;
	private MarginType marginTypeRight = MarginType.AUTO;
	private MarginType marginTypeLeft = MarginType.AUTO;
	private MarginType marginTypeBottom = MarginType.AUTO;
	
	private SizeType widthType = SizeType.PIXEL;
	private SizeType heightType = SizeType.PIXEL;
	
	private float marginTop = 0.0f;
	private float marginRight = 0.0f;
	private float marginLeft = 0.0f;
	private float marginBottom = 0.0f;
	private const float INVALID = -1f;
	private float width = 1;
	private float height = 1;
	
	/**
	 * Default Constructor
	 */
	public Box()
	{
	}
	
	/**
	 * Copy constructor
	 */
	public Box(Box b)
	{
		this.marginTop = b.marginTop;
		this.marginTypeTop = b.marginTypeTop;
		this.marginRight = b.marginRight;
		this.marginTypeRight = b.marginTypeRight;
		this.marginLeft = b.marginLeft;
		this.marginTypeLeft = b.marginTypeLeft;
		this.marginBottom = b.marginBottom;
		this.marginTypeBottom = b.marginTypeBottom;
		
		this.width = b.width;
		this.height = b.height;
		this.widthType = b.widthType;
		this.heightType = b.heightType;
	}
	
	/**
	 * Set the value of the Margin Top to a percentage.
	 */
	public Box SetMarginTop(float percentage)
	{
		this.marginTypeTop = MarginType.PERCENTAGE;
		this.marginTop = percentage;
		
		return this;
	}
	
	/**
	 * Set the value of the Margin Top to "auto" or to a pixel value.
	 */
	public Box SetMarginTop(string margin)
	{
		float width = INVALID;
		
		if (margin.ToLower().Equals("auto"))
		{
			this.marginTypeTop = MarginType.AUTO;
			this.marginTop = width;
		}
		else
		{
			string[] marginPx = Regex.Split(margin, @"\D+");
			
			if (marginPx.Length > 0) 
			{
				
				float.TryParse(marginPx[0], out width);
				
				this.marginTypeTop = MarginType.PIXEL;
				this.marginTop = width;
			}
			
		}
		
		return this;
	}
	
	/**
	 * Set the value of the Margin Left to a percentage.
	 */
	public Box SetMarginLeft(float percentage)
	{
		this.marginTypeLeft = MarginType.PERCENTAGE;
		this.marginLeft = percentage;
		
		return this;
	}
	
	/**
	 * Set the value of the Margin Top to "auto" or to a pixel value.
	 */
	public Box SetMarginLeft(string margin)
	{
		float width = INVALID;
		
		if (margin.ToLower().Equals("auto"))
		{
			this.marginTypeLeft = MarginType.AUTO;
			this.marginLeft = width;
		}
		else
		{
			string[] marginPx = Regex.Split(margin, @"\D+");
			
			if (marginPx.Length > 0) 
			{
				
				float.TryParse(marginPx[0], out width);
				
				this.marginTypeLeft = MarginType.PIXEL;
				this.marginLeft = width;
			}
			
		}
		
		return this;
	}
	
	/**
	 * Set the value of the Margin Right to a percentage.
	 */
	public Box SetMarginRight(float percentage)
	{
		this.marginTypeRight = MarginType.PERCENTAGE;
		this.marginRight = percentage;
		
		return this;
	}
	
	/**
	 * Set the value of the Margin Right to "auto" or to a pixel value.
	 */
	public Box SetMarginRight(string margin)
	{
		float width = INVALID;
		
		if (margin.ToLower().Equals("auto"))
		{
			this.marginTypeRight = MarginType.AUTO;
			this.marginRight = width;
		}
		else
		{
			string[] marginPx = Regex.Split(margin, @"\D+");
			
			if (marginPx.Length > 0) 
			{
				
				float.TryParse(marginPx[0], out width);
				
				this.marginTypeRight = MarginType.PIXEL;
				this.marginRight = width;
			}
			
		}
		
		return this;
	}
	
	/**
	 * Set the value of the Margin Bottom to a percentage.
	 */
	public Box SetMarginBottom(float percentage)
	{
		this.marginTypeBottom = MarginType.PERCENTAGE;
		this.marginBottom = percentage;
		
		return this;
	}
	
	/**
	 * Set the value of the Margin Bottom to "auto" or to a pixel value.
	 */
	public Box SetMarginBottom(string margin)
	{
		float height = INVALID;
		
		if (margin.ToLower().Equals("auto"))
		{
			this.marginTypeBottom = MarginType.AUTO;
			this.marginBottom = height;
		}
		else
		{
			string[] marginPx = Regex.Split(margin, @"\D+");
			
			if (marginPx.Length > 0) 
			{
				
				float.TryParse(marginPx[0], out height);
				
				this.marginTypeBottom = MarginType.PIXEL;
				this.marginBottom = height;
			}
			
		}
		
		return this;
	}
	
	/**
	 * Get the Margin Type for the Margin Top
	 */
	public MarginType GetMarginTopType ()
	{
		return this.marginTypeTop;
	}
	
	/**
	 * Get the Margin Type for the Margin Left
	 */
	public MarginType GetMarginLeftType ()
	{
		return this.marginTypeLeft;
	}
	
	/**
	 * Get the Margin Type for the Margin Right
	 */
	public MarginType GetMarginRightType ()
	{
		return this.marginTypeRight;
	}
	
	/**
	 * Get the Margin Type for the Margin Bottom
	 */
	public MarginType GetMarginBottomType ()
	{
		return this.marginTypeBottom;
	}
	
	/**
	 * Get the Margin Top
	 */
	public float GetMarginTop ()
	{
		return this.marginTop;
	}
	
	/**
	 * Get the Margin Left
	 */
	public float GetMarginLeft ()
	{
		return this.marginLeft;
	}
	
	/**
	 * Get the Margin Right
	 */
	public float GetMarginRight ()
	{
		return this.marginRight;
	}
	
	/**
	 * Get the Margin Bottom
	 */
	public float GetMarginBottom ()
	{
		return this.marginBottom;
	}
	
	/**
	 * Get the width of the box
	 */
	public float GetWidth()
	{
		return this.width;
	}
	
	public SizeType GetWidthType()
	{
		return this.widthType;
	}
	
	/**
	 * Set the width of the box
	 */
	public Box SetWidth(float width)
	{
		this.width = width;
		this.widthType = SizeType.PERCENTAGE;
		return this;
	}
	
	public Box SetWidth (string pixels)
	{
		float width = 0;
		string[] widthPx = Regex.Split(pixels, @"\D+");
			
		if (widthPx.Length > 0) 
		{
			
			float.TryParse(widthPx[0], out width);
			
			this.widthType = SizeType.PIXEL;
			this.width = width;
		}
		
		return this;
	}
	
	/**
	 * Get the height of the box
	 */
	public float GetHeight()
	{
		return this.height;
	}
	
	public SizeType GetHeightType()
	{
		return this.heightType;
	}
	
	/**
	 * Set the height of the box
	 */
	public Box SetHeight(float height)
	{
		this.height = height;
		this.heightType = SizeType.PERCENTAGE;
		return this;
	}
	
	public Box SetHeight (string pixels)
	{
		float height = 0;
		string[] heightPx = Regex.Split(pixels, @"\D+");
			
		if (heightPx.Length > 0) 
		{
			
			float.TryParse(heightPx[0], out height);
			
			this.heightType = SizeType.PIXEL;
			this.height = height;
		}
		
		return this;
	}
	
	/**
	 * 
	 */
	public enum MarginType
	{
		AUTO,
		PIXEL,
		PERCENTAGE
	}
	
	
	public enum SizeType
	{
		PIXEL,
		PERCENTAGE
	}
}
