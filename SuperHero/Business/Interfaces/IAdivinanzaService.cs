namespace SuperHeroWeb.Business.Interfaces
{
    public interface IAdivinanzaService
    {
        string ValidarNumero(int numeroUsuario);
        void ReiniciarJuegoPorQueAlPutoSeLeOcurre();
    }
}
