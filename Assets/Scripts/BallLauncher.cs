using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    Rigidbody rb;
    float initialForce = 1.5f;
    float torqueZ;
    float torqueY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            initialForce = Mathf.Clamp(initialForce * 1.02f, 0, 12000);
           // Debug.Log(initialForce);
            //torqueY = Random.Range(-25f, 25f);
            torqueZ = Random.Range(-1f, 1f);
        }

        
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("z: " + torqueZ);
            Debug.Log("y: " + torqueY);
            PushBall();
        }

    }

    void PushBall()
    {
        rb.AddForce(Vector3.forward * initialForce, ForceMode.Impulse);
        rb.AddTorque(new Vector3(10 * 0, 0, torqueZ), ForceMode.Impulse);
    }

}
