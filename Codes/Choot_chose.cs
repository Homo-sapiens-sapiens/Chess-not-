using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_chose : MonoBehaviour
{
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Began))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    hit.collider.GetComponent<Pawn>().Choose_move();
                }
            }
        }
    }
}