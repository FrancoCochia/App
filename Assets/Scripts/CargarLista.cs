using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class CargarLista : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;

    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    public Button btn5;

    string[] words;
    string pathLOCAL;
    string pathAssetBundle;
    string folder;
    string title;
    StreamReader inp_stm;

    public void LoadNames()
    {
        // Carga de nombres en la lista de almacenados y repositorio:

        for (int i = 1; i < 6; i++)
        {
            folder = i.ToString();

            // Dirección del archivo data.txt:
            pathLOCAL = Application.persistentDataPath + "/resources/" + folder + "/assetbundle/" + "data.txt";

            pathAssetBundle = Application.persistentDataPath + "/resources/" + folder + "/assetbundle/" + "model" + folder + "." + folder;

            if (System.IO.File.Exists(pathLOCAL) && System.IO.File.Exists(pathAssetBundle))
            {
                inp_stm = new StreamReader(pathLOCAL);

                //Leo la primer linea:
                var line = inp_stm.ReadLine();

                while (line != null)
                {
                    //Separo por ":"
                    words = line.Split((':'));

                    if (words[0].Contains("Nombre") || words[0].Contains("nombre"))
                    {
                        //Importo el nombre del modelo:
                        title = words[1];

                    }

                    //Leo la siguiente linea:
                    line = inp_stm.ReadLine();
                }

                inp_stm.Close();

                if (i == 1)
                {
                    text1.text = title;
                    btn1.gameObject.SetActive(true);
                }

                if (i == 2)
                {
                    text2.text = title;
                    btn2.gameObject.SetActive(true);
                }

                if (i == 3)
                {
                    text3.text = title;
                    btn3.gameObject.SetActive(true);
                }

                if (i == 4)
                {
                    text4.text = title;
                    btn4.gameObject.SetActive(true);
                }

                if (i == 5)
                {
                    text5.text = title;
                    btn5.gameObject.SetActive(true);
                }



            }


        }

    }
}
