using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Rotate))]
public class RotateEditor : Editor
{

    //This editor script is added to see the changes applied after the user presses "apply changes" button. It also helps to ensure that changes that are made are serialized correctly.
    public override void OnInspectorGUI()
    {
        Rotate rotateScript = (Rotate)target;

        rotateScript.orbitTarget = (Transform)EditorGUILayout.ObjectField("Orbit Target", rotateScript.orbitTarget, typeof(Transform), true);
        rotateScript.distanceFromTarget = EditorGUILayout.FloatField("Distance from Target", rotateScript.distanceFromTarget);
        rotateScript.orbitSpeed = EditorGUILayout.FloatField("Orbit Speed", rotateScript.orbitSpeed);
        rotateScript.selfRotationSpeed = EditorGUILayout.FloatField("Self Rotation Speed", rotateScript.selfRotationSpeed);
        rotateScript.radius = EditorGUILayout.FloatField("Radius", rotateScript.radius);

        if (GUILayout.Button("Apply Changes"))
        {
            Vector3 offset = rotateScript.transform.position - rotateScript.orbitTarget.position;
            offset = offset.normalized * rotateScript.distanceFromTarget;
            rotateScript.transform.position = rotateScript.orbitTarget.position + offset;
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(rotateScript);
        }
    }
}
