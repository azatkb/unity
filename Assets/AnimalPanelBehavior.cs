using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.scripts;

public class AnimalPanelBehavior : MonoBehaviour {

    public GameObject game0;
    public GameObject game1;
    public GameObject game2;
    public Button ReturnBtn;

    public GameObject SuccessPanel;

    public Image Target;
    public Image Lastic;

    int SuccessCount = 0;

	void Start () {
		
          if(ReturnBtn != null){

               ReturnBtn.onClick.AddListener(() => {
                   game0.SetActive(true);
                   game1.SetActive(false);
               });

          }
	}
	
	public void Success () {

         SuccessCount++;

        ColibriGame.Instance.GreateJob();

        if (SuccessCount == 2){

            Invoke("Timeout", 2f);

            SuccessPanel.GetComponent<FoxSuccess>().Success("Greate Job!");


        }

    }

    void Timeout()
    {

        game1.SetActive(false);
        game2.SetActive(true);

        SuccessCount = 0;

        Target.color = new Color(Target.color.r, Target.color.g, Target.color.b, 1);

        Lastic.GetComponent<Lastic>().AfterDrop();

    }
}
