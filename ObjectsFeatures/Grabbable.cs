using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Grabbable : MonoBehaviour
{

    private float distance;
    private bool _isGrabbed = false;

    private Vector3 lastPosition;
    private Vector3 lastRotation;

    private Grabber controller;
    private Transform originParent;
    private Rigidbody rig;

    private Vector3 angularVelocity;
    private Vector3 velocity;

    public int forceScalar = 10;

    private void Start()
    {
        originParent = this.transform.parent;

        this.rig = this.GetComponent<Rigidbody>();
    }

    public bool IsGrabbed
    {
        get
        {
            return this._isGrabbed;
        }
    }

    public void Grab(Grabber controller)
    {
        this.controller = controller;
        this._isGrabbed = true;

        this.rig.isKinematic = true;
        this.rig.useGravity = false;

        this.transform.Rotate(Vector3.zero);
        this.transform.parent = this.controller.grabPoint.transform;
        this.transform.localPosition = Vector3.zero;
    }

    public void Drop(Grabber controller)
    {
        this.controller = controller;
        this._Drop();
    }

    private void AddThrowForce()
    {
        this.rig.velocity = velocity;
        this.rig.angularVelocity = angularVelocity;
    }

    private void _Drop()
    {
        this.rig.isKinematic = false;
        this.rig.useGravity = true;

        this._isGrabbed = false;
        this.transform.parent = this.originParent;
        this.AddThrowForce();
    }

    public void Update()
    {
        if (this._isGrabbed)
        {
            if (distance > this.controller.interactionRange / 2)
            {
                velocity = Vector3.zero;
                angularVelocity = Vector3.zero;
                this._Drop();
                return;
            }

            distance = Vector3.Distance(this.transform.position, this.controller.transform.position);

            velocity = (this.transform.position - this.lastPosition) / Time.deltaTime;
            angularVelocity = (this.transform.eulerAngles - this.lastRotation) / Time.deltaTime;

            this.lastPosition = this.transform.position;
            this.lastRotation = this.transform.eulerAngles;
        }
    }
}
