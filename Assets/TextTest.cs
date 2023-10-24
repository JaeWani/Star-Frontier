using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Febucci.UI.Core;
using Febucci.UI;


public class TextTest : MonoBehaviour
{
    TextAnimator textAnimator;
    TextAnimatorPlayer textAnimatorPlayer;
    void Start()
    {
        textAnimator = GetComponent<TextAnimator>();
        textAnimatorPlayer = GetComponent<TextAnimatorPlayer>();


    }

    void Update()
    {
        
    }
}
