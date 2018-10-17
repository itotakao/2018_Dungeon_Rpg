using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class StatusUI : MonoBehaviour
    {
        public static StatusUI Current { get; private set; }

        [SerializeField]
        GameObject dialog;

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
        }
    }
}