using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    [SerializeField] private int value;
    private float movementSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3( 0f, movementSpeed*Time.deltaTime, 0f);
    }

    private void OnColisionEnter2D( Collision2D collision )
    {
        if (collision.gameObject.tag == "Player")
        {
            //Points;
        } else 
        {
            Destroy( gameObject );
        }
    }
}
