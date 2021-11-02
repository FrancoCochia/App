using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class SwitchHandler : MonoBehaviour
{
    private int switchstate = 1;
    public GameObject switchBtn;
    public RawImage background;
    Color color;
    
    // Color y animación de los toogle:
    public void OnSwitchButtonClicked()
    {
        switchBtn.transform.DOLocalMoveX(-switchBtn.transform.localPosition.x, 0.2f);
        switchstate = Math.Sign(-switchBtn.transform.localPosition.x);

        if (switchBtn.transform.localPosition.x < 0)
        {
            switchBtn.GetComponent<RawImage>().color = new Color32(3, 149, 129, 255);
            background.GetComponent<RawImage>().color = new Color32(125, 199, 194, 255);
        }
        else
        {
            switchBtn.GetComponent<RawImage>().color = new Color32(236, 236, 236, 255);

            background.GetComponent<RawImage>().color = new Color32(185, 185, 185, 185);
        }
        
    }

}
