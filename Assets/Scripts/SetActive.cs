using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActive : MonoBehaviour
{
    public void Active(Button Btn)
    {
        Btn.gameObject.SetActive(true);
        
    }

    public void Disable(Button Btn)
    {
        Btn.gameObject.SetActive(false);
       
    }
}
