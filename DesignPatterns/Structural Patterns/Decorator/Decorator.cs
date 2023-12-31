﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural_Patterns.Decorator;


// Базовый класс Декоратора следует тому же интерфейсу, что и другие
// компоненты. Основная цель этого класса - определить интерфейс обёртки для
// всех конкретных декораторов. Реализация кода обёртки по умолчанию может
// включать в себя  поле для хранения завёрнутого компонента и средства его
// инициализации.
abstract class Decorator : Component
{
    protected Component _component;

    public Decorator(Component component)
    {
        this._component = component;
    }

    public void SetComponent(Component component)
    {
        this._component = component;
    }

    // Декоратор делегирует всю работу обёрнутому компоненту.
    public override string Operation()
    {
        if (this._component != null)
        {
            return this._component.Operation();
        }
        else
        {
            return string.Empty;
        }
    }
}

// Конкретные Декораторы вызывают обёрнутый объект и изменяют его результат
// некоторым образом.
class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(Component comp) : base(comp)
    {
    }

    // Декораторы могут вызывать родительскую реализацию операции, вместо
    // того, чтобы вызвать обёрнутый объект напрямую. Такой подход упрощает
    // расширение классов декораторов.
    public override string Operation()
    {
        return $"ConcreteDecoratorA({base.Operation()})";
    }
}

// Декораторы могут выполнять своё поведение до или после вызова обёрнутого
// объекта.
class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(Component comp) : base(comp)
    {
    }

    public override string Operation()
    {
        return $"ConcreteDecoratorB({base.Operation()})";
    }
}