using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrazTarget : MonoBehaviour {

    public GameObject panel;

    float EnterCount = 0.1f;

    Image image;

	void Start () {
        image = gameObject.GetComponent<Image>();

    }

    void OnTriggerEnter2D(Collider2D other) {

        EnterCount+= 0.05f;

        float alpha = (image.color.a - EnterCount);

        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

        if(alpha <= 0){

            panel.GetComponent<Dog>().Success();

            gameObject.SetActive(false);

        }

    }

    public void Reset(){

        image.gameObject.SetActive(true);

        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);

    }

}
