using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerY : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float xRange = 10.0f;
    public float speed = 10.0f;
    public float horizontalinput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   //Keep Player in bounds
        if (transform.position.x < -xRange) { transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); }
        if (transform.position.x > xRange) { transform.position = new Vector3(xRange, transform.position.y, transform.position.z); }
        horizontalinput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalinput * Time.deltaTime * speed);
        if (Input.GetKeyDown(KeyCode.Space))
        {//Launch a projectile from the Player}
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
