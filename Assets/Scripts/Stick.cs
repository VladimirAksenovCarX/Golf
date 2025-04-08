using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Golf
{
    public class Stick : MonoBehaviour
    {
	    // unity event doesn't work correctly due to caching arg bug !
        private void OnCollisionEnter(Collision collision)
        {
            GameEvents.CollisionStick(collision.collider);
        }
    }
}