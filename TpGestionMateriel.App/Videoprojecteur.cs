public class VideoProjecteur : Materiel
{
    protected int lumens { get; set; }
    protected bool cableHDMIInclus { get; set; }
    public VideoProjecteur(string reference, string marque, string modele, bool disponible, string etat, int lumens, bool cableHDMIInclus) : base(reference, marque, modele, disponible, etat)
    {
        this.lumens = lumens;
        this.cableHDMIInclus = cableHDMIInclus;
    }
    public override string CalculerDuréeMaxEmprunt()
    {        return "La durée maximale d'emprunt pour un vidéo projecteur est de 3 jours.";
    }
    public override string Afficherinformation()
    {     return $"Vidéo projecteur - Référence: {reference}, Marque: {marque}, Modèle: {modele}, Disponible: {disponible}, État: {etat}, Lumens: {lumens}, Cable HDMI inclus: {cableHDMIInclus}";
    }
}