using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AddonScript : MonoBehaviour
{
    public int EnergyCounter = 5;
    public object triangleSet_obj;
    public GameObject Triangle;
    public GameObject triangleSet;
    public GameObject EnergyUI;
    GameObject[] trianglesLeft;
    TMP_Text EnergyText;
    //ClickCubeToCircle _clickScript;
    private void Start()
    {
        triangleSet = (GameObject)Resources.Load("TriangleSet");
        EnergyUI = (GameObject)Resources.Load("EnergyAddon");
        //_clickScript = GameObject.Find("ManagerGameObject").GetComponent<ClickCubeToCircle>();
    }
    public void SpawnTriangles()
    {
        Instantiate(triangleSet, new Vector3(0f, 0f, 0f), Quaternion.identity);

    }
    public void SpawnEnergyUI()
    {
       GameObject SpawnedEnergy = Instantiate(EnergyUI, new Vector3(0f,0f,0f),Quaternion.identity);

        SpawnedEnergy.transform.SetParent(GameObject.Find("PlayerProfile").transform);
        SpawnedEnergy.transform.localPosition = new Vector3(-700, 200, 0f);
        EnergyText = SpawnedEnergy.transform.Find("EnergyText").gameObject.GetComponent<TMP_Text>();
        EnergyText.text = ($"Energy: {EnergyCounter.ToString()}");
    }
    private void OnLevelWasLoaded(int level)
    {

        trianglesLeft = GameObject.FindGameObjectsWithTag("Triangle");
        for (int i = 0; i < trianglesLeft.Length; i++)
        {
            Destroy(trianglesLeft[i].gameObject);
        }
        if (level != 0)
        {
            SpawnTriangles();
            SpawnEnergyUI();
        }

    }

    private void Update()
    {
        if (EnergyText != null)
        {
            EnergyText.text = ($"Energy: {EnergyCounter.ToString()}");
        }
        if (ClickCubeToCircle.ClickedFirst != null && ClickCubeToCircle.ClickedSecond != null)
        {


            if (ClickCubeToCircle.ClickedFirst.tag == "Triangle" && ClickCubeToCircle.ClickedSecond.tag == "Square")
            {
                
                ClickCubeToCircle.ClickedSecond.transform.localScale /= 2;
                EnergyCounter--;
                Destroy(ClickCubeToCircle.ClickedFirst);
                ClickCubeToCircle.ClickedFirst = null;
                ClickCubeToCircle.ClickedSecond = null;
            }
        }


        /*private void Update()
        {
            if (_clickScript.ClickedFirst.gameObject != null && _clickScript.ClickedSecond.gameObject != null)
            {


                if (_clickScript.ClickedFirst.gameObject.tag == "Triangle" && _clickScript.ClickedSecond.gameObject.tag == "Square")
                {
                    _clickScript.ClickedSecond.transform.localScale /= 2;
                }
            }*/

    }

}
