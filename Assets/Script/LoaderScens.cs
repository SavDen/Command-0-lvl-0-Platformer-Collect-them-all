using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderScens : MonoBehaviour
{
    public void LoadScene(int countScene)
    {
        SceneManager.LoadScene(countScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
