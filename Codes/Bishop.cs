using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Figure
{
    protected float cell = 0.3f;
    public GameObject obj;
    bool maxx;
    bool maxz;
    bool minx;
    bool minz;
    public override void Choose_move()
    {
        for (int i = 0; i < 7; i++)
        {
            maxx = ((transform.position.x + 8 + (i * 6) <= 24));
            maxz = ((transform.position.z + 8 + (i * 6) <= 24));
            minx = ((transform.position.x - 4 - (i * 6) >= -24));
            minz = ((transform.position.z - 4 - (i * 6) >= -24));
            if ((maxx) && (maxz))
            { 
                Instantiate(obj, new Vector3(transform.position.x + 8 + (i * 6), transform.position.y + 0.2f, transform.position.z + 8 + (i * 6)), Quaternion.Euler(0, 0, 0));
            }
            if ((minx) && (minz))
            {
                Instantiate(obj, new Vector3(transform.position.x - 4 - (i * 6), transform.position.y + 0.2f, transform.position.z - 4 - (i * 6)), Quaternion.Euler(0, 0, 0));
            }
            if ((maxx) && (minz))
            {
                Instantiate(obj, new Vector3(transform.position.x + 8 + (i * 6), transform.position.y + 0.2f, transform.position.z - 4 - (i * 6)), Quaternion.Euler(0, 0, 0));
            }
            if ((minx) && (maxz))
            {
                Instantiate(obj, new Vector3(transform.position.x - 4 - (i * 6), transform.position.y + 0.2f, transform.position.z + 8 + (i * 6)), Quaternion.Euler(0, 0, 0));
            }
        }
    }
}

