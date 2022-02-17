using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private Bone[] _ragdoll;

    private void Start()
    {
        var colls = GetComponentsInChildren<Collider>();
        _ragdoll = new Bone[colls.GetLength(0)];

        for (int i = 0; i < _ragdoll.GetLength(0); ++i)
        {
            _ragdoll[i].coll = colls[i];
            _ragdoll[i].rb = colls[i].GetComponent<Rigidbody>();

            _ragdoll[i].coll.enabled = false;
            _ragdoll[i].rb.useGravity = false;
            _ragdoll[i].rb.isKinematic = true;
        }
    }

    public void ActivateRagdoll()
    {
        foreach (var bone in _ragdoll)
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
