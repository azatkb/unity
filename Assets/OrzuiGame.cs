using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrzuiGame : MonoBehaviour {

    void Start(){
        gameObject.SetActive(false);
        foreach (Transform child in transform){
            if (child.gameObject.tag != "title"){
                child.position = transform.position;
            }
        }
    }

}
