using System;
using System.Collections.Generic;

static class Extensions
{
	/**
	 * Broken, do not use as of 1/14/14
	 */
    public static List<T> Clone<T>(List<T> listToClone) where T: ICloneable
    {
		List<T> t = new List<T>();
		
		foreach (T item in listToClone)
		{
			t.Add ((T)item.Clone());
		}
		
        return t;
    }
}