using UnityEngine.UI;

public static class GraphicExtension
{
    public static Graphic ExChangeAlpha(this Graphic graphic, float a)
    {
        var color = graphic.color;
        color.a = a;
        graphic.color = color;
        return graphic;
    }
}