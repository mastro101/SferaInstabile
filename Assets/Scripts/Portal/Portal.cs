using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [HideInInspector] public bool CanTeleport = true;

    private void Awake()
    {
        PortalManager.AddPortal(this);
    }

    void Teleport(ITeleportable teleportable)
    {
        PortalManager.Teleport(this, teleportable);
    }

    private void OnTriggerEnter(Collider other)
    {
        ITeleportable teleportable = other.GetComponent<ITeleportable>();
        if (teleportable != null)
        {
            if (CanTeleport && teleportable.rigidbody.velocity.y <= 0)
                Teleport(teleportable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ITeleportable teleportable = other.GetComponent<ITeleportable>();
        if (teleportable != null)
        {
            if (!CanTeleport)
                CanTeleport = true;
        }
    }
}
