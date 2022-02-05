using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerProfile : MonoBehaviour
{
   
    public GameObject EnergyText;
    public GameObject movesText;
    
    TMP_Text TextTMP;
    public static int moves = 0;
    private void Start()
    {
        

        TextTMP = movesText.GetComponent<TMP_Text>();
    }
    private void Update()
    {
        
        TextTMP.text = ($"Moves: {moves.ToString()}");
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
