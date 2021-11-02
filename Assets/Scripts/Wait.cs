using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    public GameObject Panel;

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(2);

        Panel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
