using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_1
{
    public class Tap
    {
        private double unitsFlowPerMinute;
        public Tap(double unitsFlowPerMinute)
        {
            if (unitsFlowPerMinute < 0) throw new ArgumentException($"{nameof(unitsFlowPerMinute)} value must be great or equal than zero");
            this.unitsFlowPerMinute = unitsFlowPerMinute;
        }

        public double OpenFor(TimeSpan interval) => interval.TotalMinutes * unitsFlowPerMinute;
    }
}
