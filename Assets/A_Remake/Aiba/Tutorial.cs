using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] string _name;

    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(_name);
        }
    }
}
