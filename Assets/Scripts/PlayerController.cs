using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{

    float shipRotation = 0.0f;
    public float speed = 20.0f;
    
    void Start()
    {        
    }   
    
    void Update()
	{     
        shipRotation = shipRotation + (Input.GetAxis("Horizontal") * 4);
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, shipRotation, 0.0f * 25);
        
        float moveForward = Input.GetAxis("Vertical");

        GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * speed * moveForward);


        //A D side to side
        if (Input.GetKey(KeyCode.Q))
        {
            GetComponent<Rigidbody>().AddRelativeForce(-speed, 0, 0);

        }

        if (Input.GetKey(KeyCode.E))
        {
            GetComponent<Rigidbody>().AddRelativeForce(speed, 0, 0);

        }
    }
    
}
