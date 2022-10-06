using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAIba : MonoBehaviour
{
    [SerializeField] float time = 1;
    [SerializeField] string name;
    [SerializeField] GameObject panl;
    public void SceneLoad()
    {
        panl.SetActive(true);
        StartCoroutine(RE());
    }

   IEnumerator  RE()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(name);
    }

}
