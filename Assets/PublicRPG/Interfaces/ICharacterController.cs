using UnityEngine;

namespace PublicRPG.Interfaces
{
    /// <summary>
    /// Interface for character controller integration
    /// </summary>
    public interface ICharacterController
    {
        /// <summary>
        /// Move the character in a direction
        /// </summary>
        void Move(Vector3 direction);
        
        /// <summary>
        /// Make character jump
        /// </summary>
        void Jump();
        
        /// <summary>
        /// Enable or disable character movement
        /// </summary>
        void EnableMovement(bool enabled);
        
        /// <summary>
        /// Check if character is grounded
        /// </summary>
        bool IsGrounded { get; }
        
        /// <summary>
        /// Get current velocity
        /// </summary>
        Vector3 Velocity { get; }
        
        /// <summary>
        /// Get current position
        /// </summary>
        Vector3 Position { get; }
        
        /// <summary>
        /// Set character position (teleport)
        /// </summary>
        void SetPosition(Vector3 position);
    }
}