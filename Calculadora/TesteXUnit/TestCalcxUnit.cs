using Calculadora;

namespace TesteXUnit
{
    public class TesteXUnit
    {
        [Fact]
        public void TestCalcxUnit()
        {

            //arrange
            double pNum = 1;
            double sNum = 1;
            double rNum = 2;

            //act
            var resultado = Calculadoraa.Somar(pNum, sNum);

            //assert
            Assert.Equal(rNum, resultado);
        }

        [Theory]

        [InlineData(2, 2, 4)]
        [InlineData(1, 1, 2)]
        [InlineData(2, 3, 5)]
        public void SomarDoisNumerosLista(double pNum, double sNum, double rNum)
        {
            //act 
            var resultado = Calculadoraa.Somar(pNum, sNum);

            //assert
            Assert.Equal(rNum, resultado);
        }

        [Theory]


        [InlineData(90, 160, 32.5)]
        [InlineData(50, 170, 17.3)]
        [InlineData(73, 166, 26.5)]
        [InlineData(75, 183, 22.4)]

        public void CalcImc(double kg, double cm, double rNum)
        {
            var resultado = Calculadoraa.CalcularImc(kg, cm);

            Assert.Equal(rNum, resultado);
        }

    }
}
