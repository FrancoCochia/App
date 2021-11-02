using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadSprite : MonoBehaviour
{
    public string ID;
    public string img_num;

    private SpriteRenderer sprRend;

    private bool display_img = false;

    string img_name;
    string folder;
    string pathLOCAL;
    string config_path;

    Texture2D myTexture;

    void Start()
    {
        StartCoroutine(cargarImagen());
    }

    IEnumerator cargarImagen()
    {
        // Armo el ID:
        img_name = "img" + img_num + ".jpg";
        folder = (System.Int16.Parse(ID)).ToString();

        // Armo el path:
        pathLOCAL = new System.Uri(System.IO.Path.Combine(Application.persistentDataPath, "resources", folder, "img", img_name)).AbsoluteUri;
        config_path = Application.persistentDataPath + "/resources/" + folder + "/img/" + img_name;

        if (System.IO.File.Exists(config_path))
        {
            
            // Cargo la imagen en memoria:
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(pathLOCAL);
            yield return www.SendWebRequest();

            myTexture = DownloadHandlerTexture.GetContent(www);

            // Cargo la imagen en el Sprite:
            gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f), 100.0f);

            gameObject.GetComponent<SpriteRenderer>().size = new Vector2(5f, 5f);
        }

        gameObject.SetActive(false);

    }

    // Despliega los Sprites segun el panel de capas:  
    public void Change_Capa()
    {
        display_img = !display_img;

        if (display_img)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
