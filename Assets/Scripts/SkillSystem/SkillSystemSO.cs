using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillSystem", menuName = "Scriptable Objects/SkillSystem/SkillSystem")]
public partial class SkillSystemSO : ScriptableObject
{
    public List<SkillSO> Skills;
}

