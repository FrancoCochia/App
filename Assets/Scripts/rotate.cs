using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class rotate : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject empty1;
    public GameObject control1;
    public GameObject empty2;
    public GameObject control2;
    public GameObject empty3;
    public GameObject control3;
    public GameObject empty4;
    public GameObject control4;
    public GameObject empty5;
    public GameObject control5;
    
    public string direc;
    public float speed;
  
    bool _pressed = false;

    // Si el boton se encuentra presionado:
    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;
    }

    // Si el boton no se encuentra presionado:
    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
    }

    void Update()
    {
       
        if (_pressed)
        {
            if(direc == "R") // Chequeo si es derecha
            {
                empty1.transform.Rotate(Vector3.up, speed * Time.deltaTime);
                empty2.transform.Rotate(Vector3.up, speed * Time.deltaTime);
                empty3.transform.RotateAround(control3.transform.position, Vector3.up, speed * Time.deltaTime);
                empty4.transform.Rotate(Vector3.up, speed * Time.deltaTime);
                empty5.transform.Rotate(Vector3.up, speed * Time.deltaTime);


            }
            else if(direc == "L") // Chequeo si es izquierda
            {
                empty1.transform.Rotate( Vector3.up, -speed * Time.deltaTime);
                empty2.transform.Rotate( Vector3.up, -speed * Time.deltaTime);
                empty3.transform.RotateAround(control3.transform.position, Vector3.up, -speed * Time.deltaTime);
                empty4.transform.Rotate(Vector3.up, -speed * Time.deltaTime);
                empty5.transform.Rotate(Vector3.up, -speed * Time.deltaTime);
            }
        }     

    }
}
