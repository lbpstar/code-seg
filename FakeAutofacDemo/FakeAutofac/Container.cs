using System;
using System.Collections.Generic;

namespace FakeAutofac
{
    public class Container : IContainer
    {
        //用来保存注册的类型
        private readonly Dictionary<Type, Resolver> _typePool = new Dictionary<Type, Resolver>();

        public Container(Dictionary<Type, Resolver> typePool)
        {
            _typePool = typePool;
            //给所有的Resolver指定GetParameterInstance委托, 这样当遇到构造函数需要参数的时候，还是交由Container来提供实例
            foreach (var resolver in typePool.Values)
            {
                resolver.GetParameterInstance = Resolve;
            }
        }

        //实现的接口方法
        public T Resolve<T>() where T : class
        {
            //直接调用对应的REsolver的GetInstance方法获取实例
            return (T) _typePool[typeof (T)].GetInstance();
        }
        //本人注：这里是最关键的，根据type去获取实例，跟Resolve中委托形成循环调用（解决构造函数中参数需要传递一个注册的实例），自动匹配是哪个类
        private object Resolve(Type type)
        {
            return _typePool[type].GetInstance();
        }
    }
}
