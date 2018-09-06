using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class HealCard : MonoBehaviour
{
    public PlayerManager PlayerManager { get { return PlayerManager.Current; } }
    public LogManager LogManager { get { return LogManager.Current; } }
    public GameManager GameManager { get { return GameManager.Current; } }

    public string Title;
    public string Message;

    Text titleCache = null;
    public Text TitleText
    {
        get { return titleCache ? titleCache : transform.Find("Canvas").transform.Find("Root").transform.Find("Title").GetComponent<Text>(); }
    }

    Text messageCache = null;
    public Text MessageText
    {
        get { return messageCache ? messageCache : transform.Find("Canvas").transform.Find("Root").transform.Find("Message").GetComponent<Text>(); }
    }

    void OnGUI()
    {
        TitleText.text = Title;
        MessageText.text = Message;
    }

    void Start()
    {
        TitleText.text = Title;
        MessageText.text = Message;
    }

    public void OnButton()
    {
        PlayerManager.Health += 40;
        PlayerManager.Gold += 30;
        LogManager.Push("Player1 <color=red>10ゴールド消費</color> <color=green>体力20回復</color>");
        GameManager.IsNextTurn = true;
    }
}