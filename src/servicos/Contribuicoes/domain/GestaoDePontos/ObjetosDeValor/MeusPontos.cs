namespace domain.GestaoDePontos.ObjetosDeValor;
public class MeusPontos
{
    public MeusPontos(int pontos, double valorDosPontos) 
        => ValorDosPontosConvertidos = pontos * valorDosPontos;
        
    public double ValorDosPontosConvertidos { get; private set; }
}
