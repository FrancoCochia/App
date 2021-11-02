using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_scene : MonoBehaviour
{  
    // Cambio de escena y limpieza de cache:
    public void Change_this_scene(string scene_name)
    {
        Caching.ClearCache();    
        SceneManager.LoadScene(scene_name);
    }

    // Cambio de escena con retardo:
    public void WaitChangeScene(string scene_name)
    {
        Caching.ClearCache();
        StartCoroutine(WaitChange(scene_name));
    }

    IEnumerator WaitChange(string scene_name)
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadSceneAsync(scene_name);
    }


}
