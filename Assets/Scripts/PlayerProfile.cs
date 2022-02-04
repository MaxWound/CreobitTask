using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerProfile : MonoBehaviour
{
    bool withAddon;
    public GameObject EnergyText;
    public GameObject movesText;
    TMP_Text EnergyText_Text;
    TMP_Text TextTMP;
    public static int moves = 0;
    private void Start()
    {
        EnergyText_Text = EnergyText.GetComponent<TMP_Text>();
        if (GameObject.Find("AddonManager").GetComponent<AddonBoolean>().PlayWithAddon == true)
        {
            EnergyText.SetActive(true);
            withAddon = true;
        }
        else
        {
            EnergyText.SetActive(false);
            withAddon = false;
        }

        TextTMP = movesText.GetComponent<TMP_Text>();
    }
    private void Update()
    {
        if(withAddon == true)
        {
            EnergyText_Text.text = ($"Energy: {AddonBoolean.Energy.ToString()}");
        }
        TextTMP.text = ($"Moves: {moves.ToString()}");
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
