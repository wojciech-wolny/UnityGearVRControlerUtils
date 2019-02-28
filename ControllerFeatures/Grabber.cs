using UnityEngine;
using UnityEngine.UI;

public class Grabber : InteractorBase
{
    public GameObject grabPoint;
    
    private bool hasObject = false;
    private Grabbable obj;

    public void Update()
    {
        Ray ray = this.GetRay();

        RaycastHit hit = this.RayHasCollision(ray);

        if (this.hasColission) 
        {
            Grabbable temp_obj = hit.collider.gameObject.GetComponent<Grabbable>();

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && !this.hasObject)
            {
                temp_obj.Grab(this);
                this.obj = temp_obj;
                hasObject = true;
            }
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) && this.hasObject)
        {
            this.obj.Drop(this);
            this.obj = null;
            hasObject = false;
        }

    }
}
