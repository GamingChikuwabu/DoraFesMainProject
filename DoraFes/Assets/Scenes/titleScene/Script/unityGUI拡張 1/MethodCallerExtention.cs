using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteAlways]
public class MethodCallerExtention : MonoBehaviour
{
    public List<UnityEvent> OnEvent;

    public void Action(int id)
    {
        OnEvent[id]?.Invoke();
    }

    public void PublicMethod()
    {
        Debug.Log("PublicMethod");
    }

    private void PrivateMethod()
    {
        Debug.Log("PrivateMethod");
    }
}

#if UNITY_EDITOR
    [ExecuteAlways]
    [CustomEditor(typeof(MethodCallerExtention))]
    public class MethodCallerEditorExtention : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            MethodCallerExtention t = target as MethodCallerExtention;
            if (t == null) return;
            if (t.OnEvent == null) return;

            if (GUILayout.Button("PublicMethod"))
            {
                t.PublicMethod();
            }

            if (GUILayout.Button("PrivateMethod"))
            {
                t.SendMessage("PrivateMethod", null, SendMessageOptions.DontRequireReceiver);
            }

            if (t.OnEvent.Count > 1)
            {
                for (int i = 0; i < t.OnEvent.Count; i++)
                {
                    if (t.OnEvent[i].GetPersistentEventCount() > 0 && t.OnEvent[i].GetPersistentMethodName(0).Length > 0)
                    {
                        if (GUILayout.Button(t.OnEvent[i].GetPersistentMethodName(0)))
                        {
                            t.Action(i);
                        }
                    }
                }
            }
        }
    }
#endif
