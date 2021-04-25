using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour
{
    [SerializeField] private FuelManager fuelManager;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            fuelManager.AddFuel( Random.Range(0,50) );
        }
        Destroy(gameObject);
    }
}
