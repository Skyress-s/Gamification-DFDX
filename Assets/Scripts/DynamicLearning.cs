using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicLearning : MonoBehaviour
{
    public Sprite[] images;
    public Image imageContainer;
    private int index;

    public CanvasGroup[] continueAndBack; // continue is 0, back is 1 

    public void Continue()
    {
        if (index == 4)
            return;
        index++;
    }

    public void GoBack()
    {
        if (index == 0)
            return;
        index--;

    }
    
    public void Start()
    {
        index = 0;
    }

    public void OnEnable()
    {
        index = 0;
    }

    public void Update()
    {
        if (index == 0) // hide go back button
            continueAndBack[1].alpha = 0;
        else
            continueAndBack[1].alpha = 1;
        
        if (index == 4) // hide go forward
            continueAndBack[0].alpha = 0;
        else
            continueAndBack[0].alpha = 1;
        
        
        
        imageContainer.sprite = images[index];

    }
}
