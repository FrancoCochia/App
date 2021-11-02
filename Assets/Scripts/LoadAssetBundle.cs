using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Experimental.Networking;
using UnityEngine.Networking;
using Vuforia;
using UnityEditor;
using System;

// Carga de los modelos en memoria al iniciar la escena "main":

public class LoadAssetBundle : MonoBehaviour
{
    public string thisID;
    public Material alterMaterial;

    static string pathLOCAL;
    string ScaleFotoString;
    string assetbundleNAME;
    string folder;
    GameObject empty;
    GameObject obj;
    GameObject myNewObj;

    Material thisMaterial;

    bool cambio = false;

    void Start()
    {
        string name = "Model" + thisID;
        empty = GameObject.Find(name);
        
    }

    public IEnumerator CargarAssetBundleDesdeDisco(string ID)
    {
       
        // Referencia:
        assetbundleNAME = "model" + ID + "." + ID;
        folder = ID;

        LoadScale(folder);

        //Creo la dirección local donde se guarda el AssetBundle:
        pathLOCAL = (Application.persistentDataPath + "/resources/" + folder + "/assetbundle/" + assetbundleNAME);

        //Cargo el AssetBundle desde el disco:
        var bundleLoadRequest = AssetBundle.LoadFromFileAsync(pathLOCAL);
        yield return bundleLoadRequest;

        var myLoadedAssetBundle = bundleLoadRequest.assetBundle;

        //Si no existe error en la carga:
        if (myLoadedAssetBundle != null)
        {
            var obj = myLoadedAssetBundle.LoadAssetAsync<GameObject>("modelo" + ID);
            yield return obj;

            if (obj == null)
            {
                obj = myLoadedAssetBundle.LoadAssetAsync<GameObject>("model" + ID);
                yield return obj;
            }

            GameObject prefab = obj.asset as GameObject;

            //Instanciar como hijo:
            myNewObj = Instantiate(prefab, empty.transform) as GameObject;

            myNewObj.transform.parent = empty.transform;
            myNewObj.transform.localPosition = new Vector3(0,0,0);

            //Añadir boxCollider:
            var boxCol = myNewObj.GetComponent<MeshCollider>();
            if (boxCol == null)
            {
                boxCol = myNewObj.AddComponent<MeshCollider>();
            }

            Mesh mesh = myNewObj.GetComponent<MeshFilter>().sharedMesh;

            //Guardar Material:
            thisMaterial = myNewObj.GetComponent<Renderer>().material;

            myLoadedAssetBundle.Unload(false);

            myNewObj.SetActive(false);

        }
        else
        {
            //Debug.Log("error to load");
        }

    }

    // Cargar nuevo material:
    public void SetNewMaterial()
    {
        if(alterMaterial != null && alterMaterial.mainTexture != null)
        {
            myNewObj.GetComponent<MeshRenderer>().material = alterMaterial;
        }
        
    }

    // Cargar material original:
    public void SetOldMaterial()
    {
        myNewObj.GetComponent<MeshRenderer>().material = thisMaterial;
    }

    // Cambio de material:
    public void ChangeMaterial()
    { 
        if (cambio == false)
        {
            SetNewMaterial();
        }
        else
        {
            SetOldMaterial();
        }

        cambio = !cambio;
    }

    public void Cargar()
    {
        StartCoroutine(CargarAssetBundleDesdeDisco(thisID));
    }

    public void Mostrar()
    {
        myNewObj.SetActive(true);
    }

    public void Ocultar()
    {
        myNewObj.SetActive(false);
    }

    public void LoadScale(string folder)
    {
        // Armo el path:
        pathLOCAL = Application.persistentDataPath + "/resources/" + folder + "/assetbundle/" + "data.txt";

        System.IO.StreamReader inp_stm = new StreamReader(pathLOCAL);

        string[] words;
        
        //Leo la primer linea:
        var line = inp_stm.ReadLine();

        while (line != null)
        {
            //Separo por ":"
            words = line.Split((':'));
            if (words[0].Contains("Escala") || words[0].Contains("escala"))
            {
                //Importo escala:
                if (words[2] == null)
                {
                   ScaleFotoString = words[1];
                }
                else
                {
                    ScaleFotoString = words[2];
                }

                if (ScaleFotoString.EndsWith("."))
                {
                    ScaleFotoString = ScaleFotoString.Remove(ScaleFotoString.Length - 1);
                }

            }

            line = inp_stm.ReadLine();

        }
    }

    // Obtener escala:
    public float GetScale()
    {
        return float.Parse(ScaleFotoString);
    }

}
