using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourManager : MonoBehaviour
{
    public int maxArmour = 0;
    private int currentArmour = 0;
    private GameManager gameManager;
    [SerializeField] private GameObject armourIcon;
    private GameObject[] armourIcons = new GameObject[5];

    void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }
    public void ResetArmour()
    {
        currentArmour = maxArmour;
    }
    public void AddArmour()
    {
        if (maxArmour<5)
        {
            maxArmour += 1;
            armourIcons[maxArmour-1] = Instantiate( armourIcon, new Vector3( -11.7f + (float) maxArmour, 3.3f,0 ) ,Quaternion.identity);
        }
    }
    public void DecArmour( int damage )
    {
        for ( int i = currentArmour; i >= currentArmour- damage && i > 0; i-- )
        {
            armourIcons[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        }
        currentArmour -= damage;
        if( currentArmour <= 0 )
        {
            gameManager.EndPhase();
        }
    }
}
