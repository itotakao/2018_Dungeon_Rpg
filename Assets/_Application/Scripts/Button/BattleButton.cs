using UnityEngine;

public class BattleButton : MonoBehaviour {
    
    public PlayerManager PlayerManager { get { return PlayerManager.Current; } }
    public LogManager LogManager { get { return LogManager.Current; } }
    public GameManager GameManager { get { return GameManager.Current; } }
    public ItemManager ItemManager{ get { return ItemManager.Current; }}
    public BattleManager BattleManager{ get { return BattleManager.Current; }}

    public void OnButton()
    {
        //if (GameManager.IsNextTurn ) { return; }

        BattleManager.Battle();

        //GameManager.IsNextTurn = true;
    }
}