using UnityEngine;

public class BattleButton : MonoBehaviour {
    
    public PlayerManager PlayerManager { get { return PlayerManager.Current; } }
    public TextManager LogManager { get { return TextManager.Current; } }
    public GameManager GameManager { get { return GameManager.Current; } }
    public ItemManager ItemManager{ get { return ItemManager.Current; }}
    public BattleManager BattleManager{ get { return BattleManager.Current; }}

    public void OnButton()
    {
        if ( !GameManager.IsBattle ) { return; }

        BattleManager.OnBattleButton();
    }
}