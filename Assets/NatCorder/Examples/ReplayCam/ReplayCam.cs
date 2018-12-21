/* 
*   NatCorder
*   Copyright (c) 2018 Yusuf Olokoba
*/

namespace NatCorderU.Examples {

    using NatCorderU;
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using Core;
    using Core.Recorders;

    public class ReplayCam : MonoBehaviour {

        [Header("Recording")]
        public Container container = Container.MP4;

        [Header("Microphone")]
        public bool recordMicrophone;
        public AudioSource microphoneSource;
        public GameObject canvas;

        private CameraRecorder videoRecorder;
        private AudioRecorder audioRecorder;

        public string BookName;

        public void StartRecording(string bookName = null) {

            BookName = bookName;

            canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        
            recordMicrophone &= container == Container.MP4;
      
            var width = 720;
            var height = width * Screen.height / Screen.width;
            var framerate = container == Container.GIF ? 10 : 30;
            var videoFormat = new VideoFormat(width, (int)height, framerate);
            var audioFormat = recordMicrophone ? AudioFormat.Unity: AudioFormat.None;
      
            NatCorder.StartRecording(container, videoFormat, audioFormat, OnReplay);
            videoRecorder = CameraRecorder.Create(Camera.main); videoRecorder.recordEveryNthFrame = 5;
           
            if (container == Container.GIF)
                videoRecorder.recordEveryNthFrame = 5;
       
            if (recordMicrophone)
            {
                StartMicrophone();
                audioRecorder = AudioRecorder.Create(microphoneSource, true);
            }
        }

        private void StartMicrophone () {
#if !UNITY_WEBGL || UNITY_EDITOR // No `Microphone` API on WebGL :(
            //Create a microphone clip
            microphoneSource.clip = Microphone.Start(null, true, 60, 48000);
            while (Microphone.GetPosition(null) <= 0) ;
            //Play through audio source
            microphoneSource.timeSamples = Microphone.GetPosition(null);
            microphoneSource.loop = true;
            microphoneSource.Play();
#endif
        }

        public void StopRecording () {
            Debug.Log("Stop Recording");
            canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            // Stop the microphone if we used it for recording
            if (recordMicrophone)
            {
                Microphone.End(null);
                microphoneSource.Stop();
                audioRecorder.Dispose();
            }
            // Stop the recording
            videoRecorder.Dispose();
            NatCorder.StopRecording();
            //videoRecorder.
        }

        void OnReplay (string path) {
            //Debug.Log("Saved recording to: "+path);
            // Playback the video
            #if UNITY_IOS
            Handheld.PlayFullScreenMovie("file://" + path);
            #elif UNITY_ANDROID
            //Handheld.PlayFullScreenMovie(path);

            if(this.BookName != null){

                PlayerPrefs.SetString(BookName, path);
                PlayerPrefs.Save();
                BookName = null;
            }

            

            #endif
        }
    }
}