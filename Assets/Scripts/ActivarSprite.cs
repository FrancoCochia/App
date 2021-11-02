using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarSprite : MonoBehaviour
{
    public GameObject m1_sp1;
    public GameObject m1_sp2;
    public GameObject m1_sp3;

    public GameObject m2_sp1;
    public GameObject m2_sp2;
    public GameObject m2_sp3;

    public GameObject m3_sp1;
    public GameObject m3_sp2;
    public GameObject m3_sp3;

    public GameObject m4_sp1;
    public GameObject m4_sp2;
    public GameObject m4_sp3;

    public GameObject m5_sp1;
    public GameObject m5_sp2;
    public GameObject m5_sp3;

    public void IsPressed()
    {
        // Activar Sprites:

        m1_sp1.GetComponent<LoadSprite>().Change_Capa();
        m1_sp2.GetComponent<LoadSprite>().Change_Capa();
        m1_sp3.GetComponent<LoadSprite>().Change_Capa();

        m2_sp1.GetComponent<LoadSprite>().Change_Capa();
        m2_sp2.GetComponent<LoadSprite>().Change_Capa();
        m2_sp3.GetComponent<LoadSprite>().Change_Capa();

        m3_sp1.GetComponent<LoadSprite>().Change_Capa();
        m3_sp2.GetComponent<LoadSprite>().Change_Capa();
        m3_sp3.GetComponent<LoadSprite>().Change_Capa();

        m4_sp1.GetComponent<LoadSprite>().Change_Capa();
        m4_sp2.GetComponent<LoadSprite>().Change_Capa();
        m4_sp3.GetComponent<LoadSprite>().Change_Capa();

        m5_sp1.GetComponent<LoadSprite>().Change_Capa();
        m5_sp2.GetComponent<LoadSprite>().Change_Capa();
        m5_sp3.GetComponent<LoadSprite>().Change_Capa();
    }

}
