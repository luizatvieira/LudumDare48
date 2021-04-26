using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour
{
    private FuelManager fuelManager;

    void Awake()
    {
        fuelManager = FindObjectOfType<FuelManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.PlaySound( SoundManager.Sound.Collect);
            fuelManager.AddFuel( Random.Range(0,50) );
        }
        Destroy(gameObject);
    }
}
