Now you can use it like in the example below
``CSharp
builder = new ContainerBuilder();
builder.DefineType<IBaseObject>().As<BaseObject>();
var container = builder.Build();
IBaseObject baseObject = container.Resolve<IBaseObject>();
``