using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public static BattleUI Current { get; private set; }

    public Image MonsterImage = null;
    public Slider HealthSlider = null;
    public Slider AttackSlider = null;
    public Animator BattleAnimator = null;
    public Button BattleButton = null;
    public Button EscapeButton = null;

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
        HealthSlider.gameObject.SetActive(isShow);
        AttackSlider.gameObject.SetActive(isShow);
    }
}