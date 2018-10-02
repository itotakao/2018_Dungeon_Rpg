using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Town
{
    public class ItemShopUI : MonoBehaviour
    {
        public static ItemShopUI Current { get; private set; }

        [SerializeField]
        GameObject dialog;

        void Awake()
        {
            Current = this;
        }

        public void Show(bool isShow)
        {
            if (dialog.activeSelf == isShow) { return; }
            dialog.SetActive(isShow);

            if (isShow)
            {
                OnShow();
            }
            else
            {
                OnHide();
            }
        }

        void OnShow()
        {

        }
        void OnHide()
        {

        }

        public void OnButton(bool isShow)
        {
            Show(isShow);
        }
    }
}