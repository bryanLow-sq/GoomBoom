/*Done by: Shing Wei Hao (1400120J), P02
 * Coward AI scripts for Goom Boom
 */

using UnityEngine;
using System.Collections;

public interface IEnemyState
{
	void UpdateState(); // Method called to update current status in StatePattern script

	void Execute(); // State transitions are done in Execute()
}

