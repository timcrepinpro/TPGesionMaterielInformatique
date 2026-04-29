namespace TpGestionMateriel.Tests;

[TestClass]
public sealed class MSTest
{
    [TestMethod]
    public void AjouterMateriel_RetourneTrue_QuandMaterielValide()
    {
        GestionMateriel gestion = new GestionMateriel();
        OrdinateurPortable pc = new OrdinateurPortable("PC001", "Dell", "XPS 13", true, "En service", 16, true);
        // Act
        bool resultat = gestion.AjouterMateriel(pc);
        // Assert
        Assert.IsTrue(resultat);
    }
    [TestMethod]
    public void AjouterMateriel_RetourneFalse_QuandMaterielNull()
    {
        GestionMateriel gestion = new GestionMateriel();
        // Act
        bool resultat = gestion.AjouterMateriel(null);
        // Assert
        Assert.IsFalse(resultat);
    }
    [TestMethod]
    public void AjouterMateriel_RetourneFalse_QuandMaterielExisteDeja()
    {
        GestionMateriel gestion = new GestionMateriel();
        OrdinateurPortable pc = new OrdinateurPortable("PC001", "Dell", "XPS 13", true, "En service", 16, true);
        OrdinateurPortable pc1 = pc;
        gestion.AjouterMateriel(pc);
        gestion.AjouterMateriel(pc1);
        // Act
        bool resultat = gestion.AjouterMateriel(pc1);
        // Assert
        Assert.IsFalse(resultat);
    }
    //Recherche d’un matériel existant
    [TestMethod]
    public void EmprunterMateriel_RetourneTrue_QuandMaterielexiste()
    {
        GestionMateriel gestion = new GestionMateriel();
        OrdinateurPortable pc = new OrdinateurPortable("PC001", "Dell", "XPS 13", true, "En service", 16, true);
        gestion.AjouterMateriel(pc);
        // Act
        string pcTrouve = gestion.RechercherParReference("PC001");
        // Assert
        Assert.AreEqual("Ordinateur Portable - Référence: PC001, Marque: Dell, Modèle: XPS 13, Disponible: Vrai, État: En service, RAM: 16 Go, Possède un chargeur: Vrai", pcTrouve.ToString());   
    }
    //Recherche d’un matériel inexistant&
    [TestMethod]
    public void EmprunterMateriel_RetourneFalse_QuandMaterielNexistePas()
    {
        GestionMateriel gestion = new GestionMateriel();
        OrdinateurPortable pc = new OrdinateurPortable("PC001", "Dell", "XPS 13", true, "En service", 16, true);
        gestion.AjouterMateriel(pc);
        // Act
        string pcTrouve = gestion.RechercherParReference("PC002");
        // Assert
        Assert.AreEqual("null", pcTrouve.ToString());
     }
     // empreunter un matériel disponible
    [TestMethod]
    public void EmprunterMateriel_RetourneTrue_QuandMaterielDisponible()
    {
        GestionMateriel gestion = new GestionMateriel();
        OrdinateurPortable pc = new OrdinateurPortable("PC001", "Dell", "XPS 13", true, "En service", 16, true);
        gestion.AjouterMateriel(pc);
        // Act
        gestion.EmprunterMateriel("PC001");
        // Assert
        Assert.IsFalse(pc.getdisponible());
    }
    // emprunter un matériel non disponible
    [TestMethod]
    public void EmprunterMateriel_RetourneFalse_QuandMaterielNonDisponible()
    {
        GestionMateriel gestion = new GestionMateriel();
        OrdinateurPortable pc = new OrdinateurPortable("PC001", "Dell", "XPS 13", false, "En service", 16, true);
        gestion.AjouterMateriel(pc);
        // Act
        gestion.EmprunterMateriel("PC001");
        // Assert
        Assert.IsFalse(pc.getdisponible());
    }
    //Emprunt d’un matériel déjà emprunté
    [TestMethod]
    public void EmprunterMateriel_RetourneFalse_QuandMaterielDejaEmprunte()
    {
        GestionMateriel gestion = new GestionMateriel();
        OrdinateurPortable pc = new OrdinateurPortable("PC001", "Dell", "XPS 13", true, "En service", 16, true);
        gestion.AjouterMateriel(pc);
        // Act
        gestion.EmprunterMateriel("PC001");
        gestion.EmprunterMateriel("PC001");
        // Assert
        Assert.IsFalse(pc.getdisponible());
     }
     //Emprunt d’un ordinateur sans chargeur
    [TestMethod]
    public void EmprunterMateriel_RetourneFalse_QuandOrdinateurSansChargeur()
    {
        GestionMateriel gestion = new GestionMateriel();
        OrdinateurPortable pc = new OrdinateurPortable("PC001", "Dell", "XPS 13", true, "En service", 16, false);
        gestion.AjouterMateriel(pc);
        // Act
        gestion.EmprunterMateriel("PC001");
        // Assert
        Assert.IsFalse(pc.getdisponible());
     }
     //Emprunt d’un vidéoprojecteur sans câble HDMI
    [TestMethod]
    public void EmprunterMateriel_RetourneFalse_QuandVideoprojecteurSansCableHDMI()
    {
        GestionMateriel gestion = new GestionMateriel();
        VideoProjecteur vp = new VideoProjecteur("VP001", "Epson", "PowerLite", true, "En service", 3000, false);
        gestion.AjouterMateriel(vp);
        // Act
        gestion.EmprunterMateriel("VP001");
        // Assert
        Assert.IsFalse(vp.getdisponible());
     }
     //Retour d’un matériel emprunté
    [TestMethod]
    public void RetourMateriel_RetourneTrue_QuandMaterielEmprunte()
    {
        GestionMateriel gestion = new GestionMateriel();
        OrdinateurPortable pc = new OrdinateurPortable("PC001", "Dell", "XPS 13", true, "En service", 16, true);
        gestion.AjouterMateriel(pc);
        // Act
        gestion.EmprunterMateriel("PC001");
        gestion.RetournerMateriel("PC001");
        // Assert
        Assert.IsTrue(pc.getdisponible());
    }
    //Retour d’un matériel non emprunté
    [TestMethod]
    public void RetourMateriel_RetourneFalse_QuandMaterielNonEmprunte()
    {
        GestionMateriel gestion = new GestionMateriel();
        OrdinateurPortable pc = new OrdinateurPortable("PC001", "Dell", "XPS 13", true, "En service", 16, true);
        gestion.AjouterMateriel(pc);
        // Act
        gestion.RetournerMateriel("PC001");
        // Assert
        Assert.IsTrue(pc.getdisponible());
    }
    // Calcul de la durée maximale totale
    [TestMethod]
    public void CalculerDuréeMaxEmprunt_RetourneDureeCorrecte()
    {
        GestionMateriel gestion = new GestionMateriel();
        OrdinateurPortable pc = new OrdinateurPortable("PC001", "Dell", "XPS 13", true, "En service", 16, true);
        VideoProjecteur vp = new VideoProjecteur("VP001", "Epson", "PowerLite", true, "En service", 3000, true);
        Tablette tablette = new Tablette("TAB001", "Apple", "iPad Pro", true, "En service", 12.9, true);
        gestion.AjouterMateriel(pc);
        gestion.AjouterMateriel(vp);
        gestion.AjouterMateriel(tablette);
        // Act
        gestion.AfficherDuréeMaxEmprunt();
        // Assert
        Assert.AreEqual(7, tablette.CalculerDuréeMaxEmprunt());
        Assert.AreEqual(14, pc.CalculerDuréeMaxEmprunt());
        Assert.AreEqual(3, vp.CalculerDuréeMaxEmprunt());
    }
    //Recherche par état
    [TestMethod]
    public void RechercherParEtat_RetourneMaterielsCorrects()
    {
        GestionMateriel gestion = new GestionMateriel();
        OrdinateurPortable pc1 = new OrdinateurPortable("PC001", "Dell", "XPS 13", true, "En service", 16, true);
        OrdinateurPortable pc2 = new OrdinateurPortable("PC002", "Dell", "XPS 13", true, "Hors service", 16, true);
        gestion.AjouterMateriel(pc1);
        gestion.AjouterMateriel(pc2);
        // Act
        gestion.RechercherParetat("En service");
        gestion.RechercherParetat("Hors service");
        // Assert
        Assert.AreEqual("Ordinateur Portable - Référence: PC001, Marque: Dell, Modèle: XPS 13, Disponible: Vrai, État: En service, RAM: 16 Go, Possède un chargeur: Vrai", gestion.RechercherParetat("En service").ToString());
        Assert.AreEqual("Ordinateur Portable - Référence: PC002, Marque: Dell, Modèle: XPS 13, Disponible: Vrai, État: Hors service, RAM: 16 Go, Possède un chargeur: Vrai", gestion.RechercherParetat("Hors service").ToString());
    }
    //Compter les matériels disponibles
    [TestMethod]
    public void CompterMaterielsDisponibles_RetourneNombreCorrect()
    {
        GestionMateriel gestion = new GestionMateriel();
        OrdinateurPortable pc1 = new OrdinateurPortable("PC001", "Dell", "XPS 13", true, "En service", 16, true);
        OrdinateurPortable pc2 = new OrdinateurPortable("PC002", "Dell", "XPS 13", false, "En service", 16, true);
        gestion.AjouterMateriel(pc1);
        gestion.AjouterMateriel(pc2);
        // Act
        int nombreDisponibles = gestion.Comterdisponible();
        // Assert
        Assert.AreEqual(2, nombreDisponibles);
    }
    
}