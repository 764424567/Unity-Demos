using UnityEngine;
using UnityEditor;

public class CustomWireMenuTool
{
    [MenuItem("GameObject/CustomWire/Create A New Wire", priority = 0)]
    private static void CreateNewCustomWire()
    {
        GameObject wire = new GameObject("CustomWire");
        Undo.RegisterCreatedObjectUndo(wire, "Create A New Wire");

        GameObject line = new GameObject("Line");
        line.transform.parent = wire.transform;
        line.transform.localPosition = Vector3.zero;
        LineRenderer lineComponent = line.AddComponent<LineRenderer>();
        lineComponent.positionCount = 0;
        lineComponent.startWidth = 0.01f;
        lineComponent.endWidth = 0.01f;

        CustomWire wireComponent = wire.AddComponent<CustomWire>();
        wireComponent.lineRenderer = lineComponent;
        wireComponent.setOnUpdate = true;
        wireComponent.drawNodes = true;

        Selection.activeGameObject = wire;
    }
}