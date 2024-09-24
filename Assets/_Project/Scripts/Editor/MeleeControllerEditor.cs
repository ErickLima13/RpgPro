using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MeleeController))]
public class MeleeControllerEditor : Editor
{
    private void OnSceneGUI()
    {
        MeleeController meleeController = (MeleeController)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(meleeController.hitPivot.position,
            Vector3.up,Vector3.forward,360 , meleeController.radius);

        Vector3 angleA = meleeController.DirForAngle(
            -meleeController.hitAngle / 2);
        Vector3 angleB = meleeController.DirForAngle(
         meleeController.hitAngle / 2);

        Handles.color = Color.red;
        Handles.DrawLine(meleeController.hitPivot.position,
            meleeController.hitPivot.position + angleA * meleeController.radius );
        Handles.DrawLine(meleeController.hitPivot.position,
    meleeController.hitPivot.position + angleB * meleeController.radius);
    }
}
