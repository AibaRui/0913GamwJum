using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ƒV[ƒ“‘JˆÚ
/// </summary>
public class LoadScene : MonoBehaviour
{

    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
