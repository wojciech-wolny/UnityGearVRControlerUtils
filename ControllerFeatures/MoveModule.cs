using UnityEngine;


public class MoveModule : MonoBehaviour
{
    public GameObject VRPlaverModel;
    public float speed = 10;
    public bool HasVirtualButtonsOn = false;

    private Vector2 trackTouchPosition;

    private void Update()
    {
        this.trackTouchPosition = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        if (this.HasVirtualButtonsOn)
        {
            return; 
        }

        float x = this.trackTouchPosition.x * this.speed * Time.deltaTime;
        float z = this.trackTouchPosition.y * this.speed * Time.deltaTime;

        this.VRPlaverModel.transform.Translate(x, 0, z);
    }
}
