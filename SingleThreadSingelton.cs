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