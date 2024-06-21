using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "SO/TutorialInfo")]
public class TutorialObjectListSO : ScriptableObject
{
   public List<TutorialObject> _tutorialInfoList;
}
