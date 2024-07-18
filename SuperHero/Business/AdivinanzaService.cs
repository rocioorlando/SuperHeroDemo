using SuperHeroWeb.Business.Interfaces;

namespace SuperHeroWeb.Business
{
    public class AdivinanzaService: IAdivinanzaService
    {
        //esto es lo que necesito que no se borre, las declaro para que no cambien de valor por que estoy con un singleton
        private int numeroRandom;
        private int intentos = 0;

        public AdivinanzaService()
        {
            //que es lo que necesito que se mantenga en memoria
            //aca obtengo el numero random entre 1 y 100
            numeroRandom = new Random().Next(1, 100);
        }

        public void ReiniciarJuegoPorQueAlPutoSeLeOcurre() 
        {
            intentos = 0;
            numeroRandom = new Random().Next(1, 100);
        }

        public string ValidarNumero(int numeroUsuario) 
        {
            if (intentos < 10)
            {
                if (numeroRandom == numeroUsuario)
                {
                    return "Ganaste" + intentos;
                }
                else if (numeroRandom < numeroUsuario)
                {
                    intentos++;
                    return "El numero es menor" + intentos;
                }
                else if (numeroRandom > numeroUsuario)
                {
                    intentos++;
                    return "El numero es mayor" + intentos;
                }
            } 
            return "A tu casa pete" + intentos;
        }

        public int HacerCalculadora(int numero, int numero1) 
        {
            var resultadoSuma = numero + numero1;
            var resultadoResta = numero - numero1;
            var resultadoMultiplicacion = numero * numero1;
            var resultadoDivision = numero / numero1;
            return resultadoSuma + resultadoResta + resultadoMultiplicacion + resultadoDivision;
        }
    }
}
