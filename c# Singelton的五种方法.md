## C#单例模式的5种实现方法

### 1. 单线程模式

此方法在多线程下可能会出现非单例情况
```
public class SingleThreadSingelton
{
    private SingleThreadSingelton(){}

    private static SingleThreadSingelton instance;
    private static SingleThreadSingelton Instance
    {
        get
        {
            if(instance == null)
                instance = new SingleThreadSingelton();
            return instance;
        }
    }
}
```

### 2. 多线程模式

由于lock非常消耗资源，此多线程模式的性能较差

```
public class MultiThreadsSingelton
{
    private MultiThreadsSingelton(){}

    private static MultiThreadsSingelton instance;
    private static readonly System.Object obj = new System.Object(); 
    private static MultiThreadsSingelton Instance
    {
        get
        {
            lock(obj)
            {
                if(instance == null)
                    instance = new MultiThreadsSingelton();
                return instance;
            }
        }
    }
}
```

### 3. 多线程稍高性能

由于检查null的消耗比lock少很多，因此使用双重检查来规避重复的lock

```
public class MultiThreadsSingelton2
{
    private MultiThreadsSingelton2(){}

    private static MultiThreadsSingelton2 instance;
    private static readonly System.Object obj = new System.Object(); 
    private static MultiThreadsSingelton2 Instance
    {
        get
        {
            if(instance == null)
            {
                // 只有一个线程会得到锁，所以仅有第一个空值时会lock，性能高
                lock(obj)
                {
                    if(instance == null)
                        instance = new MultiThreadsSingelton2();                    
                }
            }
            return instance;
            
        }
    }
}
```

### 4. 静态变量

使用静态变量或者静态构造函数可以保证仅调用一次，但是由于这是由CLR控制，故可能在真正需要使用之前就已经分配在内存中，造成一定的浪费

```
public class StaticSingelton
{
    private StaticSingelton(){}
    private static StaticSingelton instance = new StaticSingelton();

    public StaticSingelton Instance
    {
        get
        {
            return instance;
        }
    }

    // 会先 static field，property，第二种写法
    // static StaticSingelton()
    // {
    //     instance = new StaticSingelton();
    // }
}
```

### 5. 内嵌类+静态构造函数

此方法既可保证在使用单例之前不会提前分配内存

```
public class InternalSingelton
{
    private InternalSingelton(){}

    private static InternalSingelton instance;

    public InternalSingelton Instance
    {
        get
        {
            return instance;
        }
    }

    internal class Nested
    {
        static Nested()
        {
            instance = new InternalSingelton();
        }
    }
}
```

