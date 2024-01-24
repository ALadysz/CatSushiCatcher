using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropKitty : MonoBehaviour
{


    //variables for the left and right movement of cat
    public float delta = 1.5f;  // Amount to move left and right from the start point
    public float speed = 2.0f; 
    private Vector3 startPos;
    private bool move = true;

    //variables for the trapdoor opening
    public Animator trapAnim;
    public GameObject trapdoor;
    public AudioSource trapdoorwoosh;

    //variables for the reset rotation function
    private Transform startRot;
    private Rigidbody rb;
   



    public void Start() {
        //set/get variables and components
        startPos = transform.position;
        trapAnim = trapdoor.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, -1));
    }

    public void Stop() {
        //function for when button is pressed - stops left right movement and opens trapdoor
        move = false; 
        trapAnim.SetTrigger("Open");
        trapdoorwoosh.Play();
        rb.isKinematic = false;


    }
    public void Restart() {
        // reset button function - activates left right movement and closes trapdoor
        move = true;
        trapAnim.SetTrigger("Close");
        rb.isKinematic = true;
        //resets rotation back to original
        transform.rotation = Quaternion.identity;
        transform.rotation = Quaternion.LookRotation(new Vector3(0,0,-1));


    }
    void Update() {
        if (move == true){
            //moves cat left and right
            Vector3 v = startPos;
            v.z += delta * Mathf.Sin(Time.time * speed);
            transform.position = v;
            
        }
    }

}

