using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : InteractorBase
{
    public GameObject pointer;

	// Update is called once per frame
	void LateUpdate ()
    {
        Ray ray = this.GetRay();

        RaycastHit hit = this.RayHasCollision(ray);

        if (this.hasColission)
        {
            this.pointer.transform.position = hit.point;
        }
        else
        {

            this.pointer.transform.position = new Vector3(0, -9999999, 0);
        }

    }
}
