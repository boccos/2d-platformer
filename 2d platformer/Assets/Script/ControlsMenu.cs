using UnityEngine;
using UnityEngine.SceneManagement;

public class controlsMenu : MonoBehaviour
{
    [SerializeField] GameObject controlMenu;


    public void Exit()
    {
        controlMenu.SetActive(false);
        Time.timeScale = 0;
    }

}