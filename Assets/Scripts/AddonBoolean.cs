using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddonBoolean : MonoBehaviour
{
    static private GameObject firstInstance = null;
    public bool PlayWithAddon = true;
    public static int Energy = 3;
    // Start is called before the first frame update
    void Start()
    {
        if(firstInstance == null)
        {
            firstInstance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        
    }    

    public void toogleAddon()
    {
        PlayWithAddon = !PlayWithAddon;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
