using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Golf
{
    public static class GameEvents
    {
        public static event Action onCollisionStones;
        public static event Action onStickHit;
        public static event Action<Collider> onCollisionStick;
        public static event Action<GameState> OnStateEnter;
        public static event Action<GameState> OnStateExit;
        
        public static void CollisonStonesInvoke(Collision collision)
        { 
            onCollisionStones?.Invoke();
        }

        public static void StickHit()
        {
            onStickHit?.Invoke();
        }

        public static void CollisionStick(Collider collider)
        {
	        onCollisionStick?.Invoke(collider);
        }

        public static void EnterState(GameState state)
        {
	        OnStateEnter?.Invoke(state);
        }

        public static void ExitState(GameState state)
        {
	        OnStateExit?.Invoke(state);
        }

    }
}