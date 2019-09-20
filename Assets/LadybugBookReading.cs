using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;

public class LadybugBookReading : MonoBehaviour {

    public TextAsset Book;
    public TextAsset BookTj;
    public GameObject BookWrapper;
    public GameObject Game;
    public Text PageText;
    public Button PrevButton;
    public Button RelaodButton;
    public Button NextButton;
    public Button PlayButton;
    public GameObject PageImage;

    public Sprite Iamge1;
    public Sprite Iamge2;
    public Sprite Iamge3;
    public Sprite Iamge4;
    public Sprite Iamge5;
    public Sprite Iamge6;
    public Sprite Iamge7;
    public Sprite Iamge8;
    //public Sprite Iamge9;

    private Sprite[] PageImages;

    public AudioClip Page1Clip;
    public AudioClip Page2Clip;
    public AudioClip Page3Clip;
    public AudioClip Page4Clip;
    public AudioClip Page5Clip;
    public AudioClip Page6Clip;
    public AudioClip Page7Clip;
    public AudioClip Page8Clip;

    public AudioClip Page1ClipTj;
    public AudioClip Page2ClipTj;
    public AudioClip Page3ClipTj;
    public AudioClip Page4ClipTj;
    public AudioClip Page5ClipTj;
    public AudioClip Page6ClipTj;
    public AudioClip Page7ClipTj;
    public AudioClip Page8ClipTj;

    private JsonData BookData;
    private AudioSource Sources;

    public Button CloseButton;


    private int Page = 0;

    private int PagesCount;

    float currentWordSecond = 0;

    Dictionary<string, int> PageWords;

    List<string> Words;

    private AudioClip[] PageClips;

    public Text FakePageText;

    public GameObject FakeImage;

    private AudioSource sm;

    void  Start(){

        gameObject.SetActive(false);

        sm = BookWrapper.gameObject.GetComponent<AudioSource>();

        this.PageImages = new Sprite[] { Iamge1, Iamge2, Iamge3, Iamge4, Iamge5, Iamge6, Iamge7, Iamge8 };

        this.PageClips = new AudioClip[] { Page1Clip , Page2Clip , Page3Clip , Page4Clip , Page5Clip , Page6Clip , Page7Clip, Page8Clip };

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

        BookWrapper.gameObject.SetActive(false);

        NextButton.GetComponent<Button>().onClick.AddListener(() => {

            BookWrapper.SetActive(true);

            BookWrapper.GetComponent<Animator>().Play("ElephantBookAnimation");

            sm.Play();

            CancelInvoke("RunWords");

            FakeImage.GetComponent<Image>().sprite = PageImage.GetComponent<Image>().sprite;

            FakePageText.GetComponent<Text>().text = PageText.GetComponent<Text>().text;

            if (Sources.isPlaying)
            {
                Sources.Stop();
            }

            NextPage();

            StartCoroutine(Fake());

        });

        PlayButton.GetComponent<Button>().onClick.AddListener(() => {

            Assets.scripts.ColibriGame.Instance.StopRecording();

            Page = 0;

            Game.gameObject.SetActive(true);

            gameObject.SetActive(false);

            Assets.scripts.ColibriGame.Instance.GameVoice(18);

            CancelInvoke();

        });

        CloseButton.onClick.AddListener(() => {

            Assets.scripts.ColibriGame.Instance.ForseStopRecording();

            Page = 0;

            gameObject.SetActive(false);

        });

    }

    public void StartReading()
    {

        string language = PlayerPrefs.GetString("Language");

        if (language.Length == 0)
        {
            language = "En";
        }

        TextAsset bookAsset;

        if (language == "En")
        {
            bookAsset = Book;
            this.PageClips = new AudioClip[] { Page1Clip, Page2Clip, Page3Clip, Page4Clip, Page5Clip, Page6Clip, Page7Clip, Page8Clip};

        }
        else
        {
            bookAsset = BookTj;
            this.PageClips = new AudioClip[] { Page1ClipTj, Page2ClipTj, Page3ClipTj, Page4ClipTj, Page5ClipTj, Page6ClipTj, Page7ClipTj, Page8ClipTj};
        }

        using (StreamReader sr = new StreamReader(new MemoryStream(bookAsset.bytes)))
        {
            string BookText = sr.ReadToEnd();

            BookData = JsonMapper.ToObject(BookText);

            PagesCount = (BookData.Count - 1);

        }

        InitPage();
    }

    IEnumerator Fake()
    {

        yield return new WaitForSeconds(0.6f);

        BookWrapper.SetActive(false);

    }

    void NextPage()
    {

        this.Page++;

        InitPage();
    }


    void InitPage()
    {

        if (Page == 0)
        {

            this.PrevButton.gameObject.SetActive(false);

        }
        else
        {

            this.PrevButton.gameObject.SetActive(true);

        }

        if (Page == PagesCount)
        {

            this.NextButton.gameObject.SetActive(false);
            this.PlayButton.gameObject.SetActive(true);
            
        }
        else
        {

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

    void InitPageWords()
    {

        JsonData page = BookData[this.Page.ToString()];

        for (int i = 0; i < page.Count; i++)
        {

            JsonData Word = page[i];

            PageWords.Add(Word["t"].ToString(), i);

            Words.Add(Word["w"].ToString());

        }

    }

    void RunWords()
    {

        currentWordSecond += 0.1f;

        if (PageWords.ContainsKey(currentWordSecond.ToString("0.0")))
        {

            InitText(PageWords[currentWordSecond.ToString("0.0")]);

        }

    }

    void InitText(int index)
    {

        string resultText = "";

        if (!Assets.scripts.ColibriGame.Instance.isRecording)
        {

            for (int i = 0; i < Words.Count; i++)
            {
                if (index == i)
                {
                    resultText += " " + "<color=green>" + Words[i] + "</color>";
                }
                else
                {
                    resultText += " " + Words[i];
                }

            }
        }
        else
        {

            for (int i = 0; i < Words.Count; i++)
            {
                resultText += " " + Words[i];

            }
        }

        PageText.GetComponent<Text>().text = resultText;

    }

    void InitVoice()
    {

        if (this.Page <= (this.PageImages.Length - 1))
        {
            this.PageImage.GetComponent<Image>().sprite = this.PageImages[this.Page];
        }

        if (!Assets.scripts.ColibriGame.Instance.isRecording)
        {

            if (Sources.isPlaying)
            {
                Sources.Stop();
            }


            Sources.PlayOneShot(PageClips[this.Page]);
        }

    }

}
