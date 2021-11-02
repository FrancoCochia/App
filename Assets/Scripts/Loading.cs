using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public GameObject AR_Camera;
    public GameObject Panel_Btn;
    public GameObject Anim_Wait;

    public Image FadeImg; 

    void Start()
    {
        FadeImg.canvasRenderer.SetAlpha(1f);
        StartCoroutine(ShowBtn());
    }

    IEnumerator ShowBtn()
    {
        yield return new WaitForSeconds(5);

        // Animación:
        Anim_Wait.SetActive(false);
        // Despliego camara:
        AR_Camera.SetActive(true);
        // Animación:
        FadeOut();

        yield return new WaitForSeconds(1.5f);

        // Despliego panel de botones:
        Panel_Btn.SetActive(true);

    }

    public void FadeOut()
    {
        FadeImg.CrossFadeAlpha(0, 1.5f, false);
    }
}
