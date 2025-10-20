namespace PublicRPG.Interfaces
{
    /// <summary>
    /// Interface for save/load system integration
    /// </summary>
    public interface ISaveProvider
    {
        /// <summary>
        /// Save game to a specific slot
        /// </summary>
        void Save(string saveSlot);
        
        /// <summary>
        /// Load game from a specific slot
        /// </summary>
        void Load(string saveSlot);
        
        /// <summary>
        /// Delete a save slot
        /// </summary>
        void DeleteSave(string saveSlot);
        
        /// <summary>
        /// Check if a save slot exists
        /// </summary>
        bool SaveExists(string saveSlot);
        
        /// <summary>
        /// Get list of all save slots
        /// </summary>
        string[] GetSaveSlots();
        
        /// <summary>
        /// Auto-save (quicksave)
        /// </summary>
        void AutoSave();
    }
}