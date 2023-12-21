using RozvrhHodin;
namespace UnitTesting
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestExportXML()
        {
            try
            {
                Rozvrh r = new Rozvrh();
                MetodyXML.ExportRozvrh(r, "test");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            try
            {
                List<Ucebna> ucebny = new List<Ucebna>();
                for (int i = 0; i < 5; i++)
                {
                    ucebny.Add(new Ucebna());
                }
                MetodyXML.ExportUcebna(ucebny, "test.xm");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            try
            {
                List<Ucitel> ucitele = new List<Ucitel>();
                for (int i = 0; i < 5; i++)
                {
                    ucitele.Add(new Ucitel());
                }
                MetodyXML.ExportUcitel(ucitele, "test.xml");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            try
            {
                List<Predmet> predmety = new List<Predmet>();
                for (int i = 0; i < 5; i++)
                {
                    predmety.Add(new Predmet());
                }
                MetodyXML.ExportPredmety(predmety, "test.xml");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Test]
        public void TestImporttXML()
        {
            try
            {
                MetodyXML.ImportRozvrh("importC4b.xml");
                MetodyXML.ImportPredmety();
                MetodyXML.ImportUcebny();
                MetodyXML.ImportUcitele();
            }
            catch (Exception ex) 
            {
                Assert.Fail(ex.Message);
            }

        }

        [Test]
        public void TestOhodnoceni()
        {
            try
            {
                Rozvrh test = MetodyXML.ImportRozvrh("importC4b.xml");
                test = Metody.OhodnotRozvrh(test);
                Console.WriteLine(test);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void TestVygenerujRozvrhAOhodnot()
        {
            try
            {
                List<Predmet> predmety = MetodyXML.ImportPredmety();
                List<Ucebna> ucebny = MetodyXML.ImportUcebny();
                List<Ucitel> ucitele = MetodyXML.ImportUcitele();
                Rozvrh rozvrh = new Rozvrh("Test", "C4b", predmety, ucebny, ucitele);
                rozvrh = Metody.OhodnotRozvrh(rozvrh);
                Console.WriteLine(rozvrh);
            }
            catch (Exception ex)
            {

            }
        }

    }
}