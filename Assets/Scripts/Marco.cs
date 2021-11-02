using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marco : MonoBehaviour
{
    bool marca = false;

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

    void Update()
    {
        if (marca)
        {
            Load();
        }
        else
        {
            NoLoad();
        }

    }

    // Activo los marcos:
    public void Load()
    {
        m1_sp1.SetActive(true);
        m1_sp2.SetActive(true);
        m1_sp3.SetActive(true);
        
        m2_sp1.SetActive(true);
        m2_sp2.SetActive(true);
        m2_sp3.SetActive(true);

        m3_sp1.SetActive(true);
        m3_sp2.SetActive(true);
        m3_sp3.SetActive(true);

        m4_sp1.SetActive(true);
        m4_sp2.SetActive(true);
        m4_sp3.SetActive(true);

        m5_sp1.SetActive(true);
        m5_sp2.SetActive(true);
        m5_sp3.SetActive(true);
        
    }

    // Desactivo los marcos:
    public void NoLoad()
    {
        m1_sp1.SetActive(false);
        m1_sp2.SetActive(false);
        m1_sp3.SetActive(false);
        
        m2_sp1.SetActive(false);
        m2_sp2.SetActive(false);
        m2_sp3.SetActive(false);

        m3_sp1.SetActive(false);
        m3_sp2.SetActive(false);
        m3_sp3.SetActive(false);

        m4_sp1.SetActive(false);
        m4_sp2.SetActive(false);
        m4_sp3.SetActive(false);

        m5_sp1.SetActive(false);
        m5_sp2.SetActive(false);
        m5_sp3.SetActive(false);
        
    }

    public void Change()
    {
        marca = !marca;
    }
}
