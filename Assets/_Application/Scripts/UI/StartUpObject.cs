using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpObject : MonoBehaviour {

    [SerializeField]
    GameObject[] objectList;

	void Awake () {
        foreach(var obj in objectList){
            obj.SetActive(true);
        }
	}
}
