public class OrdinateurPortable : Materiel
{

    protected  int ramGO { get; set; }
    protected bool possedeChargeur { get; set; }
    public OrdinateurPortable(string reference, string marque, string modele, bool disponible, string etat, int ramGO, bool possedeChargeur) : base(reference, marque, modele, disponible, etat)
    {
        this.ramGO = ramGO;
        this.possedeChargeur = possedeChargeur;
    }




    public override int CalculerDuréeMaxEmprunt()
    {
        return 14;
    }
    public override string Afficherinformation()
    {
        return $"Ordinateur Portable - Référence: {reference}, Marque: {marque}, Modèle: {modele}, Disponible: {(disponible ? "Vrai" : "Faux")}, État: {etat}, RAM: {ramGO} Go, Possède un chargeur: {(possedeChargeur ? "Vrai" : "Faux")}";
    }
    public void setramGO(int ramGO)
    {
        this.ramGO = ramGO;
    }
    public void setpossedeChargeur(bool possedeChargeur)
    {
        this.possedeChargeur = possedeChargeur;
    }
    public int getramGO()
    {
        return this.ramGO;
    }
    public bool getpossedeChargeur()
    {
        return this.possedeChargeur;
    }
}