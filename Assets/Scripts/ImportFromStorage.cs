using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;
using DG.Tweening;

public class ImportFromStorage : MonoBehaviour
{
    public static string ID;

    public RawImage thisimage;

    public Text thistext;
    public Text thistitle;
    public Text thisubic;

    public GameObject actividad;
    public GameObject Panel;

    string folder;
    string pathLOCAL;
    string pathimg;


    public void LoadView(string ID)
    {
        // Paso ID de modelo:
        actividad.GetComponent<GoPDF>().CargarID(ID);
        StartCoroutine(ImportImgText(ID));

    }

    // Importo imagen y datos desde almacenamiento en Panel_View:
     IEnumerator ImportImgText(string ID)
     {
        folder = ID;

        pathLOCAL = Application.persistentDataPath + "/resources/" + folder + "/assetbundle/" + "data.txt";

        pathimg = new System.Uri(System.IO.Path.Combine(Application.persistentDataPath, "resources", folder, "img", "img1.jpg")).AbsoluteUri;

        UnityWebRequest www = UnityWebRequestTexture.GetTexture(pathimg);
        yield return www.SendWebRequest();

        Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture as Texture2D;

        thisimage.texture = myTexture;
       
        System.IO.StreamReader inp_stm = new StreamReader(pathLOCAL);

        string[] words;
            //Leo la primer linea:
            var line = inp_stm.ReadLine();

            while (line != null)
            {
                //Separo por ":"
                words = line.Split((':'));
                 

            if (words[0].Contains("Nombre") || words[0].Contains("nombre"))
                {
                    //Importo el nombre del modelo:
                    thistitle.text = words[1];
                    
                }

                if (words[0].Contains("Ubicación") || words[0].Contains("ubicación"))
                {
                    //Importo la ubicación del modelo:
                    thisubic.text = words[1];
                }

                if (words[0].Contains("Descripción") || words[0].Contains("descripción"))
                {
                    //Importo la descripción del modelo:
                    thistext.text = words[1];
                    
                }

                //Leo la siguiente linea:
                line = inp_stm.ReadLine();
            }

        inp_stm.Close();

        if(thistitle.text != "" )
        {
            Panel.transform.DOLocalMoveX(Vector3.zero.x, 0.4f);
        }

    }

}

            

            
           
        
    

        
