using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movements : MonoBehaviour
{
    Rigidbody rb; 
 [SerializeField] float mainThrust = 100f;
 [SerializeField] float rotationThrust = 50f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
     
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


   void ProcessThrust()
   {
    if(Input.GetKey(KeyCode.Space))
    {
        Debug.Log("SpacePressed");
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
   
   }
   }
   void ProcessRotation()
   {
     if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust); // to extact method press 'Ctrl+.' / 'Fn+F2'
        }
        else if(Input.GetKey(KeyCode.A)) //So the player don't press the 'A' & 'D' at the same time
   {
               ApplyRotation(rotationThrust);    
               
   }
   }

     void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate 
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
      rb.freezeRotation = false; // unfreeze rotation so the physics system can take over
    }
}
