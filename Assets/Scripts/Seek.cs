using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    public GameObject target;
    public AIData data;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        data.vTarget = target.transform.position;
        BehaviourControl.Seek(data);
        BehaviourControl.Move(data);
    }

    private void OnDrawGizmos()
    {
        if (data != null)
        {
            if (data.fMoveForce > 0.0f)
            {
                Gizmos.color = Color.blue;
            }
            else
            {
                Gizmos.color = Color.red;
            }

            Gizmos.DrawLine(this.transform.position,
                this.transform.position + this.transform.forward * data.fMoveForce * 2.0f);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(this.transform.position,
                this.transform.position + this.transform.forward * 2.0f);

            //Gizmos.color = Color.gray;
            //Gizmos.DrawLine(this.transform.position, data.vTarget);
        }
    }
}
