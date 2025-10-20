#if QUEST_MACHINE_INSTALLED
using PixelCrushers.QuestMachine;
#endif
using PublicRPG.Interfaces;
using System.Collections.Generic;

namespace PublicRPG.Adapters
{
    /// <summary>
    /// Adapter for Pixel Crushers Quest Machine
    /// </summary>
    public class QuestMachineAdapter : IQuestProvider
    {
#if QUEST_MACHINE_INSTALLED
        public void StartQuest(string questId)
        {
            Quest quest = QuestMachine.GetQuestInstance(questId);
            if (quest != null)
            {
                // Quest Machine uses SetState instead of StartQuest
                quest.SetState(QuestState.Active);
            }
            else
            {
                UnityEngine.Debug.LogWarning($"Quest not found: {questId}");
            }
        }

        public void CompleteQuest(string questId)
        {
            Quest quest = QuestMachine.GetQuestInstance(questId);
            if (quest != null)
            {
                quest.SetState(QuestState.Successful);
            }
            else
            {
                UnityEngine.Debug.LogWarning($"Quest not found: {questId}");
            }
        }

        public void FailQuest(string questId)
        {
            Quest quest = QuestMachine.GetQuestInstance(questId);
            if (quest != null)
            {
                quest.SetState(QuestState.Failed);
            }
            else
            {
                UnityEngine.Debug.LogWarning($"Quest not found: {questId}");
            }
        }

        public void UpdateQuestNode(string questId, string nodeId)
        {
            // Use Quest Machine's message system to update quest nodes
            QuestMachineMessages.RefreshIndicators(questId);
        }

        public bool IsQuestActive(string questId)
        {
            Quest quest = QuestMachine.GetQuestInstance(questId);
            return quest != null && quest.GetState() == QuestState.Active;
        }

        public bool IsQuestCompleted(string questId)
        {
            Quest quest = QuestMachine.GetQuestInstance(questId);
            return quest != null && quest.GetState() == QuestState.Successful;
        }

        public string[] GetActiveQuests()
        {
            List<string> activeQuests = new List<string>();
            
            // Get the quest journal (assumes there's a QuestJournal in the scene)
            var journal = UnityEngine.Object.FindObjectOfType<QuestJournal>();
            if (journal != null)
            {
                foreach (var quest in journal.questList)
                {
                    if (quest.GetState() == QuestState.Active)
                    {
                        activeQuests.Add(quest.id.value);
                    }
                }
            }
            
            return activeQuests.ToArray();
        }
#else
        // Stub implementations when Quest Machine not installed
        public void StartQuest(string questId)
        {
            UnityEngine.Debug.LogWarning("Quest Machine not installed. Cannot start quest: " + questId);
        }

        public void CompleteQuest(string questId)
        {
            UnityEngine.Debug.LogWarning("Quest Machine not installed. Cannot complete quest: " + questId);
        }

        public void FailQuest(string questId)
        {
            UnityEngine.Debug.LogWarning("Quest Machine not installed. Cannot fail quest: " + questId);
        }

        public void UpdateQuestNode(string questId, string nodeId)
        {
            UnityEngine.Debug.LogWarning("Quest Machine not installed.");
        }

        public bool IsQuestActive(string questId)
        {
            return false;
        }

        public bool IsQuestCompleted(string questId)
        {
            return false;
        }

        public string[] GetActiveQuests()
        {
            return new string[0];
        }
#endif
    }
}