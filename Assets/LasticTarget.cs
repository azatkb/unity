using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LasticTarget : MonoBehaviour {

    public GameObject panel;

    float EnterCount = 0.1f;

    Image image;

	void Start () {
        image = gameObject.GetComponent<Image>();

    }

    void OnTriggerEnter2D(Collider2D other) {

        EnterCount+= 0.1f;

        float alpha = (image.color.a - EnterCount);

        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

        if(alpha <= 0){

            panel.GetComponent<AnimalPanelBehavior>().Success();

        }

    }

}
