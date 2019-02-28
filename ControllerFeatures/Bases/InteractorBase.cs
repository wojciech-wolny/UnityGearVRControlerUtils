using UnityEngine;

public abstract class InteractorBase : MonoBehaviour
{
    public int interactionRange = 0;
    protected bool hasColission = false;

    protected RaycastHit RayHasCollision(Ray ray)
    {
        RaycastHit hit;
        this.hasColission = Physics.Raycast(ray, out hit, this.interactionRange);
        return hit;
    }

    protected Ray GetRay()
    {
        return new Ray(transform.position, transform.forward);
    }

}
