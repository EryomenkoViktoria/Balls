using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Intro_Manager : MonoBehaviour
{
    [SerializeField]
    private Button buttonMenu;

    private async void Start()
    {
        buttonMenu.onClick.AddListener(NextScene);
        await Task.Delay(5000);
        NextScene();
    }

    private void NextScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
