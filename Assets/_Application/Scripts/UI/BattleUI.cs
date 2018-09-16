using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public static BattleUI Current { get; private set; }

    public Image MonsterImage = null;
    public Slider AttackSlider = null;
    public Text EventText = null;
    public Animator BattleAnimator = null;
    public Button BattleButton = null;
    public Button EscapeButton = null;

    void Awake()
    {
        Current = this;
    }

    public void Reset()
    {
        MonsterImage.sprite = null;
        EventText.text = null;
    }
}