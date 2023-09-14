using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}   
