using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    private float movement;
    private float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMove( InputValue movementValue )
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movement = movementVector.x;
        Debug.Log("bla");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3( movement*movementSpeed*Time.deltaTime, 0f, 0f );
    }
}
