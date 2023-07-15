using UnityEngine.SceneManagement;
using UnityEngine;

public class GenerateNextScene : MonoBehaviour
{
    public string NewScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(NewScene);
        }
    }
}
