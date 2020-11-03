using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] blueBox;
    [SerializeField]
    private GameObject[] pinkBox;

    private List<BoxCollider2D> blueBoxCollider;
    private List<BoxCollider2D> pinkBoxCollider;

    private List<SpriteRenderer> blueBoxSprite;
    private List<SpriteRenderer> pinkBoxSprite;

    private bool isBlue = false;

    // Start is called before the first frame update
    void Start()
    {
        blueBoxCollider = new List<BoxCollider2D>();
        blueBoxSprite = new List<SpriteRenderer>();
        pinkBoxCollider = new List<BoxCollider2D>();
        pinkBoxSprite = new List<SpriteRenderer>();

        for(int i = 0; i < blueBox.Length; i++)
        {
            blueBoxCollider.Add(blueBox[i].GetComponent<BoxCollider2D>());
            blueBoxSprite.Add(blueBox[i].transform.GetComponent<SpriteRenderer>());
        }

        for (int i = 0; i < pinkBox.Length; i++)
        {
            pinkBoxCollider.Add(pinkBox[i].transform.GetComponent<BoxCollider2D>());
            pinkBoxSprite.Add(pinkBox[i].transform.GetComponent<SpriteRenderer>());
        }
        Toggle();

    }

    public void Toggle()
    {
        
        if (isBlue)
        {
            for(int i = 0; i < blueBox.Length; i++)
            {
                blueBoxCollider[i].isTrigger = true;
                blueBoxSprite[i].color=new Color32(255,255,255,120);
            }

            for (int i = 0; i < pinkBox.Length; i++)
            {
                pinkBoxCollider[i].isTrigger = false;
                pinkBoxSprite[i].color = new Color32(255, 255, 255, 255);
            }
            isBlue = false;
        }
        else
        {
            for (int i = 0; i < blueBox.Length; i++)
            {
                blueBoxCollider[i].isTrigger = false;
                blueBoxSprite[i].color = new Color32(255, 255, 255, 255);
            }

            for (int i = 0; i < pinkBox.Length; i++)
            {
                pinkBoxCollider[i].isTrigger = true;
                pinkBoxSprite[i].color = new Color32(255, 255, 255, 120);
            }
            isBlue=true;
        }
    }
}
