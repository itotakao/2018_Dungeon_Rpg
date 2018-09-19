using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour {

    public static TextUI Current { get; private set; }

    public Text LogText;
    public Text popUpText;

    void Start()
    {
        Current = this;
    }
}
