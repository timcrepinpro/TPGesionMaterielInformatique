namespace TpGestionMateriel.App;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        OrdinateurPortable pc1 = new OrdinateurPortable("PC001", "Dell", "XPS 13", true, "En service", 16, true);
        OrdinateurPortable pc2 = new OrdinateurPortable("PC002", "Dell", "XPS 13", true, "En service", 16, false);
        OrdinateurPortable pc3 = pc2;
        Tablette tablette1 = new Tablette("TAB001", "Apple", "iPad Pro", true, "En service", 12.9, true);
        VideoProjecteur vp1 = new VideoProjecteur("VP001", "Epson", "PowerLite", true, "En service", 3000, true);
        VideoProjecteur vp2 = new VideoProjecteur("VP002", "Epson", "PowerLite", true, "En service", 3000, false);
        GestionMateriel gestion = new GestionMateriel();
        gestion.AjouterMateriel(pc1);
        gestion.AjouterMateriel(pc2);
        gestion.AjouterMateriel(pc3);
        gestion.AjouterMateriel(tablette1);
        gestion.AjouterMateriel(vp1);
        gestion.AjouterMateriel(vp2);
    }
}
