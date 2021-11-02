using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MovePanel : MonoBehaviour
{
    public float offset;
    public bool menu = false;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "main")
        {
            menu = true;
        }

        if (menu && scene.name == "loggin")
        {
            GameObject Panel_menu = GameObject.Find("Panel_menu");
            Panel_menu.transform.DOLocalMoveX(Vector3.zero.x, 0f);
        }
    }

    // Muevo el panel al centro:
    public void MovePanelX(GameObject Panel)
    {
        Panel.transform.DOLocalMoveX(Vector3.zero.x,0.4f);
    }

    // Muevo el panel al centro:
    public void MovePanelFirst(GameObject Panel)
    {
        Panel.transform.DOLocalMoveX(Vector3.zero.x, 0.4f);
    }

    // Muevo el panel con offset:
    public void MovePanelX_distance(GameObject Panel)
    {
        Panel.transform.DOLocalMoveX(offset, 0.4f);
    }

    // Confirmar despliegue:
    public void MoveInst()
    {
        menu = true;
    }


}
 