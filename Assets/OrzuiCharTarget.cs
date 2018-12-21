using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.scripts;

public class OrzuiCharTarget : MonoBehaviour {

    public GameObject panel;

	void Start () {
        

    }

    void OnTriggerEnter2D(Collider2D other){

        if (gameObject.tag == other.gameObject.tag)
        {

            other.gameObject.transform.position = gameObject.transform.position;

            other.gameObject.GetComponent<WordChar>().Draggable = false;

            panel.GetComponent<OrzuiCharsWrapper>().Success();

        }
        else{
            ColibriGame.Instance.Error();

        }

    }

}
