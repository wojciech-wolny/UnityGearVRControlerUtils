using UnityEngine;


public class VirtualButtons : MonoBehaviour
{
    public GameObject VirtualButtonsContextMenu;
    public GameObject topAction;
    public GameObject bottomAction;
    public GameObject rightAction;
    public GameObject leftAction;
    public int tolerance = 1;

    private Vector2 trackTouchPosition;
    private bool enableVirtualButtons = false;

    void Update()
    {
        this.trackTouchPosition = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        if (OVRInput.GetDown(OVRInput.Button.Back))
        {
            this._SwitchStatus();
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) && this.enableVirtualButtons)
        {
            this._Dispatch();
        }
    }

    private void _SwitchStatus()
    {
        this.enableVirtualButtons = !this.enableVirtualButtons;
        this.VirtualButtonsContextMenu.SetActive(enableVirtualButtons);
        this.gameObject.GetComponent<MoveModule>().HasVirtualButtonsOn = enableVirtualButtons;
    }

    private void _Dispatch()
    {
        double value = 1.0 - this.tolerance / 10.0;

        if (this.trackTouchPosition.x > value)
        {
            this._Call(rightAction.GetComponent<InteractionScriptAbstract>());
        }
        else if (this.trackTouchPosition.x <= -value)
        {
            this._Call(leftAction.GetComponent<InteractionScriptAbstract>());
        }
        else if (this.trackTouchPosition.y >= value)
        {
            this._Call(topAction.GetComponent<InteractionScriptAbstract>());

        }
        else if (this.trackTouchPosition.y <= -value)
        {
            this._Call(bottomAction.GetComponent<InteractionScriptAbstract>());
        }
    }

    private void _Call(InteractionScriptAbstract actionToCall)
    {
        if (!actionToCall.isActive)
        {
            actionToCall.Activate(this.gameObject);
        }
        else
        {
            actionToCall.Deactivate(this.gameObject);
        }

        this._SwitchStatus();
    }
}
