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
}
