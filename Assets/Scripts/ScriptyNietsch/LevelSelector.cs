using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SelectedScene(int Level)
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + Level);

        // if (Level == 1)
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + Level);
        // }
        // else if (Level == 2)
        // {
        //     Debug.Log("Level 2");
        //     //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        // }
        // else
        // {
        //     Debug.Log("Level 3");
        //     //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        // }
    }
}
