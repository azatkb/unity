using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZamGame5 : MonoBehaviour {

    public GameObject MianScreen;
    public GameObject ProfileScreen;
    public GameObject SuccessPanel;
    public GameObject game0;
    public GameObject game1;
    public GameObject game2;

    public Button UnswerButton;
    public Button UnswerButton2;
    public Button UnswerButton3;
    public Button UnswerButton4;

    public Button ReturnBtn;

    void Start () {

        gameObject.SetActive(false);

        ReturnBtn.onClick.AddListener(() => {

            game0.SetActive(true);
            game1.SetActive(false);

        });

        UnswerButton2.onClick.AddListener(() => {

           Assets.scripts.ColibriGame.Instance.Error();

        });

        UnswerButton3.onClick.AddListener(() => {

            Assets.scripts.ColibriGame.Instance.Error();

        });

        UnswerButton4.onClick.AddListener(() => {

            Assets.scripts.ColibriGame.Instance.Error();

        });

        UnswerButton.onClick.AddListener(() => {

            StartCoroutine(Timeout());

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

            SuccessPanel.GetComponent<ZamSuccess>().Success();


        });


    }

    IEnumerator Timeout()
    {

        yield return new WaitForSeconds(3.5f);

        game0.SetActive(true);

        game1.SetActive(false);

        game2.SetActive(false);

        MianScreen.GetComponent<MainScreen>().State();

        MianScreen.GetComponent<MainScreen>().OpenFeeding(3);

    }

}
