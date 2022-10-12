namespace Calculadora
{
    public static class Calculadoraa
    {
        public static double Somar(double pNum, double sNum)
        {
            return (pNum + sNum);
        }

        public static string CalcularImc(double kg, double cm)
        {
            double resultado = kg / (cm * cm);

            if (resultado < 18.5)
            {
                return "Abaixo do peso.";
            }
            if (resultado < 24.5)
            {
                return "Peso normal";
            }
            if (resultado < 29.9)
            {
                return "Sobrepeso.";
            }
            if (resultado < 34.9)
            {
                return "Obesidade grau 1.";
            }
            if (resultado < 39.9)
            {
                return "Obesidade grau 2.";
            }
            else
            {
                return "Obesidade grau 3";
            }
        }


    //classes comuns precisa instanciar pra chamar o método
    //Calculadora calc = new Calculadora;
    //calc.somar();

    //classe estatica (static) não precisa instaciar, basta chamar o método



    }
}