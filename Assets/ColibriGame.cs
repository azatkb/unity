using System;
using UnityEngine;
using LitJson;
using NatCorderU.Examples;

namespace Assets.scripts
{
    public class ColibriGame : Singleton<ColibriGame> {

        private GameObject voiceObject;
        private GameObject appObject;
        private GameObject recordManager;
        
        public bool isRecording = false;

        void Start() {

            this.IntObject();

        }

        private void  IntObject(){

            this.voiceObject = GameObject.FindGameObjectWithTag("Voice");
            this.appObject = GameObject.FindGameObjectWithTag("App");
            this.recordManager = GameObject.FindGameObjectWithTag("recordManager");

        }

        public void Success(){

            if (voiceObject == null)
            {
                this.IntObject();
            }

            voiceObject.GetComponent<VoiceBahavior>().Success();
        }


        public void Error() {

            if (voiceObject == null)
            {
                this.IntObject();
            }

            voiceObject.GetComponent<VoiceBahavior>().Error();

        }

        public void GreateJob() {

            if (voiceObject == null){
                this.IntObject();
            }

            voiceObject.GetComponent<VoiceBahavior>().GreateJob();

        }

        public void Ewesome(){

            if (voiceObject == null){
                this.IntObject();
            }

            voiceObject.GetComponent<VoiceBahavior>().Ewesome();

        }

        public void SetLevel(string id, int level){

            GameObject profile = GameObject.FindGameObjectWithTag("ProfilePanel");

            profile.GetComponent<ProfilePanel>().SetLevel(id, level);

        }

        public void Mute(){

            if (appObject == null){
                this.IntObject();
            }

            appObject.GetComponent<App>().MuteMusic();

        }

        public void RecoverMusic(){

            if (appObject == null){
                this.IntObject();
            }

            appObject.GetComponent<App>().RecoverMusic();

        }

        public void StartRecording(string name){

            if (recordManager == null){
                this.IntObject();
            }

            //if (!isRecording){
                isRecording = true;
                recordManager.GetComponent<ReplayCam>().StartRecording(name);
            //}
  

        }

        public void StopRecording(){

            if (recordManager == null){
                this.IntObject();
            }

            if (isRecording){
                isRecording = false;
                recordManager.GetComponent<ReplayCam>().StopRecording();
            }

        }

        public void ForseStopRecording()
        {

            if (recordManager == null) {
                this.IntObject();
            }

            if (isRecording) {
                isRecording = false;
                recordManager.GetComponent<ReplayCam>().BookName = null;
                recordManager.GetComponent<ReplayCam>().StopRecording();
            }

        }

    }

}


