using UnityEngine;

namespace RPGG
{
    public class Timer
    {
        public Statistic duration;
        public float currentTime;
        public Reaction OnTimerEnd = new();
        public bool enabled = false;

        public Timer(Statistic duration)
        {
            this.duration = duration;
        }

        public virtual void Reset()
        {
            currentTime = 0;
        }

        public virtual void Update()
        {
			currentTime += Time.deltaTime;
        }

        public virtual void LateUpdate()
        {
			if (currentTime >= duration.Value)
			{
				End();
			}
		}

        public virtual void End()
        {
            if (enabled)
            {
                enabled = false;
                OnTimerEnd.Execute();
            }
        }
    }
}