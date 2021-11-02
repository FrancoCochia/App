using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Experimental.Networking;
using UnityEngine.Networking;
using UnityEngine.UIElements;
using System.Threading.Tasks;
using System;
using Lean.Gui;

public class DownloadModels : MonoBehaviour
{
    public Text Info;
    public GameObject Modal;
    public GameObject Modal_noti;
    public GameObject OverrideController;
    public InputField Box;
    public GameObject PanelController;
    public GameObject Down_Anim;

    Firebase.Storage.FirebaseStorage storage;

    string Bucket;
    string pathURL;
    string local_url;
    string nameTEXT;

    bool downloaded = false;

    void Start()
    { 
        storage = Firebase.Storage.FirebaseStorage.DefaultInstance;
    }

    void Update()
    {
        if (downloaded)
        {
            Down_Anim.SetActive(false);
            Notificacion();
            downloaded = false;
        }
    }

    public void IsDownload(string ID)
    {
        // Bucket original de Firebase:
        Bucket = PanelController.GetComponent<Bucket>().Bucket_path;

        string config_path = Application.persistentDataPath + "/resources/" + ID + "/assetbundle/" + "model" + ID + "." + ID;

        // Chequeo si existe el modelo en el dispositivo:
        if (System.IO.File.Exists(config_path))
        {
            Modal.GetComponent<LeanWindow>().TurnOn();

            // Si existe paso el ID a SetOverNumber:
            OverrideController.GetComponent<SetOverNumber>().SetID(ID);

        }
        else
        {
            // Si no estaba, lo descargo y despliego la animación:
            DownloadPACK(ID);
            Down_Anim.SetActive(true);
        }

    }
    
    public void DownloadPACK(string ID)
    {
        //Descarga AssetBundle:
        GetAssetBundle(ID);

        //Descarga Data Asociada:
        GetData(ID);

        //Descarga Textos:
        for (int i = 1; i < 4; i++)
        {
            GetText(ID, i.ToString());
        }

        //Descarga Imagenes:
        GetTexture(ID, "1");
        GetTexture(ID, "2");
        GetTexture(ID, "3");
        GetTexture(ID, "4");
        GetTexture(ID, "5");

        //Descarga Enlaces:
        for (int i = 1; i < 4; i++)
        {
            GetEnl(ID, i.ToString());
        }

        //Descarga de textura Alt:
        GetTextureAlt("1");
        GetTextureAlt("2");
        GetTextureAlt("3");
        GetTextureAlt("4");
        GetTextureAlt("5");

    }

    public void GetAssetBundle(string ID)
    {
        // Armo el path:
        pathURL = Bucket + "/Model" + ID + "/" + "model" + ID + "." + ID;

        Firebase.Storage.StorageReference reference_assetbundle = storage.GetReferenceFromUrl(pathURL);

        // Create local filesystem URL
        local_url = Application.persistentDataPath + "/resources/" + ID + "/assetbundle/" + "model" + ID + "." + ID;

        // Download to the local filesystem
        reference_assetbundle.GetFileAsync(local_url).ContinueWith(task => {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                downloaded = true;
            }
        });    

    }

    public void GetData(string ID)
    {
        // Armo el path:
        pathURL = Bucket + "/Model" + ID + "/" + "data.txt";

        Firebase.Storage.StorageReference reference_assetbundle = storage.GetReferenceFromUrl(pathURL);

        // Create local filesystem URL
        local_url = Application.persistentDataPath + "/resources/" + ID + "/assetbundle/" + "data.txt";

        // Download to the local filesystem
        reference_assetbundle.GetFileAsync(local_url).ContinueWith(task => {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                
            }
        });

    }

    public void GetText(string ID, string numberText)
    {
        // Armo el path:
        pathURL = Bucket + "/Model" + ID + "/" + "text/" + "text" + numberText + ".txt";

        Firebase.Storage.StorageReference reference_assetbundle = storage.GetReferenceFromUrl(pathURL);

        // Create local filesystem URL
        local_url = Application.persistentDataPath + "/resources/" + ID + "/text/" + "text" + numberText + ".txt";

        // Download to the local filesystem
        reference_assetbundle.GetFileAsync(local_url).ContinueWith(task => {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                
            }
        });

    }

    public void GetTexture(string ID, string numberImg)
    {
        // Armo el path:
        pathURL = Bucket + "/Model" + ID + "/" + "img/" + "img" + numberImg + ".jpg";

        Firebase.Storage.StorageReference reference_assetbundle = storage.GetReferenceFromUrl(pathURL);

        // Create local filesystem URL
        local_url = Application.persistentDataPath + "/resources/" + ID + "/img/" + "img" + numberImg + ".jpg";

        // Download to the local filesystem
        reference_assetbundle.GetFileAsync(local_url).ContinueWith(task => {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                
            }
        });

        //---------------------------------------------------------------------------------------------------------------

        // Armo el path:
        pathURL = Bucket + "/Model" + ID + "/" + "img/" + "img" + numberImg + ".jpeg";

        reference_assetbundle = storage.GetReferenceFromUrl(pathURL);

        // Create local filesystem URL
        local_url = Application.persistentDataPath + "/resources/" + ID + "/img/" + "img" + numberImg + ".jpg";

        // Download to the local filesystem
        reference_assetbundle.GetFileAsync(local_url).ContinueWith(task => {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                
            }
        });


    }

    public void GetTextureAlt(string ID)
    {
        // Armo el path:
        pathURL = Bucket + "/Model" + ID + "/" + "texture/" + "m" + ID + "Alt" + ".jpg";

        Firebase.Storage.StorageReference reference_assetbundle = storage.GetReferenceFromUrl(pathURL);

        // Create local filesystem URL
        local_url = Application.persistentDataPath + "/resources/" + ID + "/" + "texture/" + "m" + ID + "Alt" + ".jpg";

        // Download to the local filesystem
        reference_assetbundle.GetFileAsync(local_url).ContinueWith(task => {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                
            }
        });

        //---------------------------------------------------------------------------------------------------------------

        // Armo el path:
        pathURL = Bucket + "/Model" + ID + "/" + "texture/" + "m" + ID + "Alt" + ".jepg";

        reference_assetbundle = storage.GetReferenceFromUrl(pathURL);

        // Create local filesystem URL
        local_url = Application.persistentDataPath + "/resources/" + ID + "/" + "texture/" + "m" + ID + "Alt" + ".jpg";

        // Download to the local filesystem
        reference_assetbundle.GetFileAsync(local_url).ContinueWith(task => {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                
            }
        });

    }

    public void GetEnl(string ID, string numberText)
    {
        // Armo el path:
        pathURL = Bucket + "/Model" + ID + "/" + "enl/" + "enl" + numberText + ".txt";

        Firebase.Storage.StorageReference reference_assetbundle = storage.GetReferenceFromUrl(pathURL);

        // Create local filesystem URL
        local_url = Application.persistentDataPath + "/resources/" + ID + "/enl/" + "enl" + numberText + ".txt";

        // Download to the local filesystem
        reference_assetbundle.GetFileAsync(local_url).ContinueWith(task => {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                //Debug.Log("File downloaded.");
            }
        });

    }

    private void Notificacion()
    {
        // Despliego la notificación de que ya esta descargado:
        Modal_noti.GetComponent<LeanPulse>().Pulse();
    }

}


