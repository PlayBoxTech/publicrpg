namespace PublicRPG.Interfaces
{
    /// <summary>
    /// Interface for quest system integration
    /// </summary>
    public interface IQuestProvider
    {
        /// <summary>
        /// Start a quest by ID
        /// </summary>
        void StartQuest(string questId);
        
        /// <summary>
        /// Complete a quest
        /// </summary>
        void CompleteQuest(string questId);
        
        /// <summary>
        /// Fail a quest
        /// </summary>
        void FailQuest(string questId);
        
        /// <summary>
        /// Update quest progress (kill count, collect items, etc.)
        /// </summary>
        void UpdateQuestNode(string questId, string nodeId);
        
        /// <summary>
        /// Check if a quest is currently active
        /// </summary>
        bool IsQuestActive(string questId);
        
        /// <summary>
        /// Check if a quest has been completed
        /// </summary>
        bool IsQuestCompleted(string questId);
        
        /// <summary>
        /// Get list of all active quests
        /// </summary>
        string[] GetActiveQuests();
    }
}