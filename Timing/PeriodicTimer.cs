using UnityEngine;

namespace RPGG
{
	public class PeriodicTimer : Timer
	{
		public Statistic rate;
		public float nextTick;
		public int ticks;
		public Reaction OnUpdate = new();

		public PeriodicTimer(Statistic duration, Statistic rate) : base(duration)
		{
			this.rate = rate;
		}

		public override void Reset()
		{
			base.Reset();
			nextTick = 0;
		}

		public override void Update()
		{
			base.Update();

			while (currentTime >= nextTick)
			{
				OnUpdate.Execute();
				nextTick += rate.Value;
				ticks++;
			}
		}
	}
}