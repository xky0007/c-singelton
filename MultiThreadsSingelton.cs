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