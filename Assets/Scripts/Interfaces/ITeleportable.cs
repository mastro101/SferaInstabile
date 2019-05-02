using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITeleportable
{
    GameObject gameObject { get; }
    Transform transform { get; }
    Rigidbody rigidbody { get; }

    bool CanJump { get; set; }
    float JumpForce { get; }
}
