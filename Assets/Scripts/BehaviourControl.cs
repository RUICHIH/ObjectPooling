using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourControl
{
    static public void Move(AIData data)
    {
        if (data.bMove == false)
        {
            return;
        }
        Transform t = data.Action.transform;
        Vector3 cPos = data.Action.transform.position;
        Vector3 vR = t.right;//turn control
        Vector3 vOriF = t.forward;//move forward
        Vector3 vF = data.vCurrentVector;

        if (data.fTempTurnForce > data.fMaxRot)
        {
            data.fTempTurnForce = data.fMaxRot;
        }
        else if (data.fTempTurnForce < data.fMaxRot)
        {
            data.fTempTurnForce = -data.fMaxRot;//turn control
        }

        vF = vF + vR * data.fTempTurnForce;
        vF.Normalize();
        t.forward = vF;

        data.speed = data.speed + data.fMoveForce * Time.deltaTime;
        if (data.speed < 0.01)
        {
            data.speed = 0.01f;
        }
        else if (data.speed > data.fMaxSpeed)
        {
            data.speed = data.fMaxSpeed;
        }

        cPos = cPos + t.forward * data.speed * Time.deltaTime;
        t.position = cPos;
    }

    static public bool Seek(AIData data)
    {
        Vector3 cPos = data.Action.transform.position;
        Vector3 vec = data.vTarget - cPos;
        vec.y = 0.0f;
        float fDist = vec.magnitude;
        if (fDist < data.speed + 0.001f)
        {
            Vector3 vFinal = data.vTarget;
            vFinal.y = cPos.y;
            data.Action.transform.position = vFinal;
            data.fMoveForce = 0.0f;
            data.fTempTurnForce = 0.0f;
            data.speed = 0.0f;
            data.bMove = false;
            return false;
        }
        Vector3 vf = data.Action.transform.forward;
        Vector3 vr = data.Action.transform.right;
        data.vCurrentVector = vf;
        vec.Normalize();
        float fDotF = Vector3.Dot(vf, vec);
        if (fDotF > 0.96f)
        {
            fDotF = 1.0f;
            data.vCurrentVector = vec;
            data.fTempTurnForce = 0.0f;
            data.fRot = 0.0f;
        }
        else
        {
            if (fDotF < -1.0f)
            {
                fDotF = 1.0f;
            }

            float fDotR = Vector3.Dot(vr, vec);
            if (fDotF < 0.0f)
            {
                if (fDotR > 0.0f)
                {
                    fDotR = 1.0f;
                }
                else
                {
                    fDotR = -1.0f;
                }
            }
            if (fDist < 3.0f)
            {
                fDotR *= ((1.0f - fDist / 3.0f) + 1.0f);
            }
            data.fTempTurnForce = fDotR;
        }

        if (fDist < data.fDeSpeedRange)
        {
            if (data.speed > 1.0f)
            {
                data.fMoveForce = -(1.0f - fDist / data.fDeSpeedRange) * 1000.0f;
            }
            else
            {
                data.fMoveForce = fDotF * 100.0f;
            }
        }
        else
        {
            data.fMoveForce = fDotF * 100.0f;
        }

        data.bMove = true;
        return true;
    }

    private static object FindObjectOfType<T>()
    {
        throw new System.NotImplementedException();
    }

}