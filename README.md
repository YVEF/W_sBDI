Now you can use it like in the example below

```csharp
int main()
{
  builder = new ContainerBuilder();
  builder.DefineType<IBaseObject>().As<BaseObject>();
  var container = builder.Build();
  IBaseObject baseObject = container.Resolve<IBaseObject>();
  
  // or

  builder.DefineType<IBaseObject>().As<BaseObject>().SingleInstance();
  var container = builder.Build();
  IBaseObject baseObject1 = container.Resolve<IBaseObject>();
  IBaseObject baseObject2 = container.Resolve<IBaseObject>();
  bool equal = baseObject1.Equals(baseObject2); // true
}
```