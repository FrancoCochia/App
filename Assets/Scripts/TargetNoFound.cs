using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;

public class TargetNoFound : MonoBehaviour
{
    bool SendNotification = true;

    public GameObject Modal;

    // Notificación de reconocimiento invalido:
    void Update()
    {
        if (!SendNotification)
        {
            Modal.GetComponent<LeanWindow>().TurnOff();
        }
    }

    public void ChangeValue(bool flag)
    {
        SendNotification = flag;
    }

    public void Check()
    {
        StartCoroutine(WaitAndCheck());
    }

    IEnumerator WaitAndCheck()
    {
        yield return new WaitForSeconds(10);

        if (SendNotification)
        {
            Modal.GetComponent<LeanWindow>().TurnOn();
        }
        else
        {
            Modal.GetComponent<LeanWindow>().TurnOff();
        }
    }
    
}
