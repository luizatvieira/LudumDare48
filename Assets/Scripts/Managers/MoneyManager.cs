using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private GameObject upgadeArmourButton;
    [SerializeField] private TextMeshProUGUI armourUpText;
    [SerializeField] private TextMeshProUGUI fuelUpText;
    private ArmourManager armourManager;
    private FuelManager fuelManager;
    private int currentMoney;
    private int armourCost;
    private int fuelCost;

    void Awake()
    {
        armourManager = GetComponent<ArmourManager>();
        fuelManager = GetComponent<FuelManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentMoney = 0;
        armourCost = 100;
        fuelCost = 300;
    }

    private void DecMoney( int value )
    {
        currentMoney -= value;
        moneyText.text = currentMoney.ToString();
    }

    public void AddMoney( int value )
    {
        currentMoney += value;
        moneyText.text = currentMoney.ToString();
    }

    public void BuyArmour() 
    {
        if ( currentMoney >= armourCost )
        {
            currentMoney -= armourCost;
            moneyText.text = currentMoney.ToString();
            armourManager.AddArmour();
            armourCost = armourCost*3;
            if ( armourManager.maxArmour > 5 ) 
            {
                upgadeArmourButton.GetComponent<Image>().color = new Color( 140, 123, 64, 1);
                armourUpText.text = "SOLD OUT";
            } 
            else 
            {
                armourUpText.text = "$ "+armourCost.ToString();
            }
        }
    }

    public void BuyFueld()
    {
        if ( currentMoney >= fuelCost )
        {
            currentMoney -= fuelCost;
            moneyText.text = currentMoney.ToString();
            fuelCost = fuelCost*5;
            fuelUpText.text = "$ "+fuelCost.ToString();
            fuelManager.UpgradeFuel();
        }
    }

}
