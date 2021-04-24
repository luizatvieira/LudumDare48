using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    [SerializeField] private int value;
    private float movementSpeed = 2;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3( 0f, movementSpeed*Time.deltaTime, 0f);
    }
}
