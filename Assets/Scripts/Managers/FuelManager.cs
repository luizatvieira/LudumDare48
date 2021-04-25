using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private float currentFuel;
    private float usedFuel = 1f;
    private float maxFuel = 100;

    // Start is called before the first frame update
    void Start()
    {
        currentFuel = maxFuel;
        InvokeRepeating( "DecFuel", 3f, 0.5f );
    }

    private void DecFuel()
    {
        currentFuel -= usedFuel;
        slider.value = currentFuel/maxFuel;
    }

    public void AddFuel( int receivedFuel )
    {
        currentFuel += receivedFuel;
    }

}
