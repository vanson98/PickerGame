using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GiftItemBehavior : MonoBehaviour
{
    public GameObject MaskItem;
    public AudioSource PickSound;

    private GiftManager giftManager;
    
    private void Start()
    {
        giftManager = GiftManager.instance;
    }
    private void OnMouseDown()
    {
        if(giftManager.PickNumber > 0)
        {
            MaskItem.SetActive(false);
            PickSound.Play();

            // add point and minus pick number
            var gift = transform.Find("Gift").GetComponent<GiftInfo>();
            giftManager.BonusTotal += gift.bonus;
            giftManager.PickNumber--;

            // update UI
            GameObject.Find("TotalText").GetComponent<Text>().text = "Total: " + GiftManager.instance.BonusTotal + "$";
            GameObject.Find("NumberOfPick").GetComponent<Text>().text = "Number of picks: " + giftManager.PickNumber;
            
            if(giftManager.PickNumber == 0)
            {
                Invoke("EndGame", 1);
            }
        }
    }

    private void EndGame()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
