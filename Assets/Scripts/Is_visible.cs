using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_visible : MonoBehaviour
{
    public GameObject thisgameobj;

    public void Mostrar()
    {
        thisgameobj.SetActive(true);
    }

    public void Ocultar()
    {
        thisgameobj.SetActive(false);
    }
}
