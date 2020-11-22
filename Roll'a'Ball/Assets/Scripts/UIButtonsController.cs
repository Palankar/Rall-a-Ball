using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonsController : MonoBehaviour
{

    public GameObject buttonsMenu;
    public GameObject buttonsExit;
    public SceneEntity sceneEntity;
    public GameObject player;

    public void Restart()
    {
        Vector3 vector;
        switch (sceneEntity.Stage)
        {
            case 1:
                vector = (Vector3)sceneEntity.stageVectors.GetValue(0);
                player.gameObject.transform.position = vector;
                break;
            case 2:
                vector = (Vector3)sceneEntity.stageVectors.GetValue(1);
                player.gameObject.transform.position = vector;
                break;
            case 3:
                vector = (Vector3)sceneEntity.stageVectors.GetValue(2);
                player.gameObject.transform.position = vector;
                break;
            default:
                Debug.LogError("Не найдена сцена " + sceneEntity.Stage);
                break;
        };
        player.GetComponent<PlayerController>().Respawn();
    }

    public void Starts()
    {
        SceneManager.LoadScene("RollaBallScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowExitMenu()
    {
        buttonsExit.SetActive(true);
        buttonsMenu.SetActive(false);
    }

    public void BackToMenu()
    {
        buttonsExit.SetActive(false);
        buttonsMenu.SetActive(true);
    }
}
