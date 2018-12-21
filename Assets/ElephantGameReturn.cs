using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElephantGameReturn : MonoBehaviour {

    public GameObject game1;
    public GameObject game2;
    public GameObject game3;
    public GameObject game4;
    public GameObject game5;

    void Start () {

        gameObject.GetComponent<Button>().onClick.AddListener(()=> { 
        
              if(game2.activeSelf){
                  game1.SetActive(true);
                  game2.SetActive(false);
              }
              else if(game3.activeSelf){
                  game2.SetActive(true);
                  game3.SetActive(false);
              }
              else if (game4.activeSelf){
                  game3.SetActive(true);
                  game4.SetActive(false);
              }
              else if ((game5 != null) && (game5.activeSelf)){
                  game4.SetActive(true);
                  game5.SetActive(false);
              }

        });
		
	}
	

}
