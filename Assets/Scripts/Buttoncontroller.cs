using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttoncontroller : MonoBehaviour
{
    // Start is called before the first frame update
  public void startthegame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
