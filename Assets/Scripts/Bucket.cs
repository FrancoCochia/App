using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Text;
using System.IO;

public class Bucket : MonoBehaviour
{
    public string Bucket_path;
    public InputField Box;
    public GameObject FirebaseInit;
    public GameObject Alerta_Bucket;
    public GameObject Panel_menu;
    public GameObject GoPDF;
    char ch;
    string pathLOCAL;
    bool keyfound = false;

    public string Decrypt(string aux)
    {
        StringBuilder varDescryp = new StringBuilder(aux.Length);

        for (int i = 0; i < aux.Length; i++)
        {
            ch = (char)(aux[i] ^ 500);
            varDescryp.Append(ch);
        }

        return varDescryp.ToString();
    }

    public void DecryptText()
    {
        pathLOCAL = Application.persistentDataPath + "/pass.txt";

        StreamReader inp_stm = new StreamReader(pathLOCAL);

        string word_encrypt;

        var line = inp_stm.ReadLine();

        while (line != null)
        {
            word_encrypt = Decrypt(line);

            if(word_encrypt == Box.text)
            {
                keyfound = true;
            }

            line = inp_stm.ReadLine();
        }

        inp_stm.Close();
    }

    public void SetBucket()
    {
        DecryptText();
        Bucket_path = "gs://ii-2020-de4e9.appspot.com/" + Box.text;

        if (keyfound==false)
        {
            Debug.Log("Connection refused");
            Alerta_Bucket.GetComponent<LeanWindow>().TurnOn();
        }
        else
        {
            Debug.Log("Connection accepted");
            FirebaseInit.GetComponent<FirebaseInit>().DownloadNames();

            Panel_menu.transform.DOLocalMoveX(Vector3.zero.x, 0.4f);

            GoPDF.GetComponent<GoPDF>().CargarURL(Bucket_path);
        }

    }

    

}
