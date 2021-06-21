using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsSystem : MonoBehaviour
{
    public TextMeshProUGUI coinsText;  // texto para indicar quantas moedas

    public int coins;        //quantidade de moedas 

    public static CoinsSystem instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        coins = PlayerPrefs.GetInt("coins");

        coinsText.SetText("" + coins);
    }



    public void UpdateCoins()
    {
        coins++;

        coinsText.SetText("" + coins);

        PlayerPrefs.SetInt("coins", coins);
    }

}
