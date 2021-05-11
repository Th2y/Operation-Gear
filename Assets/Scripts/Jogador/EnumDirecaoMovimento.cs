public enum DirecaoMovimento
{
    Up,
    Down,
    Right,
    Left
}

public static class DirecaoMovimentoExtension
{
    public static DirecaoMovimento Oposta(this DirecaoMovimento direcao)
    {
        switch (direcao)
        {
            case DirecaoMovimento.Up:
                return DirecaoMovimento.Down;
            case DirecaoMovimento.Down:
                return DirecaoMovimento.Up;
            case DirecaoMovimento.Right:
                return DirecaoMovimento.Left;
            default:
                return DirecaoMovimento.Right;
        }
    }
}
