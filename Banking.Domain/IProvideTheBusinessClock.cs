﻿namespace Banking.Domain;

public interface IProvideTheBusinessClock
{
    bool IsDuringBusinessHour();
}