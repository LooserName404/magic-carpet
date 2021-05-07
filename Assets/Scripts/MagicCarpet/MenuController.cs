using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Scenes/GameScene");
    }

    public void Exit()
    {
        Debug.Log("Bye!");
        Application.Quit();
    }
}
