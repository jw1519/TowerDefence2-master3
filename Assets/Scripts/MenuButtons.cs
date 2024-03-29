using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject MenuPannel;
    public GameObject LevelPannel;
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void StartLevel1()
    {
        SceneManager.LoadScene("Level");
    }
    public void LoadOptions()
    {
        Debug.Log("not yet added");
    }
    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void GoToMenuPannel()
    {
        MenuPannel.SetActive(true);
        LevelPannel.SetActive(false);
    }
    public void GoToLevelPannel()
    {
        MenuPannel.SetActive(false);
        LevelPannel.SetActive(true);
    }
}
