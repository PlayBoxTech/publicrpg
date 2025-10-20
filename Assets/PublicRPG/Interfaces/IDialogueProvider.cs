namespace PublicRPG.Interfaces
{
    /// <summary>
    /// Interface for dialogue system integration
    /// </summary>
    public interface IDialogueProvider
    {
        /// <summary>
        /// Start a conversation by name/ID
        /// </summary>
        void StartConversation(string conversationId);
        
        /// <summary>
        /// Stop the current conversation
        /// </summary>
        void StopConversation();
        
        /// <summary>
        /// Check if a conversation is currently active
        /// </summary>
        bool IsConversationActive { get; }
        
        /// <summary>
        /// Set a dialogue variable (for branching logic)
        /// </summary>
        void SetVariable(string variableName, object value);
        
        /// <summary>
        /// Get a dialogue variable value
        /// </summary>
        T GetVariable<T>(string variableName);
        
        /// <summary>
        /// Check if a specific conversation has been played
        /// </summary>
        bool HasPlayedConversation(string conversationId);
    }
}