using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] collectables;
    private float spawnTime = 1f;

    [SerializeField] private float gemChance = 60;
    [SerializeField] private float fuelChance = 10;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("SpawnCollectables", 3.0f, spawnTime);
    }

    private void SpawnCollectables ()
    {
        int chosen = 0;
        float location = Random.Range(-5,5 );

        int chance = Random.Range(0,100);
        if ( chance <= gemChance ) {
            chosen = 1;
        } else if ( chance <= fuelChance ) {
            chosen = 1;
        } else //Chooses Explosive
        {
            chosen = 2;
        }

        Instantiate( collectables[ chosen ], new Vector3( transform.position.x+location, transform.position.y, 0), Quaternion.identity );
    }
}
