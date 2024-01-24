using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CatCollision : MonoBehaviour
{
    //game objects
    private TextMeshProUGUI objectText;
    public GameObject panel;
    public GameObject victoryPanel;
    private GameObject[] Collectibles;


    //data used in code 
    private int score;
    public int scoreAdded;
    private int multiplier;
    private bool checker;
    private Vector3 startPos;

    

    //audiosources
    public AudioSource goalLand;
    public AudioSource victorySound;
    public AudioSource hitObjectSound;
    public AudioSource collectibleSound;





    public void Start() {
        //gets data needed and makes sure cat is set to active
        objectText = panel.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        startPos = transform.position;
        Collectibles = GameObject.FindGameObjectsWithTag("collectible");
        gameObject.SetActive(true);
        
         
    }


    public void Update() {
        //checks if all collectibles are in game and if they aren't displays victory panel and disables cat
        checker = CollectibleChecker();
        if (checker == true) {
            victorySound.Play();
            victoryPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    //function to check if collectibles from list are active in scene
    bool CollectibleChecker() {
     foreach(GameObject collectible in Collectibles) {
          if(collectible.activeSelf) {
             return false;
          }
     }
     return true;
    }

    

    void OnTriggerEnter(Collider hitty_thing) {
        DropKitty script = GetComponent<DropKitty>();
        if (hitty_thing.CompareTag("collectible")) {
            //gain score upon collecting collectible
            collectibleSound.Play();
            GainScore(multiplier);
            hitty_thing.gameObject.SetActive(false); //disables collectible upon collection
        }
        //dependent on the goal landed in alter the multiplier
        else if (hitty_thing.CompareTag("Goal1")) {
            LandedGoal(1);
            
        }
        else if (hitty_thing.CompareTag("Goal2")) {
            LandedGoal(2);
            
        }
        else if (hitty_thing.CompareTag("Goal3")) {
        
            LandedGoal(3);
            
        }

    }
    //function that adds score and prints it
    public void GainScore(int multiplier) {
        score = score + 10;
        objectText.text = "Score: " + score;

    }

    public void Reset() {
        //puts cat back in original pos and reactivates all collectibles
        transform.position = startPos;
        score = 0;

        foreach (GameObject collectible in Collectibles) {
            collectible.gameObject.SetActive(true);

        }
    }

    private void LandedGoal(int goalMultiplier) {
        //upon landing in goal move cat back
        transform.position = startPos;
        DropKitty script = GetComponent<DropKitty>();
        goalLand.Play();
        //multiply score by goal multiplier
        score = score* goalMultiplier;
        objectText.text = "Score: " + score;
        multiplier = 0;
        //reset trapdoor anim
        script.Restart();
        
    }


}
