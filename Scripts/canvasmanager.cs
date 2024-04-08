using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasmanager : MonoBehaviour
{
    public Canvas canvas;
    public Canvas canvasPause;
    // Start is called before the first frame update
    void Start()
    {
        canvasPause.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

   public void startGame()
    {
        Time.timeScale = 1f;
       canvas.gameObject.SetActive(false);
    }
    public void Pause()
    {
        canvasPause.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void UnPause()
    {
        canvasPause.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
