using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public interface IServiceFabric
{
    T InitSingle<T>() where T : class;
    public T InitMultiple<T>() where T : class;
}

public class ServiceFabric: IServiceFabric
{
    private readonly DiContainer _container;

    [Inject]
    public ServiceFabric(DiContainer container)
    {
        _container = container;
    }

    public T InitSingle<T>() where T : class
    {
        T instance = _container.TryResolve<T>();
        // ���� ��������� �� ������, �� ������ � ������� �����
        if (instance == null)
        {
            _container.Bind<T>().AsSingle(); // ����� ������������ ������ ���� �������� � ����������� �� ������ ������
            instance = _container.Resolve<T>();
        }
        return instance;
    }

    public T InitMultiple<T>() where T : class => _container.Instantiate<T>();
}

