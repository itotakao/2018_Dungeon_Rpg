using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public static BattleUI Current { get; private set; }

    // TODO : まとめすぎ　分けないと後で困りそう
    public Text PlayerNameText = null;
    public Image PlayerImage = null;
    public Slider PlayerHealthSlider = null;
    public Slider PlayerAttackSlider = null;

    public Image MonsterImage = null;
    public Slider MonsterHealthSlider = null;
    public Slider MonsterAttackSlider = null;

    public Animator BattleAnimator = null;
    public Button BattleButton = null;

    void Awake()
    {
        Current = this;
    }

    void Start()
    {
        Show(false);
    }

    public void Reset()
    {
        MonsterImage.sprite = null;
    }

    public void Show(bool isShow)
    {
        MonsterImage.enabled = isShow;
        MonsterImage.enabled = isShow;
        MonsterHealthSlider.gameObject.SetActive(isShow);
        MonsterAttackSlider.gameObject.SetActive(isShow);
    }
}