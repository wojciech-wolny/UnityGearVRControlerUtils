using UnityEngine;

public abstract class InteractionScriptAbstract : MonoBehaviour
{
    public abstract bool isActive{ get; }

    public abstract void Activate(GameObject controller);
    public abstract void Deactivate(GameObject controller);

}
