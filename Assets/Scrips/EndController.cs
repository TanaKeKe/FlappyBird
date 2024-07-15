using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public void GoBackMenu()
    {
        
        SceneManager.LoadScene(SceneData.home);
        Time.timeScale = 1.0f;
    }
}
