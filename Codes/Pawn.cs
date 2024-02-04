using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Pawn : Figure
{
    public GameObject obj;
    public override void Choose_move()
    {
        Instantiate(obj, new Vector3(0, 0.5f, 0), Quaternion.Euler(0, 0, 0));
    }
}
