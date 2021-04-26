using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmourManager : MonoBehaviour
{
    public int maxArmour = 0;
    private int currentArmour = 0;
    private GameManager gameManager;
    [SerializeField] private GameObject[] armourIcons = new GameObject[5];

    void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }
    public void ResetArmour()
    {
        currentArmour = maxArmour;
        for ( int i = 0; i < maxArmour; i++ )
        {
            armourIcons[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
    }
    public void AddArmour()
    {
        if (maxArmour<5)
        {
            maxArmour += 1;
            armourIcons[maxArmour-1].SetActive(true);
        }
    }
    public void DecArmour( int damage )
    {
        for ( int i = currentArmour; i >= currentArmour- damage && i > 0; i-- )
        {
            armourIcons[i-1].GetComponent<Image>().color = new Color(0, 0, 0, 1);
        }
        currentArmour -= damage;
        if( currentArmour <= 0 )
        {
            gameManager.EndPhase();
        }
    }
}
