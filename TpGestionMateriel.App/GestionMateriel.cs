public class GestionMateriel
{
    private List<Materiel> materiels;

    public GestionMateriel()
    {
        materiels = new List<Materiel>();
    }

    public bool AjouterMateriel(Materiel materiel)
    {
        if (materiel == null)
        {
            Console.WriteLine("Le matériel ne peut pas être null.");
            return false;
        }
        if (materiels.Contains(materiel))
        {
            Console.WriteLine("Le matériel existe déjà dans la liste.");
            return false;
        }
        materiels.Add(materiel);
        return true;
    }

    public void AfficherTousLesMateriels()
    {
        foreach (var materiel in materiels)
        {
            Console.WriteLine(materiel.Afficherinformation());
        }
    }
    public void AfficherMaterielsDisponibles()
    {
        foreach (var materiel in materiels)
        {
            if (materiel.getdisponible())
            {
                Console.WriteLine(materiel.Afficherinformation());
            }
        }
    }
    public void AfficherDuréeMaxEmprunt()
    {
        foreach (var materiel in materiels)
        {
            Console.WriteLine(materiel.CalculerDuréeMaxEmprunt());
        }
    }
    public void EmprunterMateriel(string reference)
    {
        try
        {
            foreach (var materiel in materiels)
            {
                if (materiel.getreference() == reference)
                {
                    if (materiel.getdisponible() && materiel.getetat()!="Hors service" )
                    {
                        materiel.setdisponible(false);
                        Console.WriteLine($"Le matériel {reference} a été emprunté.");
                    }
                    else
                    {
                        Console.WriteLine($"Le matériel {reference} n'est pas disponible.");
                    }
                    return;
                }
                Console.WriteLine($"Le matériel {reference} n'existe pas.");
                
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Une erreur est survenue lors de l'emprunt du matériel {reference}: {ex.Message}");
        }
        
        
    }
    public void RetournerMateriel(string reference)
    {
        foreach (var materiel in materiels)
        {
            if (materiel.getreference() == reference)
            {
                if (!materiel.getdisponible())
                {
                    materiel.setdisponible(true);
                    Console.WriteLine($"Le matériel {reference} a été retourné.");
                }
                else
                {
                    Console.WriteLine($"Le matériel {reference} n'était pas emprunté.");
                }
                return;
            }
        }
        Console.WriteLine($"Le matériel {reference} n'existe pas.");
    }
    public string RechercherParReference(string reference)
    {
        foreach (var materiel in materiels)
        {
            if (materiel.getreference() == reference)
            {
                return materiel.Afficherinformation();
            }
        }
        return "null";
    }

    public void setMateriels(List<Materiel> materiels)
    {
        this.materiels = materiels;
    }
    public List<Materiel> getMateriels()
    {
        return this.materiels;
    }

   

}