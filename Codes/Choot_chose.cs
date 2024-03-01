using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_chose : MonoBehaviour
{
    [SerializeField] protected GameObject cam;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 rayStartPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(rayStartPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                print("shooted");
                if (hit.collider != null)
                {
                    print("attacked");
                    hit.collider.GetComponent<Queen>().Choose_move();
                }
            }
        }
    }
}