using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private Bone[] ragdoll;

    private void Start()
    {
        var colls = GetComponentsInChildren<Collider>();
        ragdoll = new Bone[colls.GetLength(0)];

        for (int i = 0; i < ragdoll.GetLength(0); ++i)
        {
            ragdoll[i].coll = colls[i];
            ragdoll[i].rb = colls[i].GetComponent<Rigidbody>();

            ragdoll[i].coll.enabled = false;
            ragdoll[i].rb.useGravity = false;
            ragdoll[i].rb.isKinematic = true;
        }
    }

    public void ActivateRagdoll()
    {
        foreach (var bone in ragdoll)
        {
            bone.coll.enabled = true;
            bone.rb.useGravity = true;
            bone.rb.isKinematic = false;
        }
    }

    struct Bone
    {
        public Collider coll;
        public Rigidbody rb;
    }
}
