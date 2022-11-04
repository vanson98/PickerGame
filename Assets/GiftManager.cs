using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftManager : MonoBehaviour
{
    public int PickNumber = 2;

    public static GiftManager instance;
    [NonSerialized] public int BonusTotal = 0;
    
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
    }

    private void Start()
    {
        InitNumberOfPick(null);
    }

    public void InitNumberOfPick(int? numberOfPick)
    {
        if(numberOfPick != null)
        {
            PickNumber = numberOfPick.Value;
        }
        GameObject.Find("NumberOfPick").GetComponent<Text>().text = "Number of picks: " + PickNumber;
    }
}
