using System.Collections.Generic;
using UnityEngine;

namespace RPGG
{
	public class StatisticModifiersManager : MonoBehaviour
	{
		public List<StatisticModifier> modifiers = new();

		public PriorityList<Alter> alters = new();

		public Reaction<StatisticModification> OnModify;
	}
}
