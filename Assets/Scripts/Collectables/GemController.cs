using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    [SerializeField] private Sprite[] gemSprite;
    private SpriteRenderer spriteRenderer;
    private int value;

    [SerializeField] private float rockChanceMultiplier;
    [SerializeField] private float copperChanceMultiplier;
    [SerializeField] private float ironChanceMultiplier1;
    [SerializeField] private float ironChanceMultiplier2;

    [SerializeField] private float goldChanceMultiplier1;
    [SerializeField] private float goldChanceMultiplier2;

    [SerializeField] private float emeraldChanceMultiplier;
    [SerializeField] private float diamondChanceMultiplier;

    private float rockChance() =>   rockChanceMultiplier - Time.deltaTime;
    private float copperChance() => copperChanceMultiplier - Time.deltaTime;
    private float ironChance() => ironChanceMultiplier2 - ((Time.deltaTime - ironChanceMultiplier1)*(Time.deltaTime - ironChanceMultiplier1));
    private float goldChance() => goldChanceMultiplier2 - ((Time.deltaTime - goldChanceMultiplier1)*(Time.deltaTime - ironChanceMultiplier1));
    private float emeraldChance() => Time.deltaTime - emeraldChanceMultiplier;
    private float diamondChance() => Time.deltaTime - diamondChanceMultiplier;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        int chance = Random.Range(0,100);
        //if ( chance <= rockChance() ) {
            spriteRenderer.sprite = gemSprite[0];
        //}
    }

    // Update is called once per frame
    public void AddPoints()
    {
        
    }
}
