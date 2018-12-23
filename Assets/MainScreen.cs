using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour {

    public Button ElephantButton;
    public Button FoxButton;
    public Button BearButton;
    public Button DogButton;
    public Button LadybugButton;

    public GameObject Owl;
    public GameObject ElephantBook;
    public GameObject FoxBook;
    public GameObject BearBook;
    public GameObject LadyBugBook;
    public GameObject DogBugBook;

    public GameObject ForbiddenPanel;
    public GameObject ForbiddenPanel2;
    public GameObject ForbiddenPanel3;
    public GameObject ForbiddenPanel4;

    public GameObject ProfileScreen;
    public GameObject SayPopup;
    public GameObject Feeding;
    public GameObject FeedingMouth;

    int level = 0;

    void Start () {

        gameObject.SetActive(false);

        State();

    } 

    public void State(){

        string Id = PlayerPrefs.GetString("CurrentUser");

        if (Id.Length == 0)
        {

            level = PlayerPrefs.GetInt("Level");

        }
        else
        {

            level = ProfileScreen.GetComponent<ProfilePanel>().GetLevel(Id);

        }

        if (level >= 4)
        {

            ElephantButton.gameObject.GetComponent<Animator>().Play("ElephantOpenAnimation");

            FoxButton.gameObject.GetComponent<Animator>().Play("FoxLevel2Animation");

            BearButton.gameObject.GetComponent<Animator>().Play("BearOpenAnimation");

            DogButton.gameObject.GetComponent<Animator>().Play("DogLevel2Animation");

            LadybugButton.gameObject.GetComponent<Animator>().Play("AllAnimationsLadtAnimation");

            Owl.GetComponent<Animator>().Play("OwlLevel4Animation");


        }
        else if (level >= 3)
        {

            ElephantButton.gameObject.GetComponent<Animator>().Play("ElephantOpenAnimation");

            FoxButton.gameObject.GetComponent<Animator>().Play("FoxLevel2Animation");

            BearButton.gameObject.GetComponent<Animator>().Play("BearOpenAnimation");

            DogButton.gameObject.GetComponent<Animator>().Play("DogLevel2Animation");

            LadybugButton.gameObject.GetComponent<Animator>().Play("LadyBugAnimation");

            Owl.GetComponent<Animator>().Play("OwlLevel4Animation");

        }
        else if (level >= 2)
        {

            ElephantButton.gameObject.GetComponent<Animator>().Play("ElephantOpenAnimation");

            FoxButton.gameObject.GetComponent<Animator>().Play("FoxLevel2Animation");

            BearButton.gameObject.GetComponent<Animator>().Play("BearOpenAnimation");

            DogButton.gameObject.GetComponent<Animator>().Play("DogAnimation");

            LadybugButton.gameObject.GetComponent<Animator>().Play("LadyBugAnimation");

            Owl.GetComponent<Animator>().Play("OwlLevel3Animation");

        }
        else if (level >= 1)
        {


            ElephantButton.gameObject.GetComponent<Animator>().Play("ElephantOpenAnimation");

            FoxButton.gameObject.GetComponent<Animator>().Play("FoxLevel2Animation");

            BearButton.gameObject.GetComponent<Animator>().Play("BearAnimation");

            DogButton.gameObject.GetComponent<Animator>().Play("DogAnimation");

            LadybugButton.gameObject.GetComponent<Animator>().Play("LadyBugAnimation");

            Owl.GetComponent<Animator>().Play("OwlLevel2Animation");

        }
        else if (level == 0)
        {
            ElephantButton.gameObject.GetComponent<Animator>().Play("ElephantAnimation");

            FoxButton.gameObject.GetComponent<Animator>().Play("FoxAnimation");

            BearButton.gameObject.GetComponent<Animator>().Play("BearAnimation");

            DogButton.gameObject.GetComponent<Animator>().Play("DogAnimation");

            LadybugButton.gameObject.GetComponent<Animator>().Play("LadyBugAnimation");

            Owl.GetComponent<Animator>().Play("OwlLevel1Animation");
        }

        ElephantButton.GetComponent<Button>().onClick.AddListener(() =>
        {

            ElephantBook.SetActive(true);
            ElephantBook.GetComponent<BookBehavior>().PlayName();

        });

        FoxButton.GetComponent<Button>().onClick.AddListener(() =>
        {

            if (level < 1)
            {
                ForbiddenPanel.GetComponent<CloudScript>().Forbidden();
            }
            else
            {
                FoxBook.SetActive(true);
                FoxBook.GetComponent<FoxBookBehavior>().PlayName();
            }

        });

        BearButton.GetComponent<Button>().onClick.AddListener(() =>
        {

            if (level < 2)
            {
                ForbiddenPanel2.GetComponent<CloudScript>().Forbidden();
            }
            else
            {
                BearBook.SetActive(true);
                BearBook.GetComponent<BearBookPreviewBehavior>().PlayName();
            }

        });

        DogButton.onClick.AddListener(() =>
        {

            if (level < 3)
            {
                ForbiddenPanel3.GetComponent<CloudScript>().Forbidden();
            }
            else
            {
                DogBugBook.SetActive(true);
                DogBugBook.GetComponent<DogBookPreviewBehavior>().PlayName();
            }

        });

        LadybugButton.onClick.AddListener(() =>
        {

            if (level < 4)
            {
                ForbiddenPanel4.GetComponent<CloudScript>().Forbidden();
            }
            else
            {
                LadyBugBook.SetActive(true);
                LadyBugBook.GetComponent<LadybugBookPreviewBehavior>().PlayName();
            }

        });

    }

    public void OpenFeeding(int level = 0){

        Feeding.SetActive(true);

        FeedingMouth.GetComponent<OwlMouth>().Init(level);

    }
}
