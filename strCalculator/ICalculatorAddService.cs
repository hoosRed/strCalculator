﻿using System;
namespace strCalculator
{
    /// <summary>
    ///     Marker interface for Add Service
    /// </summary>
    public interface ICalculatorAddService
    {
        string Execute(string input, bool includeNegatives = false, int maxValue = 1000);
    }
}
