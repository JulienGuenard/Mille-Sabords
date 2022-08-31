using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerMenu : UIManagerHeritage
{
    public GameObject CanvasMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F10) || Input.GetKeyDown(KeyCode.Escape))
        {
            CanvasMenu.SetActive(!CanvasMenu.activeInHierarchy);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("2P_Game");
    }

    public void Return()
    {
        CanvasMenu.SetActive(false);
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
