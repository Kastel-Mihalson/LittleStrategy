using Abstractions;
using System;
using UniRx;
using UnityEngine;
using Zenject;

public class TimeModel : ITimeModel, ITickable
{
    private readonly ReactiveProperty<float> _gameTime = new ReactiveProperty<float>();

    public IObservable<int> GameTime => _gameTime.Select(f => (int)f);

    public void Tick() => _gameTime.Value += Time.deltaTime;
}
