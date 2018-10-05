using UnityEngine;

namespace Base
{
    public class NormalDialog : MonoBehaviour
    {
        [SerializeField]
        GameObject dialog;

        public virtual void Show(bool isShow)
        {
            if (dialog.activeSelf == isShow) { return; }

            dialog.SetActive(isShow);

            if (isShow) { OnShow(); }
            else { OnHide(); }
        }

        public virtual void OnShow() { }
        public virtual void OnHide() { }

        public virtual void OnButton(bool isShow)
        {
            Show(isShow);
        }
    }
}