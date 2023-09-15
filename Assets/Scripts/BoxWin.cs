using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BoxWin : MonoBehaviour
{
    [SerializeField] private int itemCount = 0;
    public string nameScene;
    public GameObject winPanel;

    private void FixedUpdate()
    {
        if (itemCount > 2)
        {
            winPanel.SetActive(true);
            Invoke("CooldownChangeScene", 5.0f);
            
        }
    }

    public void CooldownChangeScene() 
    {
        ChangeScene(nameScene);
    }

    public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Wood")
        {
            itemCount++;
        }
        if (other.gameObject.name == "Metal")
        {
            itemCount++;
        }
        if (other.gameObject.name == "Crystal")
        {
            itemCount++;
        }
        if (other.gameObject.name == "Picker")
        {
            itemCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Wood")
        {
            itemCount--;
        }
        if (other.gameObject.name == "Metal")
        {
            itemCount--;
        }
        if (other.gameObject.name == "Crystal")
        {
            itemCount--;
        }
        if (other.gameObject.name == "Picker")
        {
            itemCount--;
        }
    }
    
}
