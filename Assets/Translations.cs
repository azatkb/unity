using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;

public class Translations : MonoBehaviour {

    public TextAsset translateEng;
    public TextAsset translateTj;

    /// <summary>
    ///   Settings
    /// </summary>

    public Text TitleSettings;
    public Text LangText;
    public Text VoolumeText;
    public Text MusicText;
    public Text HelpText;
    public Text OkText;
    public Text CancelText;
    public Text AboutText;
    public Text AboutTitle;
    public Text AboutBody;

    /// <summary>
    ///    Profile
    /// </summary>

    public Text TitleProfile;
    public Text NameText;
    public Text LavelText;
    public Text AddPhotoText;
    public Text DeletePhotoText;
    public Text CurrentNameText;
    public Text CurrentLavelText;
    public Text AddNewPlayerText;
    public Text ProfileOkText;
    public Text ProfileAddText;
    public Text ProfileCancelText;
    public Text ProfileNewUserText;

    /// <summary>
    ///    Exit
    /// </summary>
    /// 

    public Text ExitText;
    public Text YesText;
    public Text NoText;

    /// <summary>
    ///    Teachers
    /// </summary>
    /// 

    public Text TechersTitle;
    public Text TechersText;

    /// <summary>
    ///    Teachers
    /// </summary>
    /// 

    public Text ParentsTitle;
    public Text ParentsText;

    /// <summary>
    ///    ELephant
    /// </summary>
    /// 

    public Text ElephantReadBook;
    //public Text ElephantColseBook;

    /// <summary>
    ///   Game1
    /// </summary>
    /// 

    public Text ElephantGame1Title;
    public Text ElephantGame2Title;
    public Text ElephantGame3Title;
    public Text ElephantGame4Title;
    public Text ElephantGame5Title;

    /// <summary>
    ///    Fox
    /// </summary>
    /// 

    public Text FoxReadBook;
    //public Text FoxColseBook;

    /// <summary>
    ///   Game2
    /// </summary>
    /// 

    public Text FoxGame1Title;
    public Text FoxGame2Title;
    public Text FoxGame3Title;
    public Text FoxGame4Title;
    public Text FoxGame5Title;
    public Text FoxGame5Desc;

    /// <summary>
    ///    Bear
    /// </summary>
    /// 

    public Text BearReadBook;
    //public Text BearColseBook;

    /// <summary>
    ///   Game3
    /// </summary>
    /// 

    public Text BearGame1Title;
    public Text BearGame2Title;
    public Text BearGame3Title;
    public Text BearGame4Title;
    public Text BearGame5Title;

    public Text BearGame5Task1;
    public Text BearGame5Task2;
    public Text BearGame5Task3;
    public Text BearGame5Task4;

    /// <summary>
    ///    Dog
    /// </summary>
    /// 

    public Text DogReadBook;
    //public Text DogColseBook;

    public Text DogGame1Title;
    public Text DogGame2Title;
    public Text DogGame3Title;
    public Text DogGame4Title;

    /// <summary>
    ///    LadyBug
    /// </summary>
    /// 

    public Text LadyBugReadBook;
    //public Text LadyBugColseBook;

    public Text LadyBugGame1Title;
    public Text LadyBugGame2Title;
    public Text LadyBugGame3Title;
    public Text LadyBugGame4Title;


    /// <summary>
    ///  Start
    /// </summary>

    public Text PreSchooleText;
    public Text GradeText;
    public Text Grade2Text;

    public Text IntroText;
    public Text IntroText2;
    public Text IntroText3;
    public Text IntroText4;

    public Text SoonText;

    public Text GrowText;
    public Text GrowText2;
    public Text GrowText3;
    public Text GrowText4;

    public Text ChooseLevel;
    public Text GotItButtonText;

    public Text CloudText;
    public Text CloudText2;
    public Text CloudText3;
    public Text CloudText4;

    public Text Book1Title;
    public Text Book1PreviewTitle;
    public Text Game1PreviewTitle;

    public Text Book2Title;
    public Text Book2PreviewTitle;
    public Text Game2PreviewTitle;

    public Text Book3Title;
    public Text Book3PreviewTitle;
    public Text Game3PreviewTitle;

    public Text Book4Title;
    public Text Book4PreviewTitle;
    public Text Game4PreviewTitle;

    public Text Book5Title;
    public Text Book5PreviewTitle;
    public Text Game5PreviewTitle;


