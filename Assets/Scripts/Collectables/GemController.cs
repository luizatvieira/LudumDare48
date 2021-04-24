using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    [SerializeField] private Sprite[] gemSprite;
    private SpriteRenderer spriteRenderer;
    private int value;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void DefineGem( float rockChance, float copperChance, float ironChance, float goldChance, float emeraldChance, float diamondChance ) 
    {
        int chance = Random.Range(0,100);
        int chosen = 0;

        if ( chance <= rockChance) {
            chosen = 0;
        } else if ( chance <= copperChance ) {
            chosen = 1;
        } else if ( chance <= ironChance ) {
            chosen = 2;
        } else if ( chance <= goldChance ) {
            chosen = 3;
        } else if ( chance <= emeraldChance ) {
            chosen = 4;
        } else if (chance <= diamondChance ) {
            chosen = 5;
        }
        
        spriteRenderer.sprite = gemSprite[0];
        value = ( (chosen * 20) + 1 ) * chance;
    }

    // Update is called once per frame
    public void AddPoints()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("wow much colision");
        if (collision.gameObject.tag == "Player")
        {
            AddPoints();
            //collision.gameObject.SendMessage("ApplyDamage", 10);
        }
        Destroy(gameObject);
    }
}
