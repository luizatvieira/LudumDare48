using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourManager : MonoBehaviour
{
    private int maxArmour = 0;
    private int currentArmour = 0;
    private GameManager gameManager;
    [SerializeField] private GameObject armourIcon;
    private GameObject[] armourIcons;

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
        maxArmour += 1;
        armourIcons[maxArmour] = Instantiate( armourIcon, new Vector3( 0 + (float) maxArmour, 0,0 ) ,Quaternion.identity);
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
