using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour {

    public GameObject Panel;

    public Button CloseButton;

    public Button OKButton;

    //public Button CancelButton;

    public Button EnglishButtonInput;

    public Button TajikButtonInput;

    public Button MuteButton;

    public Button MusicButotn0;

    public Button MusicButotn1;

    public Button MusicButotn2;

    public Button MusicButotn3;

    public Button HelpButton;

    public Slider VolumeSliderInput;

    public GameObject MainSound;

    Button EnglishButton;

    Button TajikButton;

    Slider VolumeSlider;

    public Sprite LangSelected;

    public Sprite Lang;

    public Sprite VolumeActiveSprite;

    public Sprite VolumeMuteSprite;

    public Button About;

    public GameObject AboutPanel;

    public Button CloseAbout;

    string language;

    float volume;

    AudioSource audioData;

    void  Start(){

        Panel.SetActive(false);

        AboutPanel.SetActive(false);

        EnglishButton = EnglishButtonInput.GetComponent<Button>();

        TajikButton = TajikButtonInput.GetComponent<Button>();

        VolumeSlider = VolumeSliderInput.GetComponent<Slider>();

        audioData = MainSound.GetComponent<AudioSource>();

        if (CloseButton.GetComponent<Button>() != null){
            CloseButton.GetComponent<Button>().onClick.AddListener(() => {
                this.Panel.SetActive(false);
            });
        }

        //if (CancelButton.GetComponent<Button>() != null)
        //{
        //    CancelButton.GetComponent<Button>().onClick.AddListener(() =>
        //    {
        //        this.Panel.SetActive(false);
        //    });
        //}

        //if (CancelButton.GetComponent<Button>() != null)
        //{
        //    CancelButton.GetComponent<Button>().onClick.AddListener(() =>
        //    {
        //        this.Panel.SetActive(false);
        //    });
        //}

        if (OKButton.GetComponent<Button>() != null)
        {
            OKButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                this.Save();
                gameObject.SetActive(false);
                MainSound.GetComponent<Translations>().InitText();
            });
        }

        if (MuteButton != null)
        {
            MuteButton.onClick.AddListener(() =>
            {
                if (this.volume > 0)
                {
                    MuteButton.GetComponent<Image>().sprite = VolumeMuteSprite;
                    this.volume = 0;
                    this.VolumeSliderInput.value = 0;
                    this.audioData.volume = 0;
                }
                else
                {
                    this.volume = PlayerPrefs.GetFloat("Volume");
                    this.VolumeSliderInput.value = this.volume;
                    this.audioData.volume = this.volume;
                    MuteButton.GetComponent<Image>().sprite = VolumeActiveSprite;

                }
            });
        }

        if (VolumeSlider != null)
        {
            VolumeSlider.onValueChanged.AddListener((value) =>
            {
                this.volume = value;
                this.audioData.volume = value;
            });
        }

        if (EnglishButton != null)
        {
            EnglishButton.onClick.AddListener(() =>
            {
                EnglishButton.GetComponent<Image>().sprite = LangSelected;
                TajikButton.GetComponent<Image>().sprite = Lang;
                this.language = "En";
            });
        }

        if (TajikButton != null)
        {
            TajikButton.onClick.AddListener(() =>
            {
                EnglishButton.GetComponent<Image>().sprite = Lang;
                TajikButton.GetComponent<Image>().sprite = LangSelected;
                this.language = "Tj";
            });
        }

        string language = PlayerPrefs.GetString("Language");

        if (language.Length > 0)
        {
            if (language == "En")
            {
                EnglishButton.GetComponent<Image>().sprite = LangSelected;
                TajikButton.GetComponent<Image>().sprite = Lang;
            }
            else
            {
                EnglishButton.GetComponent<Image>().sprite = Lang;
                TajikButton.GetComponent<Image>().sprite = LangSelected;
            }
        }

        float? volume = PlayerPrefs.GetFloat("Volume");

        if (volume > 0)
        {
            this.VolumeSliderInput.value = (float)volume;
        }
        else
        {
            this.VolumeSliderInput.value = 0.5f;
        }

        MusicButotn0.onClick.AddListener(() =>
        {

            this.MainSound.GetComponent<App>().StartMusic(0);

            MusicButotn0.GetComponent<Animator>().Play("EqulizerAnimation");

            MusicButotn1.GetComponent<Animator>().Play("Default");

            MusicButotn2.GetComponent<Animator>().Play("Default");

            MusicButotn3.GetComponent<Animator>().Play("Default");


        });

        MusicButotn1.onClick.AddListener(() =>
        {

            this.MainSound.GetComponent<App>().StartMusic(1);

            MusicButotn1.GetComponent<Animator>().Play("EqulizerAnimation");

            MusicButotn0.GetComponent<Animator>().Play("Default");

            MusicButotn2.GetComponent<Animator>().Play("Default");

            MusicButotn3.GetComponent<Animator>().Play("Default");

        });

        MusicButotn2.onClick.AddListener(() =>
        {

            this.MainSound.GetComponent<App>().StartMusic(2);

            MusicButotn2.GetComponent<Animator>().Play("EqulizerAnimation");

            MusicButotn1.GetComponent<Animator>().Play("Default");

            MusicButotn0.GetComponent<Animator>().Play("Default");

            MusicButotn3.GetComponent<Animator>().Play("Default");

        });

        MusicButotn3.onClick.AddListener(() =>
        {

            this.MainSound.GetComponent<App>().StartMusic(3);

            MusicButotn3.GetComponent<Animator>().Play("EqulizerAnimation");

            MusicButotn1.GetComponent<Animator>().Play("Default");

            MusicButotn2.GetComponent<Animator>().Play("Default");

            MusicButotn0.GetComponent<Animator>().Play("Default");


        });

        About.onClick.AddListener(() =>
        {

            AboutPanel.SetActive(true);

        });

        CloseAbout.onClick.AddListener(() =>
        {

            AboutPanel.SetActive(false);

        });

    }

    void Save(){

        PlayerPrefs.SetString("Language", language);

        PlayerPrefs.SetFloat("Volume", volume);

    }

}
