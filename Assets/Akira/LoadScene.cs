using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ?V?[???J??
/// </summary>
public class LoadScene : MonoBehaviour
{

    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
