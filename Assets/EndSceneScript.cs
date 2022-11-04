using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneScript : MonoBehaviour
{
    public Text EndGameMessage;
    private void Start()
    {
        var bonusTotal = GiftManager.instance.BonusTotal;
        if (bonusTotal > 0)
        {
            EndGameMessage.text = "You won " + bonusTotal + "$";
        }
        else
        {
            EndGameMessage.text = "You lose! ";
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
        SceneManager.sceneLoaded += OnSceneLoaded;
      
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "GamePlay")
        {
            GiftManager.instance.InitNumberOfPick(3);
            GiftManager.instance.BonusTotal = 0;
        }
       
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
