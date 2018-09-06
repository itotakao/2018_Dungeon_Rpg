using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class BattleCard : MonoBehaviour
{

    //public PlayerS Players { get { return PlayerS.Current; } }
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
        PlayerManager.Health -= 40;
        LogManager.Push("Player3 <color=red>体力40ダメージ</color>");
        PlayerManager.Gold += 30;
        LogManager.Push("<color=green>30ゴールド獲得</color>");
        GameManager.IsNextTurn = true;
    }
}
