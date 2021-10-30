using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Button lavel1, quit;

    private void Start()
    {
        lavel1.onClick.AddListener(NextScene);
        quit.onClick.AddListener(Quit);
    }

    private void NextScene()
    {
        SceneManager.LoadScene("GameLevel1");
    }

    private void Quit()
    {
        Application.Quit();
    }

}
