using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float turnSpeed = 70.0f;
    private float speed = 30.0f;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Moves the car forward based on vertical input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        //Rotates the car based on horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
    }
}
