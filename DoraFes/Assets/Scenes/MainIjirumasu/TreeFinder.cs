using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFinder : MonoBehaviour
{
    void Start()
    {
        // Get all the transforms under this gameobject
        Transform[] allChildren = GetComponentsInChildren<Transform>();

        // Iterate over each transform
        foreach (Transform child in allChildren)
        {
            // Check if the name of the gameObject starts with "TreeCubeSpring"
            if (child.name.StartsWith("Tree_"))
            {
                // Get the TreeSwing component
                TreeSwing treeSwing = child.GetComponent<TreeSwing>();

                // If the TreeSwing component exists
                if (treeSwing != null)
                {
                    // Start the tree swing
                    treeSwing.Start();
                }
            }
        }
    }
}
