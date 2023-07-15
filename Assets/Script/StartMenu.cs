using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public string StartScene;
    public string CreditsScene;
    public string serverMenu;
    public Save save;
    public string saveName;

    public void NewGame()
    {
        SceneManager.LoadScene(StartScene);
    }
    public void Continue()
    {
        SceneManager.LoadScene("SampleScene");
        save.LoadSave(saveName);
    }
    public void Settings()
    {

    }
    public void Credits()
    {
        SceneManager.LoadScene(CreditsScene);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void ServerJoin()
    {
        SceneManager.LoadScene(serverMenu);
    }
}