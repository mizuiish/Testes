using Calculadora;

namespace TesteMsTest
{
    [TestClass]
    public class TesteCalcMsTest
    {
        [TestMethod]
        public void TesteSomarDoisNumeros()
        {
            //arrange - prepara��o

            double pNum = 1;
            double sNum = 1;
            double rNum = 2; 
            
            //act - a��o

            var resultado = Calculadoraa.Somar(pNum, sNum);


            //asset - verifica��o

            Assert.AreEqual(rNum, resultado);

        }

        [DataTestMethod]

        [DataRow(1, 2, 3)]
        [DataRow(2, 2, 4)]
        [DataRow(2, 5, 7)]

        public void TestarSomarDoisNumerosLista(double pNum, double sNum, double rNum)
        {
            //Act
            var resultado = Calculadoraa.Somar(pNum, sNum);

            //Assert
            Assert.AreEqual(rNum, resultado);
        }
    }
}