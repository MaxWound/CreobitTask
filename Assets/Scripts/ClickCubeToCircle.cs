using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickCubeToCircle : MonoBehaviour
{
    
    GameObject ClickedSquare;
    GameObject ClickedCircle;
    GameObject ClickedTriangle;
    
    // Start is called before the first frame update
    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Square")
                {
                    ClickedSquare = hit.collider.gameObject;
                }
                if (hit.collider.gameObject.tag == "Circle" && ClickedSquare != null)
                {
                    ClickedCircle = hit.collider.gameObject;
                }
                if (hit.collider.gameObject.tag == "Triangle")
                {
                    ClickedTriangle = hit.collider.gameObject;
                }
            }
            else
                print(Input.mousePosition);
        }


        if (ClickedSquare != null && ClickedTriangle != null && AddonBoolean.Energy >= 1)
        {
            Destroy(ClickedTriangle.gameObject);
            ClickedSquare.transform.localScale /= 2;
            AddonBoolean.Energy--;
        }
        if (ClickedSquare != null && ClickedCircle != null)
        {
            if (((ClickedCircle.transform.localScale.x + ClickedCircle.transform.localScale.y) / (ClickedSquare.transform.localScale.x + ClickedSquare.transform.localScale.y)) >= 1.4f)
            {
                ClickedSquare.transform.position = ClickedCircle.transform.position;
                ClickedCircle = null;
                ClickedSquare.GetComponent<Collider2D>().enabled = false;
                ClickedSquare = null;

                PlayerProfile.moves += 1;

            }
            else
            {
                ClickedSquare = null;
                ClickedCircle = null;
            }

        }
    }


}
