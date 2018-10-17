using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class StatusUI : MonoBehaviour
    {
        public static StatusUI Current { get; private set; }

        void Awake()
        {
            Current = this;
        }
    }
}