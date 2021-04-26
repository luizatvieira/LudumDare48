using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    private float movement;
    private float movementSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMove( InputValue movementValue )
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movement = movementVector.x;
    }

    private void HandeRotation ()
    {
        if ( transform.eulerAngles.z != 0f && movement == 0 )
        {
            if (transform.eulerAngles.z > 0 )
            {
                transform.eulerAngles -= new Vector3(0,0,1f);
            } 
            else if (transform.eulerAngles.z < 0 )
            {
                transform.eulerAngles += new Vector3(0,0,1f);
            }
        }
        else if ( movement != 0 )
        {
            if ( (transform.eulerAngles.z < 30f && movement > 0) )
            {
                transform.eulerAngles += new Vector3(0,0,1f);
            }
            else if ( transform.eulerAngles.z > -30f && movement < 0 )
            {
                transform.eulerAngles -= new Vector3(0,0,1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3( movement*movementSpeed*Time.deltaTime, 0f, 0f );
        HandeRotation();
    }
}
