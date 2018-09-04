using System;
using System.Collections.Generic;

namespace FakeAutofac
{
    /*这个类先完成注册功能，然后提供build方法返回IContainer实例。
    build方法通过Container的构造函数将注册的类型集合传递给Container中集合变量
    Container构造函数同时对集合value，也就是resolver对象中委托进行赋值
    然后Container提供resove方法，生成所需的实例对象
    五个地方使用了反射resolver中RealType.GetConstructors()、constructors[0].Invoke(@params.ToArray())、parameterInfo.ParameterType、
    GetParameters()和当前类的_currentKey.GetInterfaces(),其实还有type
    这篇文章也有简单的di框架实现*/
    public class ContainerBuilder
    {
        //用来保存注册的类型
        private readonly Dictionary<Type, Resolver> _typePool = new Dictionary<Type, Resolver>();
        private Type _currentKey;

        public ContainerBuilder RegisterType<T> () where T:class
        {
            _currentKey = typeof (T);
            var resolver = new Resolver { RealType = _currentKey };
            _typePool[_currentKey] = resolver;

            return this;
        }


        public ContainerBuilder AsImplementedInterfaces()
        {
            //以接口为key, 对应Resolver
            var interfaces = _currentKey.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                _typePool[@interface] = _typePool[_currentKey];
            }
            return this;
        }

        //创建Container
        public IContainer Build()
        {
            var container = new Container(_typePool);

            return container;
        }
    }
}
