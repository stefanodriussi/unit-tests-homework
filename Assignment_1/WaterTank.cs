using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_1
{
    public class WaterTank
    {
        private double capacity;
        private double actualLevel;
        private Tap tap;

        public WaterTank(double unitsCapacity, double initialUnitsFilled = 0)
        {
            if (unitsCapacity < 0) throw new ArgumentException($"{nameof(unitsCapacity)} value must be great or equal than zero");
            capacity = unitsCapacity;

            if (initialUnitsFilled > unitsCapacity) throw new ArgumentException($"{nameof(initialUnitsFilled)} value must be less or equal than {nameof(unitsCapacity)}");
            actualLevel = initialUnitsFilled;
        }

        public WaterTank AttachTap(Tap tap)
        {
            this.tap = tap;
            return this;
        }

        public void Fill(double volume)
        {
            var availableVolume = capacity - actualLevel;
            var volumeToBeAdded = Math.Min(availableVolume, volume);
            actualLevel += volumeToBeAdded;
            if (capacity == actualLevel) throw new OverflowException($"Water tank is full: {volume - volumeToBeAdded} units lost");
        }

        public double OpenTapFor(TimeSpan duration)
        {
            var totalFlux = tap.OpenFor(duration);
            var spilledUnits = Math.Min(totalFlux, actualLevel);
            actualLevel = Math.Max(0, actualLevel - totalFlux);
            return spilledUnits;
        }

        public double ActualLevel => actualLevel;
    }
}
