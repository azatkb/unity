using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class ProfilePanel : MonoBehaviour {

    public GameObject Panel;

    public Button CloseButton;
    public Button OkButton;
    public Button CanselButton;

    public Button CloseButtonAddUser;

    private List<Person> AllUsers;

    public Person CurrentUser;

    public RawImage CurrentUserPhoto;
    public GameObject CurrentUserName;
    public GameObject CurrentUserLevel;


    public Text UserRowName;
    public Text UserRowLevel;
    public Button UserRowButton;

    public Text UserRowName1;
    public Text UserRowLevel1;
    public Button UserRowButton1;

    public Text UserRowName2;
    public Text UserRowLevel2;
    public Button UserRowButton2;

    string UserID = null;
    string UserID2 = null;
    string UserID3 = null;


    public Texture2D AddphotoTexture;
    public Button AddUserButton;
    public GameObject AddUserPanel;
    public Button AddUserConfirmButton;
    public Text AddUserText;

    public GameObject MainScreen;

    void  Start(){

        Panel.SetActive(false);

        //AddUserPanel.SetActive(false);

        //CloseButton.onClick.AddListener(() => {

        //    this.Panel.SetActive(false);

        //});

        //OkButton.onClick.AddListener(() => {

        //    this.Panel.SetActive(false);

        //});

        //CanselButton.onClick.AddListener(() => {

        //    this.Panel.SetActive(false);

        //});

        //CloseButtonAddUser.onClick.AddListener(() => {

        //    this.AddUserPanel.SetActive(false);

        //});

        //AddUserButton.onClick.AddListener(() => {

        //    this.AddUserPanel.SetActive(true);

        //});

        //AddUserConfirmButton.onClick.AddListener(() => {

        //   string UserName =  AddUserText.text;

        //    Debug.Log(UserName.Length);

        //   if(UserName.Length > 0){

        //        if (PlayerPrefs.HasKey(UserName))
        //        {
        //            return;
        //        }

        //        Person user = new Person();

        //        user.Id = Guid.NewGuid().ToString();

        //        user.Name = UserName;

        //        user.Level = 0;

        //        if (AddphotoTexture != null)
        //        {

        //            user.Image = Texture2DToBase64(AddphotoTexture);

        //        }

        //        AllUsers.Add(user);

        //        SaveUser();

        //        AddUserText.text = "";

        //        AddphotoTexture = null;

        //        AddUserPanel.SetActive(false);

        //        GetUsers();
        //    }


        //});

        //UserRowButton.onClick.AddListener(() =>{

        //    GetCurrentUser(UserID);

        //});

        //UserRowButton1.onClick.AddListener(() => {

        //    GetCurrentUser(UserID2);

        //});

        //UserRowButton2.onClick.AddListener(() => {

        //    GetCurrentUser(UserID3);

        //});

        //GetUsers();

   

    }

    public void GetUsers(){
   
       AllUsers = new List<Person>();

       string usersJson =  PlayerPrefs.GetString("Users");
    

       if(!string.IsNullOrEmpty(usersJson)){

            using (StreamReader sr = new StreamReader(new MemoryStream(Encoding.ASCII.GetBytes(usersJson)))){

                string UsersText = sr.ReadToEnd();

                JsonData usersData = JsonMapper.ToObject(UsersText);

                for (int i = 0; i < usersData.Count; i++){

                    Person user = new Person();

                    user.Name = usersData[i]["Name"].ToString();

                    user.Level = (int)usersData[i]["Level"];

                    user.Id = usersData[i]["Id"].ToString();

                    if (usersData[i]["Image"] != null)
                    {
                        user.Image = usersData[i]["Image"].ToString();
                    }

                    AllUsers.Add(user);

                }

            }

            GetCurrentUser();

            InitRows();

           

        }

        if(AllUsers.Count > 2){

            AddUserButton.gameObject.SetActive(false);

        }



    }

    public void SaveUser(){

        string usersJson = JsonMapper.ToJson(AllUsers);

        PlayerPrefs.SetString("Users", usersJson);

        PlayerPrefs.Save();

    }

    public void GetCurrentUser(string Id = null){

        if(string.IsNullOrEmpty(Id)){

            Id = PlayerPrefs.GetString("CurrentUser");

        }

        Person currentUser = null;

        if ((Id.Length == 0) || (AllUsers.Count == 0))
        {

            currentUser = AllUsers[0];

            PlayerPrefs.SetString("CurrentUser", AllUsers[0].Id);

        }
        else{

            for (var i = 0; i < AllUsers.Count; i++) {

                if (AllUsers[i].Id == Id){

                    currentUser = AllUsers[i];

                }

            }

        }

        if(currentUser != null){

            CurrentUserName.GetComponent<Text>().text = currentUser.Name;

            CurrentUserLevel.GetComponent<Text>().text = currentUser.Level.ToString();

            if(currentUser.Image != null){
                CurrentUserPhoto.texture = Base64ToTexture2D(currentUser.Image);
            }

            this.MainScreen.GetComponent<MainScreen>().State();

            Debug.Log("Current User Set");
        }

        
        

    }

    public void SetLevel(string id, int level){

        for (var i = 0; i < AllUsers.Count; i++){ 

            if (AllUsers[i].Id == id){
             
                if(AllUsers[i].Level < level){
                    AllUsers[i].Level = level;
                }
            }

        }

        SaveUser();

        GetCurrentUser();

        InitRows();
    }


    public int  GetLevel(string id){

        for (var i = 0; i < AllUsers.Count; i++)
        {

            if (AllUsers[i].Id == id)
            {

                return AllUsers[i].Level;

            }

        }

        return 0;

    }

    void InitRows()
    {

        if (AllUsers.Count != 0)
        {

            if (AllUsers.Count > 0)
            {

                UserRowName.text = AllUsers[0].Name.ToString();

                UserRowLevel.text = AllUsers[0].Level.ToString();

                UserID = AllUsers[0].Id;

            }
            if (AllUsers.Count > 1)
            {

                UserRowName1.text = AllUsers[1].Name.ToString();

                UserRowLevel1.text = AllUsers[1].Level.ToString();

                UserID2 = AllUsers[1].Id;

            }
            if (AllUsers.Count > 2)
            {

                UserRowName2.text = AllUsers[2].Name.ToString();

                UserRowLevel2.text = AllUsers[2].Level.ToString();

                UserID3 = AllUsers[2].Id;

            }

        }

    }

    public static string Texture2DToBase64(Texture2D texture)
    {
        byte[] imageData = texture.EncodeToPNG();
        return Convert.ToBase64String(imageData);
    }

    public static Texture2D Base64ToTexture2D(string encodedData)
    {
        byte[] imageData = Convert.FromBase64String(encodedData);

        int width, height;
        GetImageSize(imageData, out width, out height);

        Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false, true);
        texture.hideFlags = HideFlags.HideAndDontSave;
        texture.filterMode = FilterMode.Point;
        texture.LoadImage(imageData);

        return texture;
    }

    private static void GetImageSize(byte[] imageData, out int width, out int height)
    {
        width = ReadInt(imageData, 3 + 15);
        height = ReadInt(imageData, 3 + 15 + 2 + 2);
    }

    private static int ReadInt(byte[] imageData, int offset)
    {
        return (imageData[offset] << 8) | imageData[offset + 1];
    }

}

public class Person{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public string Image { get; set; }
    public Person(){}
    public Person(string id, string name, int level, string image){
        this.Name = name;
        this.Level = level;
        this.Id = id;
        this.Image = image;
    }
}

