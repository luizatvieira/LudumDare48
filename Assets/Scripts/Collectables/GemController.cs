using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Sprite[] gemSprite;
    private SpriteRenderer spriteRenderer;
    private int value;
    static private int rockValue = 50;
    static private int copperValue = 100;
    static private int ironValue = 200;
    static private int goldValue = 400;
    static private int emeraldValue = 1000;

    private MoneyManager moneyManager;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        moneyManager = FindObjectOfType<MoneyManager>();
        spriteRenderer.sprite = gemSprite[0];
    }

    public void DefineGem( int time ) 
    {
        int valueMultiplier = Random.Range(1,5);
        int chosen = 0;
        value = valueMultiplier * ( time );
        Debug.Log(time);
        
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameManager.isGameRunning )
        {
            SoundManager.PlaySound( SoundManager.Sound.Collect);
            moneyManager.AddMoney( value );
        }
        Destroy(gameObject);
    }
}
