using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Experimental.Networking;
using UnityEngine.Networking;
using UnityEngine.UIElements;
using Lean.Gui;

public class SetOverNumber : MonoBehaviour
{
    string ID;
    string Bucket ;
    public InputField Box;

    Firebase.Storage.FirebaseStorage storage;
    public GameObject PanelController;
    public GameObject Modal_noti;
    GameObject P_Controller;

    public GameObject Down_Anim;

    string pathURL;
    string local_url;
    string nameTEXT;
    bool downloaded = false;

    void Start()
    {
        P_Controller = GameObject.Find("PanelController");

        storage = Firebase.Storage.FirebaseStorage.DefaultInstance;
    }

    // Update is called once per frame
    void Update()
    {
        // Si se ha descargado:
        if (downloaded)
        {
            Down_Anim.SetActive(false);
            Notificacion();
            downloaded = false;
        }
    }

    public void SetID(string newID)
    {
        ID = newID;
    }

    public void DownloadAgain()
    {
        // Animación:
        Down_Anim.SetActive(true);

        // Obtenego el bucket:
        Bucket = P_Controller.GetComponent<Bucket>().Bucket_path;

        // Creo los directorios si no estaban:
        CreateDirectory(ID);

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
        for (int i = 1; i < 4; i++)
        {
            GetTexture(ID, i.ToString());
        }

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

        // Armo el path:
        pathURL = Bucket + "/Model" + ID + "/" + "img/" + "img" + numberImg + ".jpeg";

        reference_assetbundle = storage.GetReferenceFromUrl(pathURL);

        // Create local filesystem URL
        local_url = Application.persistentDataPath + "/resources/" + ID + "/img/" + "img" + numberImg + ".jpg";

        // Download to the local filesystem
        reference_assetbundle.GetFileAsync(local_url).ContinueWith(task => {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                //Debug.Log("File downloaded.");
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

        // Armo el path:
        pathURL = Bucket + "/Model" + ID + "/" + "texture/" + "m" + ID + "Alt" + ".jepg";

        reference_assetbundle = storage.GetReferenceFromUrl(pathURL);

        // Create local filesystem URL
        local_url = Application.persistentDataPath + "/resources/" + ID + "/" + "texture/" + "m" + ID + "Alt" + ".jpg";

        // Download to the local filesystem
        reference_assetbundle.GetFileAsync(local_url).ContinueWith(task => {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                //Debug.Log("File downloaded.");
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
                
            }
        });


    }

    private void CreateDirectory(string ID)
    {
        // Compruebo de que exista la carpeta:
        if (!Directory.Exists(Application.persistentDataPath + "/resources/" + ID + "/text/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/resources/" + ID + "/text/");
        }

        // Compruebo de que exista la carpeta:
        if (!Directory.Exists(Application.persistentDataPath + "/resources/" + ID + "/img/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/resources/" + ID + "/img/");
        }

        // Dirección de la carpeta local donde se guardarán los AssetBundles:
        if (!Directory.Exists(Application.persistentDataPath + "/resources/" + ID + "/assetbundle/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/resources/" + ID + "/assetbundle/");
        }

    }

    private void Notificacion()
    {
        Modal_noti.GetComponent<LeanPulse>().Pulse();
    }

}
