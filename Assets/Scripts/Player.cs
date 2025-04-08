using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Golf
{
    public class Player : MonoBehaviour
    {
        public Transform stick;
        private bool m_isDown = false;
        public float range = 50f;
        public float speed = 1000f;
        public float power = 20f;
        public Transform helper;

        private Vector3 m_lastPosition;
        private void Update()
        {
            m_lastPosition = helper.position;

            //m_isDown = Input.GetMouseButton(0);

            Quaternion rot = stick.localRotation;
            Quaternion toRot = Quaternion.Euler(0, 0, m_isDown ? range : -range);

            rot = Quaternion.RotateTowards(rot, toRot, speed * Time.deltaTime);
            stick.localRotation = rot;
        }

        public void SetDown(bool value)
        { 
            m_isDown=value;
        }

        private void Start()
        {
	        GameEvents.onCollisionStick += OnCollisionStick;
	        GameEvents.OnStateEnter += GameEventsOnOnStateEnter;
        }

        private void GameEventsOnOnStateEnter(GameState state)
        {
	        if (state is GamePlayState)
	        {
		        m_isDown = false;
	        }
        }

        private void OnDestroy()
        {
	        GameEvents.onCollisionStick -= OnCollisionStick;
        }

        private void OnCollisionStick(Collider collider)
        {
	        if (collider.TryGetComponent(out Rigidbody body))
	        {
		        //var dir = m_isDown ? stick.right : -stick.right;
		        var dir = (helper.position - m_lastPosition).normalized;
		        body.AddForce(dir * power, ForceMode.Impulse);
		        if (collider.TryGetComponent(out Stone stone) && !stone.isAffect)
		        {
			        stone.isAffect = true;
			        GameEvents.StickHit();
		        }
	        }
        }
    }

    
}