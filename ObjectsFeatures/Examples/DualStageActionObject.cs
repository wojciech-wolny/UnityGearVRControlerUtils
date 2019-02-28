using UnityEngine;

public class DualStageActionObject : InteractionScriptAbstract
{
    private bool _isActive = false;

    public override bool isActive
    {
        get
        {
            return _isActive;
        }
    }

    public override void Activate(GameObject controller)
    {
        this.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        this._isActive = true;
    }

    public override void Deactivate(GameObject controller)
    {
        this.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        this._isActive = false;
    }
}
