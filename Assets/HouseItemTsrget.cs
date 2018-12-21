using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts;


public class HouseItemTsrget : MonoBehaviour {

    public GameObject panel;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other){

        if (gameObject.tag == other.gameObject.tag){

            other.gameObject.transform.position = gameObject.transform.position;

            other.gameObject.GetComponent<HouseItemDraggable>().Draggable = false;

            panel.gameObject.GetComponent<HouseContainer>().Success();

            //ColibriGame.Instance.Success();

        }
        else{

            //ColibriGame.Instance.Error();

        }

    }
}
