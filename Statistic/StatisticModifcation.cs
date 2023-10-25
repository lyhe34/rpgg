namespace RPGG
{
	/// <summary>
	/// Contains all the information when a <see cref="Statistic"/> is being modified by a <see cref="StatisticModifier"/>.
	/// </summary>
	public class StatisticModification
	{
		/// <summary>
		/// The amount of the modification after being altered and clamped.
		/// </summary>
		public float amount;

		/// <summary>
		/// If this modification is periodic, records the total modification amount over time.
		/// </summary>
		/// <returns>float</returns>
		public float totalAmount;

		/// <summary>
		/// Stores only the modifier's modification amount, before being altered by the <see cref="Statistic"/>.
		/// </summary>
		public float unalteredAmount;

		/// <summary>
		/// If this modification is periodic, records the total unaltered amount over time.
		/// </summary>
		public float totalUnalteredAmount;

		/// <summary>
		/// Stores the amount before being clamped by minimum <see cref="Statistic"/> and maximum <see cref="Statistic"/>.
		/// </summary>
		public float unclampedAmount;

		/// <summary>
		/// The <see cref="Statistic"/> this modification is modifying.
		/// </summary>
		public Statistic statistic;
		
		/// <summary>
		/// The modifier that have applied the modification.
		/// </summary>
		/// <returns><see cref="StatisticModifier"/></returns>
		public StatisticModifier modifier;

		/// <summary>
		/// Returns a <see cref="Timer"/> if this modification is timed.
		/// </summary>
		public Timer timer;

		/// <summary>
		/// Returns a <see cref="Stacks"/> if this modification has been stacked.
		/// </summary>
		public Stacks stacks;

		public void Reset()
		{
			amount = 0;
			unalteredAmount = 0;
			unclampedAmount = 0;
		}

		public StatisticModification(Statistic statistic, StatisticModifier modifier = null, Stacks stacks = null, Timer timer = null)
		{
			this.statistic = statistic;
			this.modifier = modifier;
			this.stacks = stacks;
			this.timer = timer;
		}
	}
}
