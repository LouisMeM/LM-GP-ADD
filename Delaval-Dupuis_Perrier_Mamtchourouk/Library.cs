using System.Collections.Generic;
using System;

public class Bibliotheque
{
    private List<Media> library = new List<Media>();
    private List<Emprunt> emprunts = new List<Emprunt>();

    public void AjouterMedia(Media media)
    {
        library.Add(media);
        Console.WriteLine($"Média '{media.Titre}' ajouté à la bibliothèque.");
    }

    public void SupprimerMedia(int reference)
    {
        Media mediaASupprimer = library.Find(m => m.Reference == reference);
        if (mediaASupprimer != null)
        {
            library.Remove(mediaASupprimer);
            Console.WriteLine($"Média '{mediaASupprimer.Titre}' supprimé de la bibliothèque.");
        }
        else
        {
            Console.WriteLine("Média non trouvé.");
        }
    }

    public bool EmprunterMedia(int reference, string utilisateur)
    {
        Media mediaAEmprunter = library.Find(m => m.Reference == reference);
        if (mediaAEmprunter != null && mediaAEmprunter.CopiesDisponibles > 0)
        {
            mediaAEmprunter.CopiesDisponibles--;
            emprunts.Add(new Emprunt(utilisateur, mediaAEmprunter));
            Console.WriteLine($"Média '{mediaAEmprunter.Titre}' emprunté par {utilisateur}.");
            return true;
        }
        else if (mediaAEmprunter != null && mediaAEmprunter.CopiesDisponibles == 0)
        {
            Console.WriteLine($"Média '{mediaAEmprunter.Titre}' est en rupture de stock.");
            return false;
        }
        else
        {
            Console.WriteLine("Média non trouvé.");
            return false;
        }
    }

    public bool RetournerMedia(int reference, string utilisateur)
    {
        Emprunt emprunt = emprunts.Find(e => e.MediaEmprunte.Reference == reference && e.Utilisateur == utilisateur);
        if (emprunt != null)
        {
            emprunt.MediaEmprunte.CopiesDisponibles++;
            emprunts.Remove(emprunt);
            Console.WriteLine($"Média '{emprunt.MediaEmprunte.Titre}' retourné par {utilisateur}.");
            return true;
        }
        else
        {
            Console.WriteLine("Aucun emprunt correspondant trouvé.");
            return false;
        }
    }

    public List<Media> RechercherMedia(string recherche)
    {
        List<Media> resultats = library
            .Where(m => m.Titre.Contains(recherche, StringComparison.OrdinalIgnoreCase) ||
                        m.Auteur.Contains(recherche, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (resultats.Count > 0)
        {
            Console.WriteLine("Médias trouvés :");
            foreach (var media in resultats)
            {
                Console.WriteLine($"- {media.Titre} par {media.Auteur} (Copies disponibles : {media.CopiesDisponibles})");
            }
        }
        else
        {
            Console.WriteLine("Aucun média trouvé.");
        }

        return resultats;
    }

    public void ListerEmpruntsUtilisateur(string utilisateur)
    {
        var empruntsUtilisateur = emprunts.Where(e => e.Utilisateur == utilisateur).ToList();

        if (empruntsUtilisateur.Count > 0)
        {
            Console.WriteLine($"Médias empruntés par {utilisateur} :");
            foreach (var emprunt in empruntsUtilisateur)
            {
                Console.WriteLine($"- {emprunt.MediaEmprunte.Titre} par {emprunt.MediaEmprunte.Auteur}");
            }
        }
        else
        {
            Console.WriteLine($"{utilisateur} n'a emprunté aucun média.");
        }
    }

    public void AfficherStatistiques()
    {
        int totalMedias = library.Count;
        int totalExemplaires = library.Sum(m => m.CopiesTotales);
        int empruntsEnCours = emprunts.Count;
        int exemplairesDisponibles = library.Sum(m => m.CopiesDisponibles);

        Console.WriteLine("Statistiques de la Bibliothèque :");
        Console.WriteLine($"- Nombre total de médias : {totalMedias}");
        Console.WriteLine($"- Nombre total d'exemplaires : {totalExemplaires}");
        Console.WriteLine($"- Nombre d'exemplaires empruntés : {empruntsEnCours}");
        Console.WriteLine($"- Nombre d'exemplaires disponibles : {exemplairesDisponibles}");
    }
}
