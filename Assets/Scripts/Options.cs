using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class Options : MonoBehaviour
{
    private float masterAudio;
    [SerializeField] private AudioSource[] speakers;


    //runs before anything else
   void Awake() {
    masterAudio = GetFloat("volume");
    //speakers = FindObjectsOfType<AudioSource>(); - finds any audiosources and puts them in our list
    UpdateSpeakers(masterAudio); //updates the audiosources in our list with the volume we want it


    }

//useful functions for setting and getting floats - also saves player preferences
   public void SetFloat(string KeyName, float Value) {
    PlayerPrefs.SetFloat(KeyName, Value);

    }
    public float GetFloat(string KeyName) {
        return PlayerPrefs.GetFloat(KeyName);
    }


    public void SliderValueUpdate(Slider slider) {
     masterAudio = slider.value;  //updates the volumme to what the slider is
     SetFloat("volume", masterAudio);
     UpdateSpeakers(masterAudio);
    // PlayerPrefs.SetFloat("volume",masterAudio);
    
    }

    private void UpdateSpeakers(float volume) {
        foreach (AudioSource speaker in speakers ){
            speaker.volume = volume; //sets each audiosource to the same volume

        }
    }
    public void Quit() {
        Application.Quit();
    }


}
