using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionObjectTrigger : InteractorBase
{   
    public void Update()
    {
        Ray ray = this.GetRay();

        RaycastHit hit = this.RayHasCollision(ray);

        Interact(hit);
    }

    private void Interact(RaycastHit hit)
    {
        if (this.hasColission)
        {
            InteractionScriptAbstract obj = hit.collider.gameObject.GetComponent<InteractionScriptAbstract>();

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                if (!obj.isActive)
                {
                    obj.Activate(this.gameObject);
                }
                else
                {
                    obj.Deactivate(this.gameObject);
                }
            }
        }
    }
}
