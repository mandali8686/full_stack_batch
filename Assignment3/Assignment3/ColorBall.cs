namespace Assignment3;

public class Color
{
    public int Red { get; private set; }
    public int Green { get; private set; }
    public int Blue { get; private set; }
    public int Alpha { get; private set; }

    public Color(int red, int green, int blue, int alpha = 255)
    {
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }

    public int GetGrayscale() => (Red + Green + Blue) / 3;
}

public class Ball
{
    private Color BallColor { get; set; }
    private int Size { get; set; }
    private int ThrowCount { get; set; } = 0;

    public Ball(Color color, int size)
    {
        BallColor = color;
        Size = size;
    }

    public void Pop() => Size = 0;

    public void Throw()
    {
        if (Size > 0)
            ThrowCount++;
    }

    public int GetThrowCount() => ThrowCount;
}