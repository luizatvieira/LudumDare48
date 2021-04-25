using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private GameObject upgadeArmourButton;
    [SerializeField] private GameObject upgadeSafetyButton;
    [SerializeField] private TextMeshProUGUI armourUpText;
    [SerializeField] private TextMeshProUGUI fuelUpText;
    [SerializeField] private TextMeshProUGUI safetyUpText;
    private GameManager gameManager;
    private ArmourManager armourManager;
    private FuelManager fuelManager;
    private int currentMoney;
    private int armourCost;
    private int fuelCost;
    private int safetyCost;


    void Awake()
    {
        armourManager = GetComponent<ArmourManager>();
        fuelManager = GetComponent<FuelManager>();
        gameManager = GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentMoney = 0;
        armourCost = 100;
        fuelCost = 300;
        safetyCost = 600;
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
            if ( armourManager.maxArmour > 5 ) 
            {
                upgadeArmourButton.GetComponent<Image>().color = new Color( 140, 123, 64, 1);
                armourUpText.text = "SOLD OUT";
            } 
            else 
            {
                currentMoney -= armourCost;
                moneyText.text = currentMoney.ToString();
                armourManager.AddArmour();
                armourCost = armourCost*3;
                armourUpText.text = "$ "+armourCost.ToString();
            }
        }
    }

    public void BuyFuel()
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

    public void BuySafety()
    {
        if ( currentMoney >= safetyCost )
        {
            if ( gameManager.fuelChance < 100 )
            {
                currentMoney -= safetyCost;
                moneyText.text = currentMoney.ToString();
                safetyCost = safetyCost*safetyCost;
                safetyUpText.text = "$ "+safetyCost.ToString();
                gameManager.fuelChance += 10;
            } else {
                upgadeSafetyButton.GetComponent<Image>().color = new Color( 140, 123, 64, 1);
                safetyUpText.text = "SOLD OUT";
            }
        }
    }

}
