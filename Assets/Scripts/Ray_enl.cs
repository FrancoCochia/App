using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ray_enl : MonoBehaviour
{
    GameObject FoundObject;
    string RaycastReturn;
    string Link;

    void Update()
    {
        // Chequeo si se presionó la pantalla:
        if (Input.GetMouseButtonDown(0))
        {
            // Despliego rayo:
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            // Verifico si hubo intersección:
            if (Physics.Raycast(ray, out hit))
            {
                // Obtenego el objecto intersectado:
                RaycastReturn = hit.collider.gameObject.name;
                FoundObject = GameObject.Find(RaycastReturn);

                if (RaycastReturn.Contains("enl"))
                {
                    // Si es un enlace, verifico que no sea vacío y lo abro:
                    Link = FoundObject.GetComponent<LoadEnl>().ReturnLink() ;

                    if (Link != "")
                    {
                        Application.OpenURL(Link);
                    }
                    
                }

            }
            else
            {

            }
        }
    }
}
