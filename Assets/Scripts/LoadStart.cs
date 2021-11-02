using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadStart : MonoBehaviour
{
    public Image Black_Back;

    IEnumerator Start()
    {
        Black_Back.canvasRenderer.SetAlpha(1f);
        yield return new WaitForSeconds(2);
        FadeOut();

    }


    public void FadeOut()
    {
        Black_Back.CrossFadeAlpha(0, 0.5f, false);
    }


}

