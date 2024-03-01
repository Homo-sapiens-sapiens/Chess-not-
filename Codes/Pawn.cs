using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Pawn : Figure
{
    protected float cell = 0.3f;
    public GameObject obj;
    public override void Choose_move()
    {
        Instantiate(obj, new Vector3(transform.position.x + 2, transform.position.y - 1.1f , transform.position.z - 4), Quaternion.Euler(0, 0, 0));
        Instantiate(obj, new Vector3(transform.position.x + 2, transform.position.y - 1.1f, transform.position.z - 10), Quaternion.Euler(0, 0, 0));
        print("Вроде работает");
    }
}
