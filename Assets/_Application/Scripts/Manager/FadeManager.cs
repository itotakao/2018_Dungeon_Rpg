using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Current { get; private set; }

    public TurnManager TurnManager{ get { return TurnManager.Current; }}

    public bool isFadeOut = false;
    public bool isFadeIn = false;


    float alpha = 0;
    float speed = 0.02f;

    Image fadeImageCache = null;
    public Image FadeImage { get { return fadeImageCache ? fadeImageCache : GetComponent<Image>(); } }


    void Awake()
    {
        Current = this;
    }

    void Start()
    {
        FadeImage.ExChangeAlpha(alpha);
        //TurnManager.TurnText.ExChangeAlpha(alpha);
    }

    void Update()
    {
        if (isFadeIn)
        {
            StartFadeIn();
        }

        if (isFadeOut)
        {
            StartFadeOut();
        }
    }

    void StartFadeIn()
    {
        alpha -= speed;
        FadeImage.ExChangeAlpha(alpha);
        //TurnManager.TurnText.ExChangeAlpha(alpha);
        if (alpha <= 0)
        {
            isFadeIn = false;
            FadeImage.enabled = false;
            //TurnManager.TurnText.enabled = false;
        }
    }

    void StartFadeOut()
    {
        FadeImage.enabled = true;
        //TurnManager.TurnText.enabled = true;

        alpha += speed;
        FadeImage.ExChangeAlpha(alpha);
        //TurnManager.TurnText.ExChangeAlpha(alpha);
        if (alpha >= 1)
        {
            isFadeOut = false;
        }
    }
}