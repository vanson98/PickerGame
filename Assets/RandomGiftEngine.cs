using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomGiftEngine : MonoBehaviour
{
    public Sprite[] Gifts = new Sprite[3];
    public AudioClip WonSoundClip;
    public AudioClip FailSoundClip;
    public int MaxRandomNumber = 4;

    private Transform[] items;
    
    void Start()
    {
        GetTopLevelChildren();
        RandomGift();
    }

    void Update()
    {
        
    }

    private void GetTopLevelChildren()
    {
        int childCount = gameObject.transform.childCount;
        items = new Transform[childCount];
        for (int i = 0; i < childCount; i++)
        {
            items[i] = gameObject.transform.GetChild(i);
        }
    }

    private void RandomGift()
    {
        var rnd = new System.Random();
        foreach (var item in items)
        {
            var giftRandomNumber = rnd.Next(0, MaxRandomNumber);
            var giftSprite = item.Find("Gift").transform.GetComponent<SpriteRenderer>();
            var giftInfo = item.Find("Gift").transform.GetComponent<GiftInfo>();

            
            if (giftRandomNumber > 2)
            {
                giftSprite.sprite = null;
                giftInfo.bonus = 0;
                item.GetComponent<AudioSource>().clip = FailSoundClip;
            }
            else
            {
                giftSprite.sprite = Gifts[giftRandomNumber];
                giftInfo.bonus = (giftRandomNumber + 1) * 100;
                item.GetComponent<AudioSource>().clip = WonSoundClip;
            }
            
        }
    }
}
