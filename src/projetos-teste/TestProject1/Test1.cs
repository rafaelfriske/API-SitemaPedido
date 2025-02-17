using System.Text.RegularExpressions;
using System.Text;

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        [DataRow("esperado ação", "esperado acao")]
        public void TestMethod1(string texto, string expect)
        {
            //arrange
            string result = null;
            //Act
            result = RemoveAcentos(texto);
            //Assert
            Assert.AreEqual(expect, result);

        }

        static string RemoveAcentos(string input)
        {
            // Normaliza a string para a forma D (decomposição)
            string normalizedString = input.Normalize(NormalizationForm.FormD);

            // Regex para identificar caracteres diacríticos (acentos)
            Regex regex = new Regex(@"\p{M}", RegexOptions.Compiled);

            // Remove os caracteres diacríticos
            string withoutDiacritics = regex.Replace(normalizedString, string.Empty);

            return withoutDiacritics;
        }
    }
}
