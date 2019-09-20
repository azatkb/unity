using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;

public class BookReading : MonoBehaviour {

    public TextAsset Book;
    public TextAsset BookTj;
    public GameObject BookWrapper;
    public GameObject Game;
    public Text PageText;
    public Text FakePageText;
    public Button PrevButton;
    public Button RelaodButton;
    public Button NextButton;
    public Button PlayButton;
    public GameObject PageImage;
    public GameObject FakeImage;

    public Sprite Iamge1;
    public Sprite Iamge2;
    public Sprite Iamge3;
    public Sprite Iamge4;
    public Sprite Iamge5;
    public Sprite Iamge6;
    public Sprite Iamge7;
    public Sprite Iamge8;
    public Sprite Iamge9;
    public Sprite Iamge10;
    public Sprite Iamge11;
    public Sprite Iamge12;
    public Sprite Iamge13;
    public Sprite Iamge14;
    public Sprite Iamge15;

    private Sprite[] PageImages;

    public AudioClip Page1Clip;
    public AudioClip Page2Clip;
    public AudioClip Page3Clip;
    public AudioClip Page4Clip;
    public AudioClip Page5Clip;
    public AudioClip Page6Clip;
    public AudioClip Page7Clip;
    public AudioClip Page8Clip;
    public AudioClip Page9Clip;
    public AudioClip Page10Clip;
    public AudioClip Page11Clip;
    public AudioClip Page12Clip;
    public AudioClip Page13Clip;
    public AudioClip Page14Clip;
    public AudioClip Page15Clip;

    public AudioClip Page1ClipTj;
    public AudioClip Page2ClipTj;
    public AudioClip Page3ClipTj;
    public AudioClip Page4ClipTj;
    public AudioClip Page5ClipTj;
    public AudioClip Page6ClipTj;
    public AudioClip Page7ClipTj;
    public AudioClip Page8ClipTj;
    public AudioClip Page9ClipTj;
    public AudioClip Page10ClipTj;
    public AudioClip Page11ClipTj;
    public AudioClip Page12ClipTj;
    public AudioClip Page13ClipTj;
    public AudioClip Page14ClipTj;
    public AudioClip Page15ClipTj;

    private JsonData BookData;
    private AudioSource Sources;

    public Button CloseButton;

    private int Page = 0;

    private int PagesCount;

    float currentWordSecond = 0;

    Dictionary<string, int> PageWords;

    List<string> Words;

    private AudioClip[] PageClips;

    private AudioSource sm;

    void  Start(){

        BookWrapper.gameObject.SetActive(false);

        sm = BookWrapper.gameObject.GetComponent<AudioSource>();

        gameObject.SetActive(false);

        this.PageImages = new Sprite[] { Iamge1, Iamge2, Iamge3, Iamge4, Iamge5, Iamge6, Iamge7, Iamge8, Iamge9, Iamge10, Iamge11, Iamge12, Iamge13, Iamge14, Iamge15};


        this.Sources = GetComponent<AudioSource>();

        PrevButton.GetComponent<Button>().onClick.AddListener(() => {
        
            if(Sources.isPlaying){

                Sources.Stop();
            }

            Page--;

            InitPage();

        });

        RelaodButton.GetComponent<Button>().onClick.AddListener(() => {

            CancelInvoke("RunWords");

            if (Sources.isPlaying){

                Sources.Stop();

            }

            InitPage();

        });

        NextButton.GetComponent<Button>().onClick.AddListener(() => {

            BookWrapper.SetActive(true);

            BookWrapper.GetComponent<Animator>().Play("ElephantBookAnimation");

            sm.Play();

            CancelInvoke("RunWords");

            FakeImage.GetComponent<Image>().sprite = PageImage.GetComponent<Image>().sprite;

            FakePageText.GetComponent<Text>().text = PageText.GetComponent<Text>().text;

            if (Sources.isPlaying){
                Sources.Stop();
            }

            NextPage();

            StartCoroutine(Fake());

        });

        PlayButton.GetComponent<Button>().onClick.AddListener(() => {

            CancelInvoke();

            Assets.scripts.ColibriGame.Instance.StopRecording();

            Assets.scripts.ColibriGame.Instance.GameVoice(1);

            Page = 0;

            Game.gameObject.SetActive(true);

            gameObject.SetActive(false);


        });

        CloseButton.onClick.AddListener(() =>
        {

            Assets.scripts.ColibriGame.Instance.ForseStopRecording();

            Page = 0;

            gameObject.SetActive(false);

        });

    }

