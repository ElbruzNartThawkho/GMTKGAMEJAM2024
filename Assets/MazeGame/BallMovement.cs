using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float power;
    Rigidbody rb;
    float inputX;
    float inputY;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal"); 
        inputY = Input.GetAxis("Vertical");  
        rb.AddForce(inputX*power,0,inputY*power);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            Debug.Log("kazandýnýz");
        }
    }
}
