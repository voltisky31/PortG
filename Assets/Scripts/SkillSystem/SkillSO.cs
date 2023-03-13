using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Scriptable Objects/SkillSystem/Skill")]
public partial class SkillSO : ScriptableObject, IActivable
{
    #region SkillUnlockRequirements
    [System.Serializable]
    public class SkillUnlockRequirements
    {
        public int Experience;
        public int Gold;
        public List<SkillSO> UnlockedSkillsRequired;

        public bool AllRequiredSkillUnlocked()
        {
            for (int i = 0; i < UnlockedSkillsRequired.Count; i++)
                if (!UnlockedSkillsRequired[i].IsActive)
                    return false;

            return true;
        }
    }
    #endregion

    public SkillUnlockRequirements UnlockRequirements;
    [field: SerializeField] public bool IsActive { get; set; }
}