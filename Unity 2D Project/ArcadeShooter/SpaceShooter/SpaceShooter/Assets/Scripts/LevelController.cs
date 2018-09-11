using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public void LoadGameOver()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);

    }


    public void QuitGame()   { Application.Quit(); }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("SpaceShooter", LoadSceneMode.Single);
        FindObjectOfType<GameController>().ResetScore();
    }

    public void LoadStartMenu() {      SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); }
}
