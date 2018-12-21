using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BearGame5Button : MonoBehaviour {

    public GameObject ZamGame;

    public GameObject MainScreen;

    public GameObject SucccesScreen;

    public GameObject ProfileScreen;

    public GameObject Game1;

    public int IsGirl;

    void Start () {

        gameObject.GetComponent<Button>().onClick.AddListener(() => {

            if(IsGirl == 1){

                Assets.scripts.ColibriGame.Instance.Ewesome();

                Invoke("Timeout", 3.5f);

                string Id = PlayerPrefs.GetString("CurrentUser");

                if (Id.Length == 0)
                {

                    int level = PlayerPrefs.GetInt("Level");

                    if (level < 3)
                    {

                        PlayerPrefs.SetInt("Level", 3);

                        PlayerPrefs.Save();

                    }

                }
                else
                {

                    ProfileScreen.GetComponent<ProfilePanel>().SetLevel(Id, 3);

                }

                SucccesScreen.GetComponent<ZamSuccess>().Success();

            }
            else{

                Assets.scripts.ColibriGame.Instance.Error();

            }




        });


    }

    void Timeout()
    {

        ZamGame.SetActive(false);

        Game1.SetActive(true);

        MainScreen.GetComponent<MainScreen>().State();

        MainScreen.GetComponent<MainScreen>().OpenFeeding(3);

    }

}
