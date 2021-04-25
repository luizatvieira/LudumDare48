using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] collectables;
    [SerializeField] private float spawnTime = 10f;
    [SerializeField] private float adjustSpawnTime = 10f;


    [SerializeField] private float gemChance = 60;
    [SerializeField] private float fuelChance = 10;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine( SpawnCollectables() );
        InvokeRepeating( "AdjustSpawnTime", 3.0f,   adjustSpawnTime);
    }

    private void AdjustSpawnTime ()
    {
        spawnTime -= 0.01f;
    }

    private IEnumerator SpawnCollectables ()
    {
        while (true) {
            yield return new WaitForSeconds(spawnTime);
            int chosen = 0;
            float location = Random.Range(-10,10 );

            int chance = Random.Range(0,100);

            if ( chance <= gemChance ) {
                chosen = 1;
            } else if ( chance <= fuelChance ) {
                chosen = 1;
            } else //Chooses Explosive
            {
                chosen = 2;
            }

            GameObject collectable = Instantiate( collectables[ chosen ], new Vector3( transform.position.x+location, transform.position.y, 0), Quaternion.identity );
            if (chosen == 1) 
            {
                GemController gem = collectable.GetComponent<GemController>();
                gem.DefineGem((int)Time.deltaTime);
            }
        }
    }
}
