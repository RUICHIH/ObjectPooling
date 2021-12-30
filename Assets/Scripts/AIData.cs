using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AIData
{
    public float fRadius;
    public float fProbeLength;
    public float speed;
    public float fMaxSpeed;
    public float fDeSpeedRange;
    public float fRot;
    public float fMaxRot;
    public GameObject Action;

    [HideInInspector]
    public Vector3 vTarget;
    [HideInInspector]
    public Vector3 vCurrentVector;
    [HideInInspector]
    public float fTempTurnForce;
    [HideInInspector]
    public float fMoveForce;
    [HideInInspector]
    public bool bMove;

    [HideInInspector]
    public bool bCol;
}
