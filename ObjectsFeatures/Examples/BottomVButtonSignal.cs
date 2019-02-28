using UnityEngine;

public class BottomVButtonSignal : InteractionScriptAbstract
{
    private bool _isActive = true;

    public override bool isActive
    {
        get
        {
            return this._isActive;
        }
    }

    public override void Activate(GameObject controller)
    {
        this.gameObject.SetActive(true);
        this._isActive = true;
    }

    public override void Deactivate(GameObject controller)
    {
        this.gameObject.SetActive(false);
        this._isActive = false;
    }
}

