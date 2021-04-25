using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveController : MonoBehaviour
{
    [SerializeField] private Sprite[] explosiveSprite;
    private SpriteRenderer spriteRenderer;
    private int damage;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        int damage = Random.Range(0,1);
        spriteRenderer.sprite = explosiveSprite[damage];
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //DecArmour( damage );
        }
        Destroy(gameObject);
    }
}
