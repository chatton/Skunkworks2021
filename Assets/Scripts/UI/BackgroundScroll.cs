using System;
using UnityEngine;

namespace UI
{
    public class BackgroundScroll : MonoBehaviour
    {
        [SerializeField] private float scrollSpeed = 0.5f;

        private Health _playerHealth;

        private void Start()
        {
            _playerHealth = FindObjectOfType<Player>().GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_playerHealth.IsDead)
            {
                return;
            }

            Vector2 offset = new Vector2(Time.time * scrollSpeed, 0);
            GetComponent<Renderer>().material.mainTextureOffset = offset;
        }
    }
}