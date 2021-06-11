using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject _menu;
    public static bool _MENU;
    private void Start()
    {
        _MENU = false;
    }
    public void MenuButton()
    {
        if (!_MENU)
        {
            _MENU = true;
            _menu.SetActive(true);
        }
        else
        {
            _MENU = false;
            _menu.SetActive(false);
        }

    }
    public void NewGame() { SceneManager.LoadScene(0); }
    public void Recrod() {  }
    public void ExitGame() { Application.Quit(); }
}
