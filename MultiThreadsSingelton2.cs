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