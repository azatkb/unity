using System;
using UnityEngine;
using LitJson;
using System.IO;

namespace Assets.scripts
{
    public static class GameData 
    { 
        public static string GetJson()
        {

            TextAsset pathTxt = (TextAsset)Resources.Load("translate", typeof(TextAsset));

            Debug.Log(pathTxt);
            
            using (StreamReader sr = new StreamReader(new MemoryStream(pathTxt.bytes)))
            {
                return sr.ReadToEnd();
            }


        }

    }
}


