using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartChoose : MonoBehaviour {

    public GameObject App;

    public Button CloseButton;

    public Button EnglishButtonInput;

    public Button TajikButtonInput;

    public Button OKButton;

    public Sprite LangSelected;

    public Sprite Lang;

    string language = "En";

    void Start(){

        gameObject.SetActive(false);

        CloseButton.onClick.AddListener(()=> {
            gameObject.SetActive(false);
        });

        string l = PlayerPrefs.GetString("Language");

        if(l.Length == 0){
            l = "En";
            
        }

     

        if (l == "En"){

                EnglishButtonInput.GetComponent<Image>().sprite = LangSelected;
                TajikButtonInput.GetComponent<Image>().sprite = Lang;
                this.language = "En";

        }
         else{

                EnglishButtonInput.GetComponent<Image>().sprite = Lang;
                TajikButtonInput.GetComponent<Image>().sprite = LangSelected;
                this.language = "Tj";

        }


        TajikButtonInput.onClick.AddListener(() => {

            EnglishButtonInput.GetComponent<Image>().sprite = Lang;
            TajikButtonInput.GetComponent<Image>().sprite = LangSelected;
            this.language = "Tj";

        });

        EnglishButtonInput.onClick.AddListener(() => {

            EnglishButtonInput.GetComponent<Image>().sprite = LangSelected;
            TajikButtonInput.GetComponent<Image>().sprite = Lang;
            this.language = "En";


        });

        OKButton.onClick.AddListener(() => {


            PlayerPrefs.SetString("Language", language);
            PlayerPrefs.Save();
            gameObject.SetActive(false);

            App.GetComponent<Translations>().InitText();

        });
    }

}
