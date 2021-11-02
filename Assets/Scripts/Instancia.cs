using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Instancia : MonoBehaviour
{
    public GameObject Modelo1;
    public GameObject Modelo2;
    public GameObject Modelo3;
    public GameObject Modelo4;
    public GameObject Modelo5;

    string path1;
    string path2;
    string path3;
    string path4;
    string path5;

    void Start()
    {
        path1 = (Application.persistentDataPath + "/resources/" + "1" + "/assetbundle/" + "model1.1");
        path2 = (Application.persistentDataPath + "/resources/" + "2" + "/assetbundle/" + "model2.2");
        path3 = (Application.persistentDataPath + "/resources/" + "3" + "/assetbundle/" + "model3.3");
        path4 = (Application.persistentDataPath + "/resources/" + "4" + "/assetbundle/" + "model4.4");
        path5 = (Application.persistentDataPath + "/resources/" + "5" + "/assetbundle/" + "model5.5");

        StartCoroutine(IniciarModelos());
    }

    // Iniciar modelos secuencialmente: -> main
    IEnumerator IniciarModelos()
    {
        if (System.IO.File.Exists(path1))
        {
            yield return StartCoroutine((Modelo1.GetComponent<LoadAssetBundle>().CargarAssetBundleDesdeDisco("1")));
        }

        if (System.IO.File.Exists(path2))
        {
            yield return StartCoroutine((Modelo2.GetComponent<LoadAssetBundle>().CargarAssetBundleDesdeDisco("2")));
        }

        if (System.IO.File.Exists(path3))
        {
            yield return StartCoroutine((Modelo3.GetComponent<LoadAssetBundle>().CargarAssetBundleDesdeDisco("3")));
        }

        if (System.IO.File.Exists(path4))
        {
            yield return StartCoroutine((Modelo4.GetComponent<LoadAssetBundle>().CargarAssetBundleDesdeDisco("4")));
        }

        if (System.IO.File.Exists(path5))
        {
            yield return StartCoroutine((Modelo5.GetComponent<LoadAssetBundle>().CargarAssetBundleDesdeDisco("5")));
        }

    }





}
