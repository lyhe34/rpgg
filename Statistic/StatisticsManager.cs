using System.Collections.Generic;
using UnityEngine;

namespace RPGG
{
	public class StatisticsManager : MonoBehaviour
	{
		public List<Statistic> statistics = new();

		public PriorityList<Alter> alters = new();

		public List<StatisticModification> timedModifications = new();

		public TimersManager timersManager;

		public void Awake()
		{
			timersManager = gameObject.GetOrAddComponent<TimersManager>();
		}

		public void AddTimedModification(StatisticModification modification)
		{
			if (modification.timer != null && timersManager)
			{
				timersManager.AddTimer(modification.timer, true);
				timedModifications.Add(modification);
			}
			else
			{
				Debug.Log($"{modification.timer} is null.");
			}
		}

		public void RemoveTimedModification(StatisticModification modification)
		{
			if (modification.timer != null && timersManager)
			{
				timersManager.RemoveTimer(modification.timer);
				timedModifications.Remove(modification);
			}
			else
			{
				Debug.Log($"{modification.timer} is null.");
			}
		}
	}
}
