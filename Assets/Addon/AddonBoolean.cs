using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddonBoolean : MonoBehaviour
{
    static private GameObject firstInstance = null;
    GameObject _manager;
    public static int Energy = 3;
    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.Find("ManagerGameObject");
        if (firstInstance == null)
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
        if (_manager.GetComponent<AddonScript>() == null)
        {
            _manager.AddComponent<AddonScript>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
