using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class HealthUI : MonoBehaviour
    {
        public static HealthUI Current { get; private set; }

        public Slider HealthBar;

        void Awake()
        {
            Current = this;
        }
    }
}