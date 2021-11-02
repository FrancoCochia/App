using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GoPDF : MonoBehaviour
{
    string ID;
    string pathURL;
    string Bucket;

    public static string FirebaseLoadPath;

    Firebase.Storage.FirebaseStorage storage;

    GameObject P_Controller;

    // Obtengo el Bucket nuevamente:
    void Start()
    {
        P_Controller = GameObject.Find("PanelController");

        Bucket = P_Controller.GetComponent<Bucket>().Bucket_path;

        storage = Firebase.Storage.FirebaseStorage.DefaultInstance;
    }

    // Cargo el bucket:
    public void CargarURL(string URL)
    {
        Bucket = URL;

    }

    // ID para el modelo seleccionado: -> Panel_View
    public void CargarID(string nID)
    {
        ID = nID;

        // Cargo URL:
        GetPDF();
    }

    // Invocar:
    public void GoURL()
    {
        Invoke("Go", 1.0f);
    }

    // Abrir URL en Browser:
    public void Go()
    {
        Application.OpenURL(FirebaseLoadPath);
    }

    // Obtener referencia HTTP desde Firebase:
    public void GetPDF()
    {
        pathURL = Bucket + "/Model" + ID + "/ext/" + "Actividad" + ID + ".pdf";

        Firebase.Storage.StorageReference reference = storage.GetReferenceFromUrl(pathURL);

        reference.GetDownloadUrlAsync().ContinueWith((Task<Uri> task) =>
        {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                FirebaseLoadPath = task.Result.ToString();

            }
        });

    }
}
