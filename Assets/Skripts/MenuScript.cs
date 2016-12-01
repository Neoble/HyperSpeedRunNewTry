using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public GameObject Menuobject;
    // Use this for initialization
    void Start()
    {
        Menuobject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale==0)
            {
                Menuobject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
            Menuobject.SetActive(true);
            Time.timeScale = 0;
            }
        }
    }

    public void EndGame(string scene)
    {
            SceneManager.LoadScene(scene);
    }

    public void ResumeGame()
    {
        Menuobject.SetActive(false);
        Time.timeScale = 1;
    }
}
