# <p align="center"> Edit Collider Button </p>

**Description**
: An easy way to add the "Edit Collider" button from the Collider components, to any custom script.

**Preview**
: <img src="https://raw.githubusercontent.com/blindeyethe/Unity-Edit-Collider-Button/main/Docs/1.png" width="480">

**The class field name provides the label**
 : <img src="https://raw.githubusercontent.com/blindeyethe/Unity-Edit-Collider-Button/main/Docs/2.png" width="480">

## <p align="center"> How to use </p>

### 1. Create a `[SerializeField] private bool` field

```cs
using UnityEngine;

public class MyScript : MonoBehaviour
{
    [SerializeField] private bool editCollider;
}
```

### 2. Create an Editor script

```cs
using UnityEditor;

[CustomEditor(typeof(MyScript))]
public class MyScriptEditor : Editor
{ 
}
```

### 3. Create a `SerializedProperty` from the field

```cs
using UnityEditor;

[CustomEditor(typeof(MyScript))]
public class MyScriptEditor : Editor
{
    private SerializedProperty _editColliderProperty;

    private void OnEnable()
    {
        _editColliderProperty = serializedObject.FindProperty("editCollider");
    }

    public override void OnInspectorGUI()
    {     
        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
    }
}
```

### 4. Call `Helpers.DrawEditButton()` and pass the `SerializedProperty`

```cs
using UnityEditor;
using TheBlindEye.EditorExtensions;

[CustomEditor(typeof(MyScript))]
public class MyScriptEditor : Editor
{
    private SerializedProperty _editColliderProperty;

    private void OnEnable()
    {
        _editColliderProperty = serializedObject.FindProperty("editCollider");
    }

    public override void OnInspectorGUI()
    {     
        Helpers.DrawEditButton(_editColliderProperty);
        
        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
    }
}
```
