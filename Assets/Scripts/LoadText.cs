using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoadText : MonoBehaviour
{
    public string ID;
    public string numb_text;

    string folder;
    string config_path;

    private bool display_img = false;
    public TextMeshPro TextLine;

    
    void Start()
    {
        ImportarTexto();
    }

    // Si no hay texto, se oculta el sprite:
    void Update()
    {
        if(TextLine.text==null || TextLine.text == "")
        {
            gameObject.SetActive(false);
        }
    }

    public void ImportarTexto()
    {
        folder = (System.Int16.Parse(ID)).ToString();
        config_path = Application.persistentDataPath + "/resources/" + folder + "/text/" + "text" + numb_text + ".txt";

        if (System.IO.File.Exists(config_path))
        {
            // Cargo el texto en memoria;
            StreamReader inp_stm = new StreamReader(config_path);
            // Lo cargo en la escena:
            TextLine.text = inp_stm.ReadToEnd();
        }
            
        gameObject.SetActive(false);

    }

    // Despliego segun Panel_Capas:
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
