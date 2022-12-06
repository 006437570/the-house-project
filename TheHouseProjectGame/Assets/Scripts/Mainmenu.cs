using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AITest()
    {
        SceneManager.LoadScene("AITest");
    }

    public void BRTest()
    {
        SceneManager.LoadScene("BRTest");
    }

    public void MapRNG()
    {
        SceneManager.LoadScene("MapRNGTest");
    }

    public void RingTest()
    {
        SceneManager.LoadScene("RingTest");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}