    public Text RecordText1;
    public Text RecordText2;
    public Text RecordText3;
    public Text RecordText4;
    public Text RecordText5;

    public Text BookAuthor1;
    public Text BookAuthor2;
    public Text BookAuthor3;
    public Text BookAuthor4;
    public Text BookAuthor5;

    public Text GameReturn1;
    public Text GameReturn2;
    public Text GameReturn3;
    public Text GameReturn4;
    public Text GameReturn5;

    public Text FoxGameReturn2;
    public Text FoxGameReturn3;
    public Text FoxGameReturn4;

    public Text BearGameReturn2;
    public Text BearGameReturn3;
    public Text BearGameReturn4;
    public Text BearGameOk;

    public Text DogGameReturn2;
    public Text DogGameReturn3;
    public Text DogGameReturn4;


    /// <summary>
    ///  Elephant Games 
    /// </summary>
    /// 

    public GameObject ElephantGame1En;
    public GameObject ElephantGame1Tj;

    public GameObject ElephantGame3En;
    public GameObject ElephantGame3Tj;

    public GameObject FoxGame1En;
    public GameObject FoxGame1Tj;

    /// <summary>
    /// /  Records 
    /// </summary>
    /// 

    public Text RecorTitle;
    public Text BookRecordName1;
    public Text BookRecordName2;
    public Text BookRecordName3;
    public Text BookRecordName4;
    public Text BookRecordName5;
    public Text TextFeeding;


    public Text TextFOX;
    public Text TextBEAR;
    public Text TextWOLF;
    public Text TextRABBIT;

    public GameObject BearGame3En;
    public GameObject BearGame3Tj;

    public Text TextD;
    public Text TextC;
    public Text TextH;
    public Text TextG;
    public Text TextS;
    public Text TextR;

    public GameObject LadyGame3En;
    public GameObject LadyGame3Tj;

    public GameObject VoiceBehavior;

    public Image SoonImage;
    public Image SoonImage2;

    public Sprite SoonSpriteEn1;
    public Sprite SoonSpriteEn2;

    public Sprite SoonSpriteTj1;
    public Sprite SoonSpriteTj2;

    public Text ElephantPaintOk;
    public Text FoxPaintOk;

    void Start () {
        InitText();
    }

