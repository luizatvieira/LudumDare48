using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] collectables;
    [SerializeField] private float spawnTime = 3f;
    [SerializeField] private float adjustTime = 10f;

    [SerializeField] private float gemChance = 60;
    [SerializeField] private float fuelChance = 10;

    private float rockChance;
    private float copperChance;

    private float ironChance;
    private float goldChance;

    private float emeraldChance;
    private float diamondChance;

    // Update is called once per frame
    void Start()
    {
        rockChance = 100;
        copperChance = 0;
        ironChance = 0;
        goldChance = 0;
        emeraldChance = 0;
        diamondChance = 0;

        StartCoroutine( SpawnCollectables() );
        InvokeRepeating( "VariateGemChances", 3.0f, adjustTime );
        InvokeRepeating( "AdjustSpawnTime", 3.0f,   adjustTime);
    }

    private void AdjustSpawnTime ()
    {
        spawnTime -= 0.1f;
    }

    private void VariateGemChances ()
    {
        //iff I have time I will redo this in a decent way
        if ( rockChance > 80 )
        {
            rockChance--;
            copperChance++;
        } 
        else if ( rockChance > 40 ) 
        {
            rockChance -= 2;
            copperChance++;
            ironChance++;
        } 
        else if ( rockChance > 0 )
        {
            rockChance -= 4;
            copperChance += 2;
            ironChance++;
            goldChance++;
        }
        else if ( copperChance > 0 )
        {
            copperChance -= 2;
            ironChance++;
            goldChance++;
        }
        else if ( ironChance > 0 )
        {
            ironChance -= 3;
            goldChance++;
            emeraldChance++;
            diamondChance++;
        } else if ( goldChance > 0 )
        {
            goldChance -= 2;
            emeraldChance++;
            diamondChance++;
        }
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
                gem.DefineGem( rockChance, copperChance, ironChance, goldChance, emeraldChance, diamondChance );
            }
        }
    }
}
