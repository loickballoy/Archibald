using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    public Animator animator;
    
    public GameObject PauseMenu;
    public string StartMenu;

    public GameObject dontDestroy;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !InventoryMenu.inventoryOpen)
        {
            if (isPaused)
            {
                EndPause();
            }
            else
            {
                StartPause();
            }
        }
    }

    void StartPause()
    {
        PauseMenu.SetActive(true);
        animator.SetBool("IsOnPause", true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void EndPause()
    {
        PauseMenu.SetActive(false);
        animator.SetBool("IsOnPause", false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Quit()
    {
        SceneManager.LoadScene(StartMenu);
        EndPause();
        foreach (GameObject objects in dontDestroy.GetComponent<DontDestroy>().objects)
        {
            Destroy(objects);
        }
        
    }
}
