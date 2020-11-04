using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenLevel(int n)
    {
        string level = "Level-" + n;
        SceneManager.LoadScene(level);
    }
}
