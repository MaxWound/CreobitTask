using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLevelManager : MonoBehaviour
{
    
    public GameObject TrianglePrefab;
    public GameObject tier1;
    public GameObject tier2;
    private void Start()
    {
        if (GameObject.Find("AddonManager").GetComponent<AddonBoolean>().PlayWithAddon == true)
        {
            Instantiate(TrianglePrefab, tier1.transform.position, tier1.transform.rotation);
            Instantiate(TrianglePrefab, tier2.transform.position, tier2.transform.rotation);
        }
    }




}
