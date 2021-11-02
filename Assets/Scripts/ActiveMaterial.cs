using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMaterial : MonoBehaviour
{
    public GameObject Model1;
    public GameObject Model2;
    public GameObject Model3;
    public GameObject Model4;
    public GameObject Model5;

    bool cambio = false;

    public void ActivarMaterial()
    {
        ActivarNuevoMaterial();
    }

    [System.Obsolete]
    public void ActivarNuevoMaterial()
    {
        // Cambio de materiales:

        if (Model1.transform.GetChild(0).gameObject.active)
        {
            Model1.GetComponent<LoadAssetBundle>().ChangeMaterial();
        }

        if (Model2.transform.GetChild(0).gameObject.active)
        {
            Model2.GetComponent<LoadAssetBundle>().ChangeMaterial();
        }

        if (Model3.transform.GetChild(0).gameObject.active)
        {
            Model3.GetComponent<LoadAssetBundle>().ChangeMaterial();
        }

        if (Model4.transform.GetChild(0).gameObject.active)
        {
            Model4.GetComponent<LoadAssetBundle>().ChangeMaterial();
        }

        if (Model5.transform.GetChild(0).gameObject.active)
        {
            Model5.GetComponent<LoadAssetBundle>().ChangeMaterial();
        }
    }

}