    public void StartReading(){

        string language = PlayerPrefs.GetString("Language");

        if (language.Length == 0){
            language = "En";
        }

        TextAsset bookAsset;

        if(language == "En"){
            bookAsset = Book;
            this.PageClips = new AudioClip[] { Page1Clip, Page2Clip, Page3Clip, Page4Clip, Page5Clip, Page6Clip, Page7Clip, Page8Clip, Page9Clip, Page10Clip, Page11Clip, Page12Clip, Page13Clip, Page14Clip, Page15Clip };

        }
        else{
            bookAsset = BookTj;
            this.PageClips = new AudioClip[] { Page1ClipTj, Page2ClipTj, Page3ClipTj, Page4ClipTj, Page5ClipTj, Page6ClipTj, Page7ClipTj, Page8ClipTj, Page9ClipTj, Page10ClipTj, Page11ClipTj, Page12ClipTj, Page13ClipTj, Page14ClipTj, Page15ClipTj };
        }

        using (StreamReader sr = new StreamReader(new MemoryStream(bookAsset.bytes)))
        {
            string BookText = sr.ReadToEnd();

            BookData = JsonMapper.ToObject(BookText);

            PagesCount = (BookData.Count - 1);


        }

        InitPage();
    }

    IEnumerator Fake(){

        yield return new WaitForSeconds(0.4f);

        BookWrapper.SetActive(false);

    }

    void NextPage(){

        this.Page++;

        InitPage();
    }


    void InitPage(){

        if (Page == 0){

            this.PrevButton.gameObject.SetActive(false);

        }else{

            this.PrevButton.gameObject.SetActive(true);

        }

        if(Page == PagesCount){

            this.NextButton.gameObject.SetActive(false);
            this.PlayButton.gameObject.SetActive(true);

        }
        else{

            this.NextButton.gameObject.SetActive(true);
            this.PlayButton.gameObject.SetActive(false);

        }

        PageWords = new Dictionary<string, int>();

        Words = new List<string>();

        currentWordSecond = 0;

        StartCoroutine(TimeoutWords());

    }

    IEnumerator  TimeoutWords(){

        yield return new WaitForSeconds(0.2f);

        InitPageWords();

        InitVoice();

        InvokeRepeating("RunWords", 0, 0.1f);

    }

    void InitPageWords(){

        JsonData page = BookData[this.Page.ToString()];

        for (int i = 0; i < page.Count; i++){

            JsonData Word = page[i];

            PageWords.Add(Word["t"].ToString(), i);

            Words.Add(Word["w"].ToString());

        }

    }

    void RunWords(){

        currentWordSecond += 0.1f;


        if (PageWords.ContainsKey(currentWordSecond.ToString("0.0"))){

            InitText(PageWords[currentWordSecond.ToString("0.0")]);
            
        }

    }

    void InitText(int index){

       string resultText = "";

        if (!Assets.scripts.ColibriGame.Instance.isRecording) {

            for (int i = 0; i < Words.Count; i++)
            {
                if (index == i) {
                    resultText += " " + "<color=green>" + Words[i] + "</color>";
                }
                else
                {
                    resultText += " " + Words[i];
                }

            }
        }
        else{

            for (int i = 0; i < Words.Count; i++)
            {
                resultText += " " + Words[i];

            }
        }

       PageText.GetComponent<Text>().text = resultText;

    }

    void InitVoice(){

        if(this.Page <= (this.PageImages.Length - 1)){

            this.PageImage.GetComponent<Image>().sprite = this.PageImages[this.Page];

        }

        if(Assets.scripts.ColibriGame.Instance.isRecording){
            return;
        }

        if(Sources.isPlaying){
            Sources.Stop();
        }

        Sources.PlayOneShot(PageClips[this.Page]);

    }

}
