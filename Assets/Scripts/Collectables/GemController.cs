using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    [SerializeField] private Sprite[] gemSprite;
    private SpriteRenderer spriteRenderer;
    private int value;
    static private int rockValue = 50;
    static private int copperValue = 100;
    static private int ironValue = 200;
    static private int goldValue = 400;
    static private int emeraldValue = 1000;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void DefineGem( int time ) 
    {
        int valueMultiplier = Random.Range(0,100);
        int chosen = 0;
        value = valueMultiplier * ( 1 + time );

        if ( value < rockValue) {
            chosen = 0;
        } else if ( value < copperValue ) {
            chosen = 1;
        } else if ( value < ironValue ) {
            chosen = 2;
        } else if ( value < goldValue ) {
            chosen = 3;
        } else if ( value < emeraldValue ) {
            chosen = 4;
        } else {
            chosen = 5;
        }
        
        spriteRenderer.sprite = gemSprite[chosen];
    }

    // Update is called once per frame
    public void AddPoints()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AddPoints();
        }
        Destroy(gameObject);
    }
}
