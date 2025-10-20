namespace PublicRPG.Interfaces
{
    /// <summary>
    /// Interface for inventory system integration
    /// </summary>
    public interface IInventoryProvider
    {
        /// <summary>
        /// Add an item to inventory
        /// </summary>
        bool AddItem(string itemId, int quantity = 1);
        
        /// <summary>
        /// Remove an item from inventory
        /// </summary>
        bool RemoveItem(string itemId, int quantity = 1);
        
        /// <summary>
        /// Check if inventory contains an item
        /// </summary>
        bool HasItem(string itemId, int quantity = 1);
        
        /// <summary>
        /// Get quantity of a specific item
        /// </summary>
        int GetItemQuantity(string itemId);
        
        /// <summary>
        /// Equip an item to a slot
        /// </summary>
        bool EquipItem(string itemId, string slotName);
        
        /// <summary>
        /// Unequip an item from a slot
        /// </summary>
        bool UnequipItem(string slotName);
        
        /// <summary>
        /// Get currently equipped item in a slot
        /// </summary>
        string GetEquippedItem(string slotName);
    }
}