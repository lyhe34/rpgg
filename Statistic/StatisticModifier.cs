using System.Collections.Generic;

namespace RPGG
{
	public class StatisticModifier
	{
		public Properties properties = new();

		public StatisticModifiersManager manager;

		public PriorityList<Alter> alters = new();

		public bool isStackable;
		public Statistic maximumStacks;

		public bool isTimed;
		public Statistic duration;

		public bool isPeriodic;
		public Statistic rate;

		public List<StatisticModification> timedModifications = new();

		public Reaction<StatisticModification> OnModify;

		public StatisticModifier(StatisticModifiersManager manager = null)
		{
			this.manager = manager;
		}

		public StatisticModifier Stackable(float maximumStacks, StatisticsManager manager = null)
		{
			isStackable = true;
			return this;
		}

		public StatisticModifier Stackable(Statistic maximumStacks)
		{
			isStackable = true;
			this.maximumStacks = maximumStacks;
			return this;
		}

		public StatisticModifier Timed(float duration)
		{
			isTimed = true;
			return this;
		}

		public StatisticModifier Timed(Statistic duration)
		{
			isTimed = true;
			this.duration = duration;
			return this;
		}

		public StatisticModifier Periodic(float duration, float rate)
		{
			Timed(duration);
			isPeriodic = true;

			return this;
		}

		public StatisticModifier Periodic(Statistic duration, Statistic rate)
		{
			Timed(duration);
			isPeriodic = true;
			this.rate = rate;
			return this;
		}

		public PriorityList<Alter> GetAlters()
		{
			PriorityList<Alter> alters = new();

			alters.Concat(this.alters);
			if(manager) alters.Concat(manager.alters);

			return alters;
		}
	}
}
