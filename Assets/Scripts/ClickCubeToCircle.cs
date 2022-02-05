using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickCubeToCircle : MonoBehaviour
{
    static private GameObject firstInstance = null;
    public static GameObject ClickedFirst;
    public static GameObject ClickedSecond;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
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
    // Start is called before the first frame update
    private void Update()
    {
        ////////////
        if (Input.GetKeyDown(KeyCode.K))
        {
            GetComponent<AddonScript>().SpawnTriangles();
        }
        ////////////

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit.collider != null)
            {
                
                if (ClickedFirst == null)
                {
                    ClickedFirst = hit.collider.gameObject;

                }
                else
                {
                    ClickedSecond = hit.collider.gameObject;
                }

            }

            else
            {
                ClickedFirst = null;
                ClickedSecond = null;
                print(Input.mousePosition);
            }
        }



        if (ClickedFirst != null && ClickedSecond != null)
        {
            if (ClickedFirst.tag == "Square" && ClickedSecond.tag == "Circle")
            {
                if (((ClickedSecond.transform.localScale.x + ClickedSecond.transform.localScale.y) / (ClickedFirst.transform.localScale.x + ClickedFirst.transform.localScale.y)) >= 1.4f)

                {
                    ClickedFirst.transform.position = ClickedSecond.transform.position;

                    ClickedFirst.GetComponent<Collider2D>().enabled = false;
                    ClickedFirst = null;
                    ClickedSecond = null;

                    PlayerProfile.moves += 1;

                }
            }
          

        }
    }


}
