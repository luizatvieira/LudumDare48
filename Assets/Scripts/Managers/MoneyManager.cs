using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    private int currentMoney;

    // Start is called before the first frame update
    void Start()
    {
        currentMoney = 0;
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

}
