using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
  public void StartLevel_1()
    {
        SceneManager.LoadScene(1);
    }
    public void StartLevel_2()
    {
        SceneManager.LoadScene(2);
    }
    public void StartLevel_3()
    {
        SceneManager.LoadScene(3);
    }

}
