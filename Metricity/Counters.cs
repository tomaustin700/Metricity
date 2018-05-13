using Metricity.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity
{
    public static class Counters
    {
        private static List<CounterInfo> _activeCounters = new List<CounterInfo>();

        public static void Increment(string counterName, string subset = "")
        {
            if (!_activeCounters.Any(x => x.Name == counterName))
                _activeCounters.Add(new CounterInfo() { Name = counterName, SubSetName = subset });
            else
                _activeCounters.Single(x => x.Name == counterName).Count++;
        }

        public static void Decrement(string counterName, string subset = "")
        {
            if (!_activeCounters.Any(x => x.Name == counterName))
                throw new InvalidOperationException("A counter for " + counterName + " is not being monitored");
            else if (_activeCounters.Single(x => x.Name == counterName).Count == 0)
                throw new InvalidOperationException(counterName + " is already at zero");
            else
                _activeCounters.Single(x => x.Name == counterName).Count--;
        }

        public static void ClearCounter(string counterName, string subset = "")
        {
            if (string.IsNullOrEmpty(subset))
            {
                if (!_activeCounters.Any(x => x.Name == counterName))
                    throw new InvalidOperationException("A counter for " + counterName + " is not being monitored");
                else
                    _activeCounters.Remove(_activeCounters.Single(x => x.Name == counterName));
            }
            else
            {
                if (!_activeCounters.Any(x => x.Name == counterName && x.SubSetName == subset))
                    throw new InvalidOperationException("A counter for " + counterName + " (" + subset + ") " + " is not being monitored");
                else
                    _activeCounters.Remove(_activeCounters.Single(x => x.Name == counterName && x.SubSetName == subset));

            }
        }

        public static void PurgeCounters()
        {
            _activeCounters = new List<CounterInfo>();
        }

        public static List<SubsetSplit> GetSubsetSplit(string counterName)
        {
            var split = new List<SubsetSplit>();
            if (!_activeCounters.Any(x => x.Name == counterName))
                throw new InvalidOperationException("A counter for " + counterName + " is not being monitored");

            if (_activeCounters.All(x => x.Name == counterName && string.IsNullOrEmpty(x.SubSetName)))
                throw new InvalidOperationException("No subsets have been recored for " + counterName);

            var total = _activeCounters.Where(x => x.Name == counterName && !string.IsNullOrEmpty(x.SubSetName)).Sum(y => y.Count);
            foreach (var subset in _activeCounters.Where(x => x.Name == counterName && !string.IsNullOrEmpty(x.SubSetName)))
            {
                split.Add(new SubsetSplit() { CounterName = subset.Name, SubsetName = subset.SubSetName, Percentage = subset.Count * 100 / total });
            }

            return split;
        }

        public static int GetCurrentCount(string counterName, string subset = "")
        {
            if (string.IsNullOrEmpty(subset))
            {
                if (!_activeCounters.Any(x => x.Name == counterName))
                    throw new InvalidOperationException("A counter for " + counterName + " is not being monitored");
                else
                    return _activeCounters.Single(x => x.Name == counterName).Count;
            }
            else
            {
                if (!_activeCounters.Any(x => x.Name == counterName && x.SubSetName == subset))
                    throw new InvalidOperationException("A counter for " + counterName + " (" + subset + ") " + " is not being monitored");
                else
                    return _activeCounters.Single(x => x.Name == counterName && x.SubSetName == subset).Count;
            }
        }

    }
}
