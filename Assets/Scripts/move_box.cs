using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class move_box : MonoBehaviour
{
    // Muevo el panel al centro:
    public void MovePanelX(GameObject Panel)
    {
        Panel.transform.DOLocalMoveX(Vector3.zero.x, 0.4f);
    }

    // Muevo el panel a la derecha:
    public void MovePanelX_distance(GameObject Panel)
    {
        Panel.transform.DOLocalMoveX(1030, 0.4f);
    }
}
