using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Flipper : MonoBehaviour
{
    //components
    public HingeJoint hinge;
    Rigidbody rb;

    //data
    public float targetPosition;
    
    public float thrust;

    void Start() {
        //get components
        rb = GetComponent<Rigidbody>();
    }

    //put hinge back to original pos
    public void Down() {
        var spring = hinge.spring;
        spring.targetPosition = 0;
        hinge.spring = spring;
    }
 
 //lift hinge up
    public void Up() {
        var spring = hinge.spring;
        spring.targetPosition = targetPosition;
        hinge.spring = spring;
        rb.AddForce(transform.up * thrust);
    }

    public IEnumerator UpDown() {
        Up();
        yield return new WaitForSeconds(1);
        Down();
    }
    void OnTriggerEnter(Collider cat) {
        //if cat is hit, hit with flipper
        StartCoroutine(UpDown());
    }


}
