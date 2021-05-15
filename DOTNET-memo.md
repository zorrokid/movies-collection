
## 15.3.

Migrations

dotnet ef migrations add MigrationName

## 20.2.

DI : https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection

- https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-guidelines

* Avoid stateful, static classes and members. Avoid creating global state by designing apps to use singleton services instead.
* Avoid direct instantiation of dependent classes within services. Direct instantiation couples the code to a particular implementation.
* Make services small, well-factored, and easily tested.

If a class has many injected dependencies, it might be a sign that the class has too many responsibilities and violates the Single Responsibility Principle (SRP).


Services can be registered with one of the following lifetimes:

Transient: Transient lifetime services are created each time they're requested from the service container.
Scoped: For web applications, a scoped lifetime indicates that services are created once per client request (connection). Register scoped services with AddScoped.
Singleton: Every subsequent request of the service implementation from the dependency injection container uses the same instance.



