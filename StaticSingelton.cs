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