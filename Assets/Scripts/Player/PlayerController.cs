using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour , ITeleportable
{
    [SerializeField] PlayerData data;

    public Rigidbody rigidbody { get { return GetComponent<Rigidbody>(); } }

    [SerializeField] KeyCode Left, Right, jumpKey;

    [SerializeField] GameObject portalGO;

    public bool CanJump { get; set; }

    public float JumpForce { get { return data.JumpForce; } }

    private void Update()
    {
        if (Input.GetKey(Left))
        {
            transform.position += Vector3.left * data.Speed;
        }
        if (Input.GetKey(Right))
        {
            transform.position += Vector3.right * data.Speed;
        }

        if (Input.GetKeyDown(jumpKey))
        {
            if (CanJump)
                jump();
        }
    }

    void jump()
    {
        CanJump = false;
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
        rigidbody.AddForce(Vector3.up * JumpForce);
        Instantiate(portalGO, transform.position, Quaternion.Euler(Vector3.zero)).GetComponent<Portal>().CanTeleport = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            CanJump = true;
        }
    }
}
