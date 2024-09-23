using System;
using System.Collections.Generic;
using System.Net.Mime;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Library
{
	// Declare an array of Media objects
	private List<Media> biblioteque = new List<Media>();

	/// <summary>
	/// Ajouter un media (via sa référence : int) à la Bibliotheque (list)
	/// </summary>
	/// <param name="ref"></param>
	public void ajouterMedia(int ref)
	{
        biblioteque.Add(ref);
    }

    /// <summary>
    /// Supprimer un media (via sa référence : int) de la Bibliotheque (list)
    /// </summary>
    /// <param name="ref"></param>
    public void supprimerMedia(int ref)
	{		
        biblioteque.Remove(ref)
	}

    /// <summary>
    /// "Emprunter" un media (via sa référence : int) à la Bibliotheque (list)
    /// </summary>
    /// <param name="ref"></param>
    public int emprunterMedia(int ref)
	{
		mediaEmprunte = biblioteque.Remove(ref)
	}

	public static Library operator + (Media media)
	{
		if bibliotheque.empty()
		{
			throw new Exception("La bibliotheque est vide");
		} else 
		{
			ajouterMedia(media);
		}
	}

    public static Library operator -(int ref)
    {
        if bibliotheque.empty()
		{
            throw new Exception("La bibliotheque est vide");
        }
        else
        {
            supprimerMedia(ref);
        }
    }

    public Library()
	{
		//
		// TODO: Add constructor logic here
		// petit changement
	}
}