using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AggErrorBehavior : MonoBehaviour {

    public Sprite NormalImage;
    public Sprite ErrorImage;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => {

            gameObject.GetComponent<Image>().sprite = ErrorImage;

            Assets.scripts.ColibriGame.Instance.Error();

        });
    }
   
}
