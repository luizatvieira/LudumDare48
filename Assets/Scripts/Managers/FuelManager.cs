using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private GameManager gameManager;
    private float currentFuel;
    [SerializeField] private float usedFuel = 1f;
    [SerializeField] private float maxFuel = 100;

    void Awake()
    {
        gameManager = gameObject.GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentFuel = maxFuel;
        InvokeRepeating( "DecFuel", 3f, 0.5f );
    }

    public void ResetFuel()
    {
        currentFuel = maxFuel;
    }

    private void DecFuel()
    {
        if ( gameManager.isGameRunning ) 
        {
            currentFuel -= usedFuel;
            slider.value = currentFuel/maxFuel;
            if ( currentFuel == 0 ) 
            {
                gameManager.EndPhase();
            }
        }
    }

    public void UpgradeFuel ()
    {
        maxFuel += maxFuel;
    }

    public void AddFuel( int receivedFuel )
    {
        currentFuel += receivedFuel;
    }

}
