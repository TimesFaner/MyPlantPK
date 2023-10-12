using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlantPK
{
    public class PlayerControl : MonoBehaviour
    {
        public Rigidbody2D rb;
        public Vector2 getInput;
        public float moveSpeed;
        public MoveInput moveInput;
        public MoveInput.PlayerActions playerActions { get; private set; }


        private void OnEnable()
        {
            moveInput.Enable();
        }
        private void OnDisable()
        {
            moveInput.Disable();
        }

        private void Awake()
        {
            moveInput = new MoveInput();
            playerActions = moveInput.Player;
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            getInput = moveInput.Player.Move.ReadValue<Vector2>();
            rb.velocity = getInput * moveSpeed;//…Ë±∏  ”¶*Time.deltaTime;
        }

    }
}
