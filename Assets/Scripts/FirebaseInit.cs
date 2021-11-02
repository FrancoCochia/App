using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Storage;
using System;
using System.IO;

public class FirebaseInit : MonoBehaviour
{
    public string Bucket ;
    GameObject PanelController;
    void Start()
    {
        // Chequeo disponibilidad con Firebase:

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            }
        });

        PanelController = GameObject.Find("PanelController");

        

    }

    

    public void DownloadNames()
    {
        Bucket = PanelController.GetComponent<Bucket>().Bucket_path;

        Firebase.Storage.FirebaseStorage storage =  Firebase.Storage.FirebaseStorage.DefaultInstance;

        // Descargo previamente los nombres de los modelos:

        for (int i = 1; i < 6; i++)
        {
            CreateDirectory(i.ToString());

            string path = Bucket + "/Model" + i.ToString() + "/" + "data.txt";

            Firebase.Storage.StorageReference reference_assetbundle = storage.GetReferenceFromUrl(path);

            // Create local filesystem URL
            string local_url = Application.persistentDataPath + "/resources/" + i.ToString() + "/assetbundle/" + "data" + ".txt";

            // Download to the local filesystem
            reference_assetbundle.GetFileAsync(local_url).ContinueWith(task => {
                if (!task.IsFaulted && !task.IsCanceled)
                {
                    //Debug.Log("File downloaded.");
                }
            });

            
        }
    }

    private void CreateDirectory(string ID)
    {
        // Compruebo de que existan la carpetas:

        if (!Directory.Exists(Application.persistentDataPath + "/resources/" + ID + "/text/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/resources/" + ID + "/text/");
        }

        if (!Directory.Exists(Application.persistentDataPath + "/resources/" + ID + "/img/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/resources/" + ID + "/img/");
        }

        if (!Directory.Exists(Application.persistentDataPath + "/resources/" + ID + "/assetbundle/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/resources/" + ID + "/assetbundle/");
        }

        if (!Directory.Exists(Application.persistentDataPath + "/resources/" + ID + "/enl/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/resources/" + ID + "/enl/");
        }

        if (!Directory.Exists(Application.persistentDataPath + "/resources/" + ID + "/texture/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/resources/" + ID + "/texture/");
        }
    }

}
