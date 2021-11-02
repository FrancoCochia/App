using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layers : MonoBehaviour
{
    public GameObject Switch_Img;
    public GameObject switchBtn_img;
    public GameObject Switch_Text;
    public GameObject switchBtn_text;
    public GameObject Switch_Enl;
    public GameObject switchBtn_enl;

    bool img = false;
    bool text = false;
    bool link = false;
    bool img_r = false;
    bool text_r = false;
    bool link_r = false;

    public void Aceptar()
    {
        img_r = img;
        text_r = text;
        link_r = link;
    }

    public void Cancelar()
    {
        if(img_r != img)
        {
            Switch_Img.GetComponent<SwitchHandler>().OnSwitchButtonClicked();
            switchBtn_img.GetComponent<ActivarSprite>().IsPressed();
            switchBtn_img.GetComponent<Marco>().Change();
        }

        if (text_r != text)
        {
            Switch_Text.GetComponent<SwitchHandler>().OnSwitchButtonClicked();
            switchBtn_text.GetComponent<ActivarText>().IsPressed();
        }

        if (link_r != link)
        {
            Switch_Enl.GetComponent<SwitchHandler>().OnSwitchButtonClicked();
            switchBtn_enl.GetComponent<ActivarEnl>().IsPressed();
        }

        img = img_r;
        text = text_r;
        link = link_r;

        Debug.Log("img:" + img_r);
        Debug.Log("text:" + text_r);
        Debug.Log("link:" + link_r);
    }

    public void SetImg()
    {
        img = !img;
    }

    public void SetText()
    {
        text = !text;
    }
    public void SetLink()
    {
        link = !link;
    }
}
