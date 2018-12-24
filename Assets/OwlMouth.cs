using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwlMouth : MonoBehaviour {

    public GameObject FeedingScreen;
    public GameObject ProfileScreen;
    public GameObject LevelImage;
    public Sprite     Level1Sprite;
    public Sprite     Level2Sprite;
    public Sprite     Level3Sprite;
    public Sprite     Level5Sprite;

    public Image NutImage;
    public Image NutImage2;
    public Image NutImage3;

    public Image Fake;

    int level = 0;

    int SuccessCount = 0;

	void Start () {

        FeedingScreen.SetActive(false);

    }

    void OnTriggerEnter2D(Collider2D other) {

        SuccessCount++;

        other.gameObject.SetActive(false);

        Assets.scripts.ColibriGame.Instance.GreateJob();

        if (SuccessCount == 3){

             LevelImage.gameObject.SetActive(true);
             Fake.gameObject.SetActive(false);

            //LevelImage.GetComponent<Animator>().enabled = true;

            if (level == 1){

                  LevelImage.GetComponent<Animator>().Play("FeedAnimationAnimation");

              }
              else if (level == 2) {

                LevelImage.GetComponent<Animator>().Play("Feeding2Animation");

              }
              else if (level == 3){

                LevelImage.GetComponent<Animator>().Play("Feeding3Animation");

              }
              else if (level == 4){

                LevelImage.GetComponent<Animator>().Play("Feeding4Animation");

              }

              StartCoroutine(Reset());

        }

    }

    public void Init(int ? currentLevel = 1)
    {

        LevelImage.gameObject.SetActive(false);
        Fake.gameObject.SetActive(true);

        string Id = PlayerPrefs.GetString("CurrentUser");

        if(currentLevel == null){

            if (Id.Length == 0)
            {
                currentLevel = PlayerPrefs.GetInt("Level");
            }
            else
            {
                currentLevel = ProfileScreen.GetComponent<ProfilePanel>().GetLevel(Id);
            }

        }

        level = (int)currentLevel;


        if (currentLevel == 1)
        {
            Fake.sprite = Level1Sprite;
        }
        else if (currentLevel == 2)
        {
            Fake.sprite = Level2Sprite;
        }
        else if (currentLevel == 3)
        {

            Fake.sprite = Level3Sprite;
        }
        else if (currentLevel == 4)
        {
            Fake.sprite = Level5Sprite;

        }

    }

    IEnumerator Reset() {

        yield return new WaitForSeconds(3f);

        SuccessCount = 0;

        NutImage.GetComponent<Nut>().Reset();

        NutImage2.GetComponent<Nut>().Reset();

        NutImage3.GetComponent<Nut>().Reset();

        //LevelImage.GetComponent<Animator>().enabled = false;

        FeedingScreen.SetActive(false);

        //Init();

    }
}
