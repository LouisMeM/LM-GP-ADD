public class Media
{
    public int Reference { get; set; }
    public string Titre { get; set; }
    public string Auteur { get; set; }
    public int CopiesDisponibles { get; set; }
    public int CopiesTotales { get; set; }

    public Media(int reference, string titre, string auteur, int copiesTotales)
    {
        Reference = reference;
        Titre = titre;
        Auteur = auteur;
        CopiesDisponibles = copiesTotales;
        CopiesTotales = copiesTotales;
    }
}


public class Emprunt
{
    public string Utilisateur { get; set; }
    public Media MediaEmprunte { get; set; }

    public Emprunt(string utilisateur, Media media)
    {
        Utilisateur = utilisateur;
        MediaEmprunte = media;
    }
}