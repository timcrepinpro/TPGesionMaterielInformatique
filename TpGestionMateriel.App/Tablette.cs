public class Tablette : Materiel
{
    public  double tailleEcran { get; set; }
    protected bool styletinclut { get; set; }
    public Tablette(string reference, string marque, string modele, bool disponible, string etat, double tailleEcran, bool styletinclut) : base(reference, marque, modele, disponible, etat)
    {
        this.tailleEcran = tailleEcran;
        this.styletinclut = styletinclut;
    }
    public override int CalculerDuréeMaxEmprunt()
    {        return 7;
    }
    public override string Afficherinformation()
    {     return $"Tablette - Référence: {reference}, Marque: {marque}, Modèle: {modele}, Disponible: {disponible}, État: {etat}, Taille de l'écran: {tailleEcran} pouces, Stylet inclus: {styletinclut}";
    }
}