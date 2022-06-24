#### There are two versions of Apis in the controller folder, v1 and v2. A normal approach has been implemented in the version 1 and in the version 2, strategy and factory patterns have been used to implement the calculator. 
##### Since Asp core IoC container does not allow to add different implementation of one interface, there is an extrax code to handle that.
```
 services.AddScoped(provider =>
            {
                var factory = (IMathStrategyFactory)provider.GetService(typeof(IMathStrategyFactory));
                return factory.Create();
            });
```
