using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour {
    public static BackGroundManager Current { get; private set; }

    void Awake(){
        Current = this;
    }
}
