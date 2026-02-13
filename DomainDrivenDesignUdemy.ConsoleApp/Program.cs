using MediatR;

namespace DomainDrivenDesignUdemy.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        //Guid id = Guid.NewGuid();
        //A a1 = new A(id);
        //A a2 = new A(id);
        //Console.WriteLine(a1.Equals(a2)); // true, because they have the same Id

        //BenchmarkRunner.Run<BenchMarkService>();

        //Order order = new Order();
        //order.CreateOrder(1, "Muz");
        //order.CreateOrder(2, "Elma");
        //order.CreateOrder(3, "Armut");

        //DomainEventDispatcher.Dispatch(order.DomainEvents);
        Console.ReadLine();
    }
}

#region DomainEvents : Domain events are a way to represent something that has happened in the domain that is of interest to other parts of the system. They are typically used to decouple different parts of the system and to allow for asynchronous processing of events. In this example, we have an Order class that has a CreateOrder method which creates an order and publishes a domain event (OrderCreatedEvent) when an order is created. The DomainEventDispatcher class is responsible for dispatching the domain events to the appropriate handlers. In this case, it simply writes a message to the console when an OrderCreatedEvent is dispatched.
public class Order
{
    private readonly IMediator _mediator;

    public Order(IMediator mediator)
    {
        _mediator = mediator;
    }

    public int Id { get; set; }
    public string ProductName { get; set; }
    public List<IDomainEvent> DomainEvents { get; } = new();
    public void CreateOrder(int id, string productName)
    {
        Id = id;
        ProductName = productName;
        // publish domain event
        //DomainEvents.Add(new OrderCreatedEvent(id));
        _mediator.Publish(new OrderCompletedEvent(id)); // it will automatically find the handlers for this event and execute them

    }
}

// MediaTr
public class StockUpdateHandler : INotificationHandler<OrderCompletedEvent>
{
    public Task Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
    {
        // update stock based on the order completed event
        return Task.CompletedTask;
    }
}

public class SendMailHandler : INotificationHandler<OrderCompletedEvent>
{
    public Task Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
    {
        // send email based on the order completed event
        return Task.CompletedTask;
    }
}

public class SendSMSHandler : INotificationHandler<OrderCompletedEvent>
{
    public Task Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
    {
        // send SMS based on the order completed event
        return Task.CompletedTask;
    }
}

public class OrderCompletedEvent : INotification
{
    public int Id { get; }
    public OrderCompletedEvent(int id)
    {
        Id = id;
    }
}



public static class DomainEventDispatcher
{
    public static void Dispatch(List<IDomainEvent> domainEvents)
    {
        foreach (var domainEvent in domainEvents)
        {
            if (domainEvent is OrderCreatedEvent orderCreatedEvent)
            {
                Console.WriteLine($"Order with Id {orderCreatedEvent.Id} has been created.");
            }
        }
    }
}

public interface IDomainEvent
{
}

public class OrderCreatedEvent : IDomainEvent
{
    public int Id { get; }
    public OrderCreatedEvent(int id)
    {
        Id = id;
    }
}
#endregion

public abstract class Entity : IEquatable<Entity> // can only be inherited
{
    public Guid Id { get; init; } // init only property, can only be set during object initialization
    public Entity(Guid id)
    {

        Id = id;
    }

    public override bool Equals(object? obj) // override the default implementation of Equals method to compare entities based on their Id because in DDD, entities are defined by their identity rather than their attributes
    {
        if (obj == null) return false;

        if (obj is not Entity entity) return false;

        if (obj.GetType() != GetType()) return false;

        return entity.Id == Id;
    }

    public override int GetHashCode() // override the default implementation of GetHashCode method to return the hash code of the Id property because in DDD, entities are defined by their identity rather than their attributes
    {
        return Id.GetHashCode();
    }

    public bool Equals(Entity? other)
    {
        if (other == null) return false;

        if (other is not Entity entity) return false;

        if (other.GetType() != GetType()) return false;

        return entity.Id == Id;
    }
}

class A : Entity
{
    public A(Guid id) : base(id)
    {
    }
}

class B : Entity
{
    public B(Guid id) : base(id)
    {
    }
}
