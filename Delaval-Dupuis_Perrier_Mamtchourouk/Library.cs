using System;
using System.Collections.Generic;
using System.Net.Mime;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Librabry
{
	// Declare an array of Media objects
	private List<Media> biblioteque = new List<Media>();


	public void ajouterMedia(int ref)
	{
        biblioteque.Add(ref);
    }

	public void supprimerMedia(int ref)
	{		
        biblioteque.Remove(ref)
	}

	public int emprunterMedia(int ref)
	{
		mediaEmprunte = biblioteque.Remove(ref)
	}

	public Librabry()
	{
		//
		// TODO: Add constructor logic here
		// petit changement
	}
}
