using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Librabry
{
	// Declare an array of Media objects
	private T[] biblioteque = new T[100];

	public T this[int i]
	{
		get { return (T)biblioteque[i]; }
		set { biblioteque[i] = value; }
	}

	public Librabry()
	{
		//
		// TODO: Add constructor logic here
		//petit changement
	}
}
