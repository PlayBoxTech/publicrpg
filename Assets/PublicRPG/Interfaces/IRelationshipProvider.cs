namespace PublicRPG.Interfaces
{
    /// <summary>
    /// Interface for relationship/faction system integration (Love/Hate)
    /// </summary>
    public interface IRelationshipProvider
    {
        /// <summary>
        /// Modify relationship value with a faction/character
        /// </summary>
        void ModifyRelationship(string targetId, float amount);
        
        /// <summary>
        /// Get current relationship value with a faction/character
        /// </summary>
        float GetRelationship(string targetId);
        
        /// <summary>
        /// Set relationship to a specific value
        /// </summary>
        void SetRelationship(string targetId, float value);
        
        /// <summary>
        /// Check if relationship meets a threshold (for dialogue/quest gates)
        /// </summary>
        bool IsRelationshipAbove(string targetId, float threshold);
        
        /// <summary>
        /// Trigger a deed/action that affects relationships
        /// </summary>
        void CommitDeed(string deedId, string targetId);
    }
}