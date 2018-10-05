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

    public static Graphic ExChangeYellow(this Graphic graphic)
    {
        graphic.color = ExColor.Yellow;
        return graphic;
    }

    public static Graphic ExChangeGray(this Graphic graphic)
    {
        graphic.color = ExColor.Gray;
        return graphic;
    }

    public static Graphic ExChangeWhite(this Graphic graphic)
    {
        graphic.color = ExColor.White;
        return graphic;
    }
}