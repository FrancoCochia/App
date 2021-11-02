using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Decode : MonoBehaviour
{
    public void DownloadPass()
    {
        Firebase.Storage.FirebaseStorage storage = Firebase.Storage.FirebaseStorage.DefaultInstance;

        string pathLOCAL = Application.persistentDataPath + "/pass.txt";

        string path = "gs://ii-2020-de4e9.appspot.com/pass.txt";

        Firebase.Storage.StorageReference reference_assetbundle = storage.GetReferenceFromUrl(path);

        // Download to the local filesystem
        reference_assetbundle.GetFileAsync(pathLOCAL).ContinueWith(task => {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                Debug.Log("File downloaded.");
            }
        });
    }
}
