using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookRecords : MonoBehaviour {

    public Button CloseButton;

    public Button ElephantBookRecord;
    public Button FoxBookRecord;
    public Button BearBookRecord;
    public Button DogBookRecord;
    public Button LadybugBookRecord;

    public GameObject RecordRow;
    public GameObject RecordRow2;
    public GameObject RecordRow3;
    public GameObject RecordRow4;
    public GameObject RecordRow5;

    string ElephantBook;
    string FoxBook;
    string BearBook;
    string DogBook;
    string LadybugBook;

    void Start () {

        gameObject.SetActive(false);

        CloseButton.onClick.AddListener(()=> {

            gameObject.SetActive(false);
        
        });

        ElephantBookRecord.onClick.AddListener(() => {

            Handheld.PlayFullScreenMovie(ElephantBook, Color.black, FullScreenMovieControlMode.CancelOnInput);

        });

        FoxBookRecord.onClick.AddListener(() => {

            Handheld.PlayFullScreenMovie(FoxBook, Color.black, FullScreenMovieControlMode.CancelOnInput);

        });

        BearBookRecord.onClick.AddListener(() => {

            Handheld.PlayFullScreenMovie(BearBook, Color.black, FullScreenMovieControlMode.CancelOnInput);

        });

        DogBookRecord.onClick.AddListener(() => {

            Handheld.PlayFullScreenMovie(DogBook, Color.black, FullScreenMovieControlMode.CancelOnInput);

        });

        LadybugBookRecord.onClick.AddListener(() => {

            Handheld.PlayFullScreenMovie(LadybugBook, Color.black, FullScreenMovieControlMode.CancelOnInput);

        });

        InitRows();

    }

    public void InitRows(){

        Debug.Log("Init Record Rows");

        string language = PlayerPrefs.GetString("Language");

        if (language.Length == 0)
        {
            language = "En";
        }

        ElephantBook = PlayerPrefs.GetString("ElephantBook"+ language);

        FoxBook = PlayerPrefs.GetString("FoxBook" + language);

        BearBook = PlayerPrefs.GetString("BearBook" + language);

        DogBook = PlayerPrefs.GetString("DogBook" + language);

        LadybugBook = PlayerPrefs.GetString("LadybugBook" + language);

        if(ElephantBook.Length == 0){
            RecordRow.SetActive(false);
        }else{
            RecordRow.SetActive(true);

        }

        if (FoxBook.Length == 0){
            RecordRow2.SetActive(false);
        }
        else{
            RecordRow2.SetActive(true);
        }

        if (BearBook.Length == 0){
            RecordRow3.SetActive(false);
        }
        else{
            RecordRow3.SetActive(true);
        }

        if (DogBook.Length == 0) {
            RecordRow4.SetActive(false);
        }
        else{
            RecordRow4.SetActive(true);
        }

        if (LadybugBook.Length == 0){
            RecordRow5.SetActive(false);
        }
        else{
            RecordRow5.SetActive(true);
        }

        Debug.Log(DogBook);


    }
	
}
