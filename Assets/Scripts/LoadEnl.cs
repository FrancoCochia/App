using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoadEnl : MonoBehaviour
{
    public string ID;
    public string num_enl;

    private bool display_img = false;
    public TextMeshPro TextLine;

    string folder;
    string config_path;

    void Start()
    {
        ImportarEnlace();
    }

    void Update()
    {
        // Cargar URL:

        if (gameObject.GetComponent<TextMeshPro>().text == "" || gameObject.GetComponent<TextMeshPro>().text == null)
        {
            gameObject.SetActive(false);
        }
    }

    public void ImportarEnlace()
    {
        folder = (System.Int16.Parse(ID)).ToString();
        config_path = Application.persistentDataPath + "/resources/" + folder + "/enl/" + "enl" + num_enl + ".txt";

        if (System.IO.File.Exists(config_path))
        {
            StreamReader inp_stm = new StreamReader(config_path);
            TextLine.text = inp_stm.ReadToEnd();
        }       

        gameObject.SetActive(false);
    }

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

    public string ReturnLink()
    {
        return TextLine.text;
    }
}
