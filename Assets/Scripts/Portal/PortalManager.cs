using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PortalManager
{
    public static int MaxPortalInLevel { get { return 2; } }

    static List<Portal> portals = new List<Portal>();

    public static void AddPortal(Portal _portal)
    {
        portals.Add(_portal);
        if (portals.Count > MaxPortalInLevel)
        {
            Portal portalToRemove = portals[0];
            portals.Remove(portalToRemove);
            Object.Destroy(portalToRemove.gameObject);

            Debug.Log(portals[0].gameObject);
        }
    }

    public static void Teleport(Portal startPortal, ITeleportable teleportable)
    {
        Portal endPortal = null;
        foreach (Portal portal in portals)
        {
            if (portal != startPortal)
            {
                endPortal = portal;
                break;
            }
        }
        endPortal.CanTeleport = false;

        //Teletrasporto
        Transform teleportableT = teleportable.transform;
        Rigidbody teleportableRB = teleportable.rigidbody;

        teleportableT.position = endPortal.transform.position;
        teleportableRB.velocity = new Vector3(teleportableRB.velocity.x, 0, teleportableRB.velocity.z);
        teleportableRB.AddForce(Vector3.up * teleportable.JumpForce);
        //

        teleportable.CanJump = true;
    }
}
