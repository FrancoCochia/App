using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActivarText : MonoBehaviour
{
    public GameObject m1_text1;
    public GameObject m2_text1;
    public GameObject m3_text1;
    public GameObject m4_text1;
    public GameObject m5_text1;

    public GameObject m1_text2;
    public GameObject m2_text2;
    public GameObject m3_text2;
    public GameObject m4_text2;
    public GameObject m5_text2;

    public GameObject m1_text3;
    public GameObject m2_text3;
    public GameObject m3_text3;
    public GameObject m4_text3;
    public GameObject m5_text3;

    public void IsPressed()
    {
        // Activar Textos:

        m1_text1.GetComponent<LoadText>().Change_Capa();
        m2_text1.GetComponent<LoadText>().Change_Capa();
        m3_text1.GetComponent<LoadText>().Change_Capa();
        m4_text1.GetComponent<LoadText>().Change_Capa();
        m5_text1.GetComponent<LoadText>().Change_Capa();

        m1_text2.GetComponent<LoadText>().Change_Capa();
        m2_text2.GetComponent<LoadText>().Change_Capa();
        m3_text2.GetComponent<LoadText>().Change_Capa();
        m4_text2.GetComponent<LoadText>().Change_Capa();
        m5_text2.GetComponent<LoadText>().Change_Capa();

        m1_text3.GetComponent<LoadText>().Change_Capa();
        m2_text3.GetComponent<LoadText>().Change_Capa();
        m3_text3.GetComponent<LoadText>().Change_Capa();
        m4_text3.GetComponent<LoadText>().Change_Capa();
        m5_text3.GetComponent<LoadText>().Change_Capa();

    }

}
