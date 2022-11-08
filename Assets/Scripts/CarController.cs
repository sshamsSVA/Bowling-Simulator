using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    Rigidbody carRb;
    float initialForce = 100f;
    float newForce;
    float rotationSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        carRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(verticalInput > 0 || verticalInput < 0)
        {
            newForce = Mathf.Clamp(initialForce += 50f, 100, 8000);
            Debug.Log("Increasing " + newForce);
        }else
        {
            newForce = 0;
            initialForce = 100f;
        }

        Debug.Log("Moving: " + newForce);
        carRb.AddForce(Vector3.forward * verticalInput * newForce);
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);
        
        
    }
}
