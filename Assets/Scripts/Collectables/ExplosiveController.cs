using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveController : MonoBehaviour
{
    [SerializeField] private Sprite[] explosiveSprite;
    private SpriteRenderer spriteRenderer;
    private ArmourManager armourManager;
    private int damage;

    void Awake()
    {
        armourManager = FindObjectOfType<ArmourManager>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        int damage = Random.Range(0,2);
        spriteRenderer.sprite = explosiveSprite[damage];
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            armourManager.DecArmour( damage+1 );
        }
        Destroy(gameObject);
    }
}
