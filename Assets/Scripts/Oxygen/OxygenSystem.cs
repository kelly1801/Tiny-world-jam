using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenSystem : MonoBehaviour
{

    [SerializeField] private float maxOxygenLevel = 100f;
    [SerializeField] private OxygenBar oxygenBar;
    [SerializeField] private float decreaseLevel = 2.0f;
    private PlayerMovement playerScript;
    private float initialSpeed;
    [SerializeField] private float currentOxygenLevel;
 
    ///////
    public UIManager sceneChanger;


    // Start is called before the first frame update
    void Start()
    {
        playerScript = gameObject.GetComponent<PlayerMovement>();
        currentOxygenLevel = maxOxygenLevel;
        oxygenBar.SetSliderMax(maxOxygenLevel);
        initialSpeed = playerScript.speed;
        sceneChanger = GameObject.Find("SceneChanger").GetComponent<UIManager>();
        

    }
    private void Update()
    {
        ChangeOxygenLevels(decreaseLevel);
        ChangeSpeedBasedOnOxygenLevel();
    }

    // Update is called once per frame
    public void ChangeOxygenLevels(float amount)
    {
        if (playerScript.isTiny)
        {
            currentOxygenLevel -= amount * Time.deltaTime;
            currentOxygenLevel = Mathf.Clamp(currentOxygenLevel, 0f, maxOxygenLevel); // Ensure it doesn't go below 0

            oxygenBar.SetSlider(currentOxygenLevel);
        }
        else
        {
            oxygenBar.SetSliderMax(maxOxygenLevel);
            currentOxygenLevel = maxOxygenLevel;
        } 

    }

    public void ChangeSpeedBasedOnOxygenLevel() {

        float minSpeed = initialSpeed / 2;
        if (playerScript.isTiny && currentOxygenLevel < 25)
        {
            playerScript.speed = Mathf.Max(minSpeed, playerScript.speed - 1);
        }
        
        if (currentOxygenLevel <= 0)
        {
            sceneChanger.ChangeScene("LostScene");
        }
        
        else
        {
            playerScript.speed = initialSpeed;
        }
    
    }

    
    
}
