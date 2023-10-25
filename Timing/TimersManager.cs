using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RPGG
{
    public class TimersManager : MonoBehaviour
    {
	    private List<Timer> timers = new();

		private void Update()
		{
			foreach (var timer in timers.ToList())
			{
				if (timer.enabled)
				{
					timer.Update();
					timer.LateUpdate();
				}
			}
		}

		/// <summary>
		/// Add a <see cref="Timer"/> to be managed.
		/// </summary>
		/// <param name="timer">The timer to be managed.</param>
		/// <param name="start">If the <paramref name="timer"/> should be started once added.</param>
		public void AddTimer(Timer timer, bool start)
		{
			timers.Add(timer);
			if(start) timer.enabled = true;
		}

		public void RemoveTimer(Timer timer)
		{
			timers.Remove(timer);
		}

		public void EndTimer(Timer timer)
		{
			timers.Find(t => t == timer).End();
			timers.Remove(timer);
		}
	}
}