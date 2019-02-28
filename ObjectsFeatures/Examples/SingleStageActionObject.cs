using System.Collections;
using UnityEngine;

public class SingleStageActionObject : InteractionScriptAbstract
{
    private Vector3 position;

    private void Start()
    {
        this.position = this.transform.position;
    }

    public override bool isActive
    {
        get
        {
            return false;
        }
    }

    public override void Activate(GameObject controller)
    { 
        this.transform.position = new Vector3(0, 10, 0);
        this.Delay(10);
        this.transform.position = this.position;
    }


    IEnumerator Delay(int time)
    {
        yield return new WaitForSeconds(time);
    }

    public override void Deactivate(GameObject controller){ }
}
