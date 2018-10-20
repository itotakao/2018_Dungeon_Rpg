using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public static SkillUI Current { get; private set; }

    public PlayerManager PlayerManager{ get { return PlayerManager.Current; }}

    public Button SkillAButton = null;
    public Button SkillBButton = null;
    public Button SkillCButton = null;

    public Text SkillAButtonText = null;
    public Text SkillBButtonText = null;
    public Text SkillCButtonText = null;

    void Awake()
    {
        Current = this;
    }

    void Start()
    {
        Initilize();
    }

    void Initilize()
    {
        SkillAButtonText.text = PlayerManager.SkillA.GetSkillName();
        SkillBButtonText.text = PlayerManager.SkillB.GetSkillName();
        SkillCButtonText.text = PlayerManager.SkillC.GetSkillName();
    }

    public void OnButtonUseSkillA()
    {
        PlayerManager.SkillA.Use();
    }

    public void OnButtonUseSkillB()
    {
        PlayerManager.SkillB.Use();
    }

    public void OnButtonUseSkillC()
    {
        PlayerManager.SkillC.Use();
    }
}