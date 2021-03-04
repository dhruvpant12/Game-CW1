using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoading : MonoBehaviour
{
    
    public void sceneload(int i)
    {
                SceneManager.LoadScene(i);

    }
}
