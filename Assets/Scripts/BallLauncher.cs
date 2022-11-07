using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    Rigidbody rb;
    float initialForce = .5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            initialForce = Mathf.Clamp(initialForce * 1.15f, 0, 12000);
            Debug.Log(initialForce);
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(Vector3.forward * initialForce * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
