using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class StatusUI : MonoBehaviour
    {
        public static StatusUI Current { get; private set; }

        public PlayerManager PlayerManager { get { return PlayerManager.Current; } }

        [SerializeField]
        GameObject dialog;

        [SerializeField]
        Text healthText = null;
        [SerializeField]
        Text attackText = null;
        [SerializeField]
        Text defenceText = null;
        [SerializeField]
        Text speedText = null;
        [SerializeField]
        Text attackIntervalText = null;

        void Awake()
        {
            Current = this;
        }

        void Start()
        {
            ShowDialog(false);
        }

        public void ShowDialog(bool isShow)
        {
            dialog.SetActive(isShow);

            if(isShow)
            {
                UpdateText();
            }
        }

        void UpdateText()
        {
            healthText.text = "体力: " + PlayerManager.GetMaxHealth();
            attackText.text = "攻撃: " + PlayerManager.GetAttack();
            defenceText.text = "防御: " + PlayerManager.GetDefence();
            speedText.text = "敏捷: " + PlayerManager.GetSpeed();
            attackIntervalText.text = "攻撃間隔: " + PlayerManager.GetAttackInterval();
        }
    }
}