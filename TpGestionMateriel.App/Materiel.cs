public abstract class Materiel
{
    protected string reference { get; set; }
    protected string marque { get; set; }
    protected string modele { get; set; }
    protected bool disponible { get; set; }
    protected string etat { get; set; }

    public Materiel(string reference, string marque, string modele, bool disponible, string etat)
    {
        this.reference = reference;
        this.marque = marque;
        this.modele = modele;
        this.disponible = disponible;
        this.etat = etat;
    }
    public abstract string CalculerDuréeMaxEmprunt();
    public abstract string Afficherinformation();
    public void setreference(string reference)
    {
        this.reference = reference;
    }
    public void setmarque(string marque)
    {
        this.marque = marque;
    }
    public void setmodele(string modele)
    {
        this.modele = modele;
    }
    public void setdisponible(bool disponible)
    {
        this.disponible = disponible;
    }
    public void setetat(string etat)
    {
        this.etat = etat;
    }
    public string getreference()
    {
        return this.reference;
    }
    public string getmarque()
    {
        return this.marque;
    }
    public string getmodele()
    {
        return this.modele;
    }
    public bool getdisponible()
    {
        return this.disponible;
    }
    public string getetat()
    {
        return this.etat;
    }


}