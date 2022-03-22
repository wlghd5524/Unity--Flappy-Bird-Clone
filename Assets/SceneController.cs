using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void GoPlayScene()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void GoStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    
    int ClickCount = 0;
    bool ready = false;
    void Update()
    {   
         if (SceneManager.GetActiveScene().name == "PlayScene")
            {
                if (ready == false) {
                    Time.timeScale = 0.0F;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    ready = true;
                    Time.timeScale = 1.0F;
                }
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GoStartScene();
            }
        else
        {
            if (SceneManager.GetActiveScene().name == "StartScene")
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ClickCount++;
                    if(!IsInvoking("DoubleClick"))
                        Invoke("DoubleClick",1.0f);
                }
                else if (ClickCount == 2)
                {
                    CancelInvoke("DoubleClick");
                    Application.Quit();
                }
            }
        }
        
    }
    void DoubleClick()
    {
        ClickCount = 0;
    }
    
    
}