    public void InitText()
    {

        TextAsset translate;

        string language = PlayerPrefs.GetString("Language");

        if (language.Length > 0){

           if(language == "Tj")
            {
                translate = translateTj;
            }
            else{
                translate = translateEng;
            }

        }
        else{
            translate = translateEng;
            language = "En";
        }


        if (language == "En") {
            ElephantGame1En.SetActive(true);
            ElephantGame1Tj.SetActive(false);
            ElephantGame3En.SetActive(true);
            ElephantGame3Tj.SetActive(false);
            FoxGame1En.SetActive(true);
            FoxGame1Tj.SetActive(false);
            BearGame3En.SetActive(true);
            BearGame3Tj.SetActive(false);
            LadyGame3En.SetActive(true);
            LadyGame3Tj.SetActive(false);

            VoiceBehavior.GetComponent<VoiceBahavior>().TranslateEn();
            SoonImage.sprite = SoonSpriteEn1;
            SoonImage2.sprite = SoonSpriteEn2;
        }
        else{
            ElephantGame1En.SetActive(false);
            ElephantGame1Tj.SetActive(true);
            ElephantGame3En.SetActive(false);
            ElephantGame3Tj.SetActive(true);
            FoxGame1En.SetActive(false);
            FoxGame1Tj.SetActive(true);
            BearGame3En.SetActive(false);
            BearGame3Tj.SetActive(true);
            LadyGame3En.SetActive(false);
            LadyGame3Tj.SetActive(true);

            VoiceBehavior.GetComponent<VoiceBahavior>().TranslateTj();

            SoonImage.sprite = SoonSpriteTj1;
            SoonImage2.sprite = SoonSpriteTj2;

        }


        using (StreamReader sr = new StreamReader(new MemoryStream(translate.bytes))) {

            string langText = sr.ReadToEnd();

            //try
            //{

                JsonData Lang = JsonMapper.ToObject(langText);

            TitleSettings.GetComponent<Text>().text = Lang["title_settings"].ToString();
            LangText.GetComponent<Text>().text = Lang["label_language"].ToString();
            VoolumeText.GetComponent<Text>().text = Lang["label_volume"].ToString();
            MusicText.GetComponent<Text>().text = Lang["label_music"].ToString();

            OkText.GetComponent<Text>().text = Lang["label_ok"].ToString();


            TitleProfile.GetComponent<Text>().text = Lang["title_profile"].ToString();
            NameText.GetComponent<Text>().text = Lang["label_name"].ToString();
            LavelText.GetComponent<Text>().text = Lang["label_level"].ToString();

            DeletePhotoText.GetComponent<Text>().text = Lang["label_delete_photo"].ToString();
            CurrentNameText.GetComponent<Text>().text = Lang["label_name"].ToString();
            CurrentLavelText.GetComponent<Text>().text = Lang["label_level"].ToString();
            AddNewPlayerText.GetComponent<Text>().text = Lang["label_add_player"].ToString();
            ProfileOkText.GetComponent<Text>().text = Lang["label_ok"].ToString();
            ProfileCancelText.GetComponent<Text>().text = Lang["label_cancel"].ToString();
            AddPhotoText.GetComponent<Text>().text = Lang["label_add_photo"].ToString();
            ProfileAddText.GetComponent<Text>().text = Lang["label_add_player"].ToString();
            ProfileNewUserText.GetComponent<Text>().text = Lang["label_name"].ToString();

            ExitText.GetComponent<Text>().text = Lang["title_exit"].ToString();
            YesText.GetComponent<Text>().text = Lang["label_yes"].ToString();
            NoText.GetComponent<Text>().text = Lang["label_no"].ToString();
            AboutText.GetComponent<Text>().text = Lang["label_about"].ToString();


            AboutTitle.GetComponent<Text>().text = Lang["label_about_title"].ToString();
            AboutBody.GetComponent<Text>().text = Lang["label_about_text"].ToString();
            AboutBody.GetComponent<Text>().text = Lang["label_about_text"].ToString();

            TechersTitle.GetComponent<Text>().text = Lang["label_teachers_title"].ToString();
            TechersText.GetComponent<Text>().text = Lang["label_teachers_text"].ToString();

            ParentsTitle.GetComponent<Text>().text = Lang["label_parents_title"].ToString();
            ParentsText.GetComponent<Text>().text = Lang["label_parents_text"].ToString();

            ElephantReadBook.GetComponent<Text>().text = Lang["label_read_book"].ToString();


            FoxReadBook.GetComponent<Text>().text = Lang["label_read_book"].ToString();


            BearReadBook.GetComponent<Text>().text = Lang["label_read_book"].ToString();
            //    //BearColseBook.GetComponent<Text>().text= Lang["label_return"].ToString();

            DogReadBook.GetComponent<Text>().text = Lang["label_read_book"].ToString();
            //    //DogColseBook.GetComponent<Text>().text = Lang["label_return"].ToString();

            //    LadyBugReadBook.GetComponent<Text>().text = Lang["label_read_book"].ToString();
            //    //LadyBugColseBook.GetComponent<Text>().text = Lang["label_return"].ToString();

            ElephantGame1Title.GetComponent<Text>().text = Lang["label_find_animal_name"].ToString();
            ElephantGame2Title.GetComponent<Text>().text = Lang["label_toss_apples"].ToString();
            ElephantGame3Title.GetComponent<Text>().text = Lang["label_elephant_sound"].ToString();
            ElephantGame4Title.GetComponent<Text>().text = Lang["label_count_apples_together"].ToString();
            //ElephantGame5Title.GetComponent<Text>().text = Lang["label_prepare_draw_elephant"].ToString();


            FoxGame1Title.GetComponent<Text>().text = Lang["label_find_animal_name"].ToString();
            FoxGame2Title.GetComponent<Text>().text = Lang["label_erase_animal_not_story"].ToString();
            FoxGame3Title.GetComponent<Text>().text = Lang["label_name_animal"].ToString();
            FoxGame4Title.GetComponent<Text>().text = Lang["label_collect_puzzle_2"].ToString();
            //    //FoxGame5Title.GetComponent<Text>().text = Lang["label_learn_draw_rabbit"].ToString();
            //    //FoxGame5Desc.GetComponent<Text>().text = Lang["label_prepare_draw_rabbit"].ToString();

            BearGame1Title.GetComponent<Text>().text = Lang["label_help_collect_mushrooms"].ToString();
            BearGame2Title.GetComponent<Text>().text = Lang["label_match_names_children"].ToString();
            BearGame3Title.GetComponent<Text>().text = Lang["label_match_sount"].ToString();
            BearGame4Title.GetComponent<Text>().text = Lang["label_build_house_children"].ToString();
    

            BearGame5Task1.GetComponent<Text>().text = Lang["label_one_elephant"].ToString();
            BearGame5Task2.GetComponent<Text>().text = Lang["label_two_rabbits"].ToString();
            BearGame5Task3.GetComponent<Text>().text = Lang["label_three_apples"].ToString();
            BearGame5Task4.GetComponent<Text>().text = Lang["label_four_flowers"].ToString();

            DogGame1Title.GetComponent<Text>().text = Lang["label_help_puppy_clean"].ToString();
            DogGame2Title.GetComponent<Text>().text = Lang["label_animals_names_letters"].ToString();
            DogGame3Title.GetComponent<Text>().text = Lang["label_collect_puzzle"].ToString();
            DogGame4Title.GetComponent<Text>().text = Lang["label_find_chicks"].ToString();

            //    LadyBugGame1Title.GetComponent<Text>().text = Lang["label_hiding_beetle"].ToString();
            //    LadyBugGame2Title.GetComponent<Text>().text = Lang["label_how_many_apricots"].ToString();
            //    LadyBugGame3Title.GetComponent<Text>().text = Lang["label_puzzle_sun"].ToString();
            //    LadyBugGame4Title.GetComponent<Text>().text = Lang["label_grow_apricots"].ToString();

            PreSchooleText.GetComponent<Text>().text = Lang["label_preschoole"].ToString();
                GradeText.GetComponent<Text>().text = Lang["label_grade"].ToString();
                Grade2Text.GetComponent<Text>().text = Lang["label_grade2"].ToString();

                IntroText.GetComponent<Text>().text = Lang["label_intro"].ToString();
                IntroText2.GetComponent<Text>().text = Lang["label_intro2"].ToString();
                IntroText3.GetComponent<Text>().text = Lang["label_intro3"].ToString();
                IntroText4.GetComponent<Text>().text = Lang["label_intro4"].ToString();

            //    SoonText.GetComponent<Text>().text = Lang["label_soon"].ToString();

                GrowText.GetComponent<Text>().text = Lang["label_grow3"].ToString();
                GrowText2.GetComponent<Text>().text = Lang["label_grow"].ToString();
                GrowText3.GetComponent<Text>().text = Lang["label_grow2"].ToString();
                GrowText4.GetComponent<Text>().text = Lang["label_grow4"].ToString();

                ChooseLevel.GetComponent<Text>().text = Lang["label_choose"].ToString();
            //    GotItButtonText.GetComponent<Text>().text = Lang["label_gotit"].ToString();

            //    CloudText.GetComponent<Text>().text = Lang["label_cloud"].ToString();
            //    CloudText2.GetComponent<Text>().text = Lang["label_cloud2"].ToString();
            //    CloudText3.GetComponent<Text>().text = Lang["label_cloud3"].ToString();
            //    CloudText4.GetComponent<Text>().text = Lang["label_cloud4"].ToString();


                 Book1Title.GetComponent<Text>().text = Lang["label_the_elephant"].ToString();
                 Book1PreviewTitle.GetComponent<Text>().text = Lang["label_the_elephant"].ToString();
                 Game1PreviewTitle.GetComponent<Text>().text = Lang["label_the_elephant"].ToString();

                 Book2Title.GetComponent<Text>().text = Lang["label_the_fox"].ToString();
                 Book2PreviewTitle.GetComponent<Text>().text = Lang["label_the_fox"].ToString();
                 Game2PreviewTitle.GetComponent<Text>().text = Lang["label_the_fox"].ToString();

                  Book3Title.GetComponent<Text>().text = Lang["label_the_bear"].ToString();
                  Book3PreviewTitle.GetComponent<Text>().text = Lang["label_the_bear"].ToString();
                  Game3PreviewTitle.GetComponent<Text>().text = Lang["label_the_bear"].ToString();

            Book4Title.GetComponent<Text>().text = Lang["label_the_dog"].ToString();
            Book4PreviewTitle.GetComponent<Text>().text = Lang["label_the_dog"].ToString();
            Game4PreviewTitle.GetComponent<Text>().text = Lang["label_the_dog"].ToString();

            //    Book5Title.GetComponent<Text>().text = Lang["label_the_ladybug"].ToString();
            //    Book5PreviewTitle.GetComponent<Text>().text = Lang["label_the_ladybug"].ToString();
            //    Game5PreviewTitle.GetComponent<Text>().text = Lang["label_the_ladybug"].ToString();

            RecordText1.GetComponent<Text>().text = Lang["label_the_record"].ToString();
                  RecordText2.GetComponent<Text>().text = Lang["label_the_record"].ToString();
            RecordText3.GetComponent<Text>().text = Lang["label_the_record"].ToString();
            RecordText4.GetComponent<Text>().text = Lang["label_the_record"].ToString();
            //RecordText5.GetComponent<Text>().text = Lang["label_the_record"].ToString();

            BookAuthor1.GetComponent<Text>().text = Lang["label_book_author1"].ToString();
            BookAuthor2.GetComponent<Text>().text = Lang["label_book_author2"].ToString();
            BookAuthor3.GetComponent<Text>().text = Lang["label_book_author3"].ToString();
            BookAuthor4.GetComponent<Text>().text = Lang["label_book_author4"].ToString();
            //    BookAuthor5.GetComponent<Text>().text = Lang["label_book_author5"].ToString();

            //    GameReturn1.GetComponent<Text>().text = Lang["label_return"].ToString();
                 GameReturn2.GetComponent<Text>().text = Lang["label_return2"].ToString();
                 GameReturn3.GetComponent<Text>().text = Lang["label_return2"].ToString();
                 GameReturn4.GetComponent<Text>().text = Lang["label_return2"].ToString();
                 FoxGameReturn2.GetComponent<Text>().text = Lang["label_return2"].ToString();
                 FoxGameReturn3.GetComponent<Text>().text = Lang["label_return2"].ToString();
                 FoxGameReturn4.GetComponent<Text>().text = Lang["label_return2"].ToString();
                 BearGameReturn2.GetComponent<Text>().text = Lang["label_return2"].ToString();
                 BearGameReturn3.GetComponent<Text>().text = Lang["label_return2"].ToString();
                 BearGameReturn4.GetComponent<Text>().text = Lang["label_return2"].ToString();
                 DogGameReturn2.GetComponent<Text>().text = Lang["label_return2"].ToString();
                 DogGameReturn3.GetComponent<Text>().text = Lang["label_return2"].ToString();
                 DogGameReturn4.GetComponent<Text>().text = Lang["label_return2"].ToString();

            BearGameOk.GetComponent<Text>().text = Lang["label_ok"].ToString();
            //    GameReturn5.GetComponent<Text>().text = Lang["label_return"].ToString();

            RecorTitle.GetComponent<Text>().text = Lang["label_record"].ToString();

            BookRecordName1.GetComponent<Text>().text = Lang["label_record_book_1"].ToString();
            BookRecordName2.GetComponent<Text>().text = Lang["label_record_book_2"].ToString();
            BookRecordName3.GetComponent<Text>().text = Lang["label_record_book_3"].ToString();
            BookRecordName4.GetComponent<Text>().text = Lang["label_record_book_4"].ToString();
            BookRecordName5.GetComponent<Text>().text = Lang["label_record_book_5"].ToString();

            TextFeeding.GetComponent<Text>().text = Lang["label_feeding"].ToString();

            TextFOX.GetComponent<Text>().text = Lang["label_fox"].ToString();
            TextBEAR.GetComponent<Text>().text = Lang["label_bear"].ToString();
            TextWOLF.GetComponent<Text>().text = Lang["label_wolf"].ToString();
            TextRABBIT.GetComponent<Text>().text = Lang["label_rabbit"].ToString();


            TextD.GetComponent<Text>().text = Lang["label_D"].ToString();
            TextC.GetComponent<Text>().text = Lang["label_C"].ToString();
            TextH.GetComponent<Text>().text = Lang["label_H"].ToString();
            TextG.GetComponent<Text>().text = Lang["label_G"].ToString();
            TextS.GetComponent<Text>().text = Lang["label_S"].ToString();
            TextR.GetComponent<Text>().text = Lang["label_R"].ToString();

            ElephantPaintOk.GetComponent<Text>().text = Lang["label_ok"].ToString();
            FoxPaintOk.GetComponent<Text>().text = Lang["label_ok"].ToString();


            //}
            //catch
            //{

            //    Debug.Log("Translate Error");
            //}



        }



    }
     
}
