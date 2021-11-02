using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ray_Point : MonoBehaviour
{
    public float escala;
    public GameObject SpriteLineBegin;
    public GameObject SpriteLineEnd;
    public GameObject SpriteLine;
    public GameObject sphereBegin;
    public GameObject sphereEnd;
    public GameObject lineController;
    public GameObject line1;
    public GameObject line2;
    public GameObject Modal;
    public TextMeshPro TextLine;
    
    Vector3 point1;
    Vector3 point2;
    Vector3 midpoint;
    Vector3 point1ext;
    Vector3 point2ext;
    Vector3 ext = new Vector3(0f,0.05f,0f);
    Vector3 ext2 = new Vector3(0f, 0.055f, 0f);

    float y_rota;
    float z_rota;
    float distance;
    float distance_real;
    float distance_points;
    float FotoScale;

    bool MedirFlag =false;
    bool display = false;
    bool btn_pres = false;

    int cont=0;

    LineRenderer line;
    LineRenderer lineBegin;
    LineRenderer lineEnd;

    GameObject FoundObject;
    string RaycastReturn;

    void Start()
    {
        line = lineController.GetComponent<LineRenderer>();
        lineBegin = line1.GetComponent<LineRenderer>();
        lineEnd = line2.GetComponent<LineRenderer>();   
    }


    void Update()
    {
        if (MedirFlag)
        {
            // Chequeo si se presionó la pantalla:
            if (Input.GetMouseButtonDown(0))    //if ((Input.GetTouch(0).phase == TouchPhase.Began))
            {
                // Despliego rayo:
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                // Verifico si hubo intersección:
                if (Physics.Raycast(ray, out hit))
                {

                        RaycastReturn = hit.collider.gameObject.name;
                        FoundObject = GameObject.Find(RaycastReturn);

                        if (cont == 0)
                        {
                            if (point2 != hit.point) //Para que no se el mismo
                            {
                                point1 = hit.point;
                                cont = cont + 1;

                            }
                            else
                            {

                            }

                        }
                        else
                        {
                            if (point1 != hit.point) //Para que no se el mismo
                            {
                                point2 = hit.point;
                                cont = 0;
                                display = true;
                            }
                            else
                            {
                                Modal.GetComponent<LeanWindow>().TurnOn();
                                NoMedir();
                            }

                        }
                                        

                }
                else
                {
                
                }
        }

            if (display && btn_pres)
            {
                //------------------------------------------------- Crear segmentos --------------------------------------        

                // Segmento 1: 
                lineBegin.SetPosition(0, point1);
                lineBegin.SetPosition(1, point1 + ext);

                // Segmento 2:
                lineEnd.SetPosition(0, point2);
                lineEnd.SetPosition(1, point2 + ext);

                // Segmento Texto-Distancia:
                line.SetPosition(0, point1 + ext);
                line.SetPosition(1, point2 + ext);

                //----------------------------------------------- Obtener distancia --------------------------------------

                // Distancia entre 2 puntos picados:
                distance_points = Vector3.Distance(point1, point2);

                // Punto medio:
                midpoint = new Vector3((point1.x + point2.x) / 2, (point1.y + point2.y) / 2, (point1.z + point2.z) / 2);

                //FotoScale = FoundObject.GetComponent<LoadAssetBundle>().GetScale();
                FotoScale = FoundObject.GetComponentInParent<LoadAssetBundle>().GetScale();

                // Pasaje distancia modelo-real:
                distance_real = ((1 / FoundObject.transform.localScale.x) * distance_points) * FotoScale;
                distance_real = distance_real / 100;
                if (FoundObject.transform.localScale.x > 1)
                {
                    distance_real = (distance_points) * FotoScale;
                }
                distance_real = (float)System.Math.Round(distance_real, 3);
                // distancia -> texto:
                TextLine.text = (distance_real).ToString() + " m";
                // Ubicación Texto/Sprite:
                TextLine.transform.localPosition = midpoint + ext2;
                // Sphere-Positions:
                point1ext = point1 + ext;
                point2ext = point2 + ext;
                sphereBegin.transform.position = point1ext;
                sphereEnd.transform.position = point2ext;

                //----------------------------------------------- Alinear Texto/Sprite ----------------------------------------

                // LookAT point 2:
                TextLine.transform.LookAt(point2ext);
                // Alinear al LineRenderer:
                TextLine.transform.Rotate(0, 270, 0);
                // Alinear y corregir ejes:
                distance_points = Vector3.Distance(point1ext, point2ext);
                y_rota = TextLine.transform.eulerAngles.y;
                z_rota = Mathf.Asin((point2ext.y - point1ext.y) / distance_points);
                z_rota = (z_rota * 180) / (3.14f);
                TextLine.transform.eulerAngles = new Vector3(0, y_rota, z_rota);
        
                //----------------------------------------------- Display -----------------------------------------------------

                SpriteLineBegin.transform.localPosition = new Vector3((point1.x + point1ext.x) / 2, (point1.y + point1ext.y) / 2, (point1.z + point1ext.z) / 2);
                SpriteLineEnd.transform.localPosition = new Vector3((point2.x + point2ext.x) / 2, (point2.y + point2ext.y) / 2, (point2.z + point2ext.z) / 2);

                sphereBegin.SetActive(true);
                sphereEnd.SetActive(true);

                SpriteLine.SetActive(true);
                SpriteLineBegin.SetActive(true);
                SpriteLineEnd.SetActive(true);

                display = false;
        }
       
    }

    }

    public void btn_true()
    {
        btn_pres = true;
    }

    public void btn_false()
    {
        btn_pres = false;
    }

    public void Medir()
    {
        MedirFlag = true;
        cont = 0;
    }

    public void NoMedir()
    {
        // Ocultar:

        Vector3 zero = Vector3.zero;
        lineBegin.SetPosition(0, zero);
        lineBegin.SetPosition(1, zero);

        lineEnd.SetPosition(0, zero);
        lineEnd.SetPosition(1, zero);

        line.SetPosition(0, zero);
        line.SetPosition(1, zero);

        TextLine.text = "";

        display = false;
        MedirFlag = false;

        SpriteLineBegin.SetActive(false);
        SpriteLineEnd.SetActive(false);

        SpriteLine.SetActive(false);
        sphereBegin.SetActive(false);
        sphereEnd.SetActive(false);

    }

   

}
