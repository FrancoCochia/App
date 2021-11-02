using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarEnl : MonoBehaviour
{
    public GameObject m1_enl1;
    public GameObject m2_enl1;
    public GameObject m3_enl1;
    public GameObject m4_enl1;
    public GameObject m5_enl1;

    public GameObject m1_enl2;
    public GameObject m2_enl2;
    public GameObject m3_enl2;
    public GameObject m4_enl2;
    public GameObject m5_enl2;

    public GameObject m1_enl3;
    public GameObject m2_enl3;
    public GameObject m3_enl3;
    public GameObject m4_enl3;
    public GameObject m5_enl3;

    public void IsPressed()
    {
        // Activar Enlaces:

        m1_enl1.GetComponent<LoadEnl>().Change_Capa();
        m2_enl1.GetComponent<LoadEnl>().Change_Capa();
        m3_enl1.GetComponent<LoadEnl>().Change_Capa();
        m4_enl1.GetComponent<LoadEnl>().Change_Capa();
        m5_enl1.GetComponent<LoadEnl>().Change_Capa();

        m1_enl2.GetComponent<LoadEnl>().Change_Capa();
        m2_enl2.GetComponent<LoadEnl>().Change_Capa();
        m3_enl2.GetComponent<LoadEnl>().Change_Capa();
        m4_enl2.GetComponent<LoadEnl>().Change_Capa();
        m5_enl2.GetComponent<LoadEnl>().Change_Capa();

        m1_enl3.GetComponent<LoadEnl>().Change_Capa();
        m2_enl3.GetComponent<LoadEnl>().Change_Capa();
        m3_enl3.GetComponent<LoadEnl>().Change_Capa();
        m4_enl3.GetComponent<LoadEnl>().Change_Capa();
        m5_enl3.GetComponent<LoadEnl>().Change_Capa();

    }
}
