using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;

    // ステータス
    public float MaxHealth = 100;
    float HealthCache = 100;
    public float Health
    {
        get
        {
            return HealthCache;
        }
        set
        {
            HealthCache = value;
            healthBar.maxValue = MaxHealth;
            healthBar.value = value;

            if (HealthCache <= 0)
            {
                //PlayerManager.instance.exp += exp;
                //PlayerManager.instance.gold += gold;
                //Death();
            }
        }
    }

    public float Exp = 10;
    public int Gold = 100;
    public float Attack = 10;
    [SerializeField]
    private Item[] dropNormalItemList;
    [SerializeField]
    private int normalItemDropLate = 50;
    [SerializeField]
    private Item[] dropRareItemList;
    [SerializeField]
    private int rarelItemDropLate = 10;


    //void Start()
    //{
    //    // 戦闘開始イベントに追加
    //    ApplicationManager.instance.battleEvent += OnBattle;
    //}

    //private void Death()
    //{
    //    // イベントから削除
    //    if (ApplicationManager.instance)
    //        ApplicationManager.instance.battleEvent -= OnBattle;
    //    // 次の敵読み込み
    //    ApplicationManager.instance.NextFloor();
    //    // アイテム抽選
    //    DropItem();
    //    // 本体を削除
    //    Destroy(gameObject, 3f);
    //}

    //void OnDestroy() // シーン遷移時に残らないように削除
    //{
    //    // イベントから削除
    //    if (ApplicationManager.instance)
    //        ApplicationManager.instance.battleEvent -= OnBattle;
    //}
    //// ApplicationManagerのEvent用　戦闘を管理
    //void OnBattle()
    //{
    //    health -= PlayerManager.instance.attack;
    //    PlayerManager.instance.health -= attack;
    //    EffectManager.instance.PlayBasicAttack();
    //    TextManager.instance.DisplayDamage((int)PlayerManager.instance.attack, Vector3.zero);
    //}

    //private void DropItem()
    //{
    //    int itemDropRate = Random.Range(0, 1000);
    //    if (itemDropRate < rarelItemDropLate)
    //    {
    //        int rand = Random.Range(0, dropRareItemList.Length - 1);
    //        ItemManager.instance.AddItem(dropRareItemList[rand]);
    //        return;
    //    }

    //    if (itemDropRate < normalItemDropLate)
    //    {
    //        int rand = Random.Range(0, dropNormalItemList.Length - 1);
    //        ItemManager.instance.AddItem(dropNormalItemList[rand]);
    //    }
    //}
}