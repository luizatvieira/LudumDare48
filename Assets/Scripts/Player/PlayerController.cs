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

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Debug.Log("wow much colision");
    //     if (collision.gameObject.tag == "Collectable")
    //     {
    //         //collision.gameObject.SendMessage("ApplyDamage", 10);
    //     }
    //     Destroy(collision.gameObject);
    // }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3( movement*movementSpeed*Time.deltaTime, 0f, 0f );
    }
}
