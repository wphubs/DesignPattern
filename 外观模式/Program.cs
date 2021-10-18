using System;

namespace 外观模式
{
    class Program
    {
        static void Main(string[] args)
        {
            IDevice d1 = new FHCardReader();
            d1.Open();
            d1.Send("GpoHigh");
            d1.Close();

            IDevice d2 = new ImpinjCardReader();
            d2.Open();
            d2.Send("GpoHigh");
            d2.Close();
        }
    }

    //Facade
    public interface IDevice
    {
        void Open();
        void Close();
        void Send(string msg);
    }
    //ConcreteFacadeA
    public class FHCardReader : IDevice
    {
        FHReader reader = new FHReader();
        FHGpo gpo = new FHGpo();
        public void Open()
        {
            reader.Connect();
        }
        public void Close()
        {
            reader.DisConnect();
        }
        public void Send(string msg)
        {
            switch (msg)
            {
                case "Config": reader.ApplyConfig(); break;
                case "GpoHigh": gpo.SetGpo(true); break;
                case "GpoLow": gpo.SetGpo(false); break;
                default:
                    break;
            }
        }

        public void Send()
        {
            throw new NotImplementedException();
        }
    }
    //ConcreteFacadeB
    public class ImpinjCardReader : IDevice
    {
        ImpinjReader reader = new ImpinjReader();
        public void Open()
        {
            reader.Connect();
        }
        public void Close()
        {
            reader.DisConnect();
        }
        public void Send(string msg)
        {
            switch (msg)
            {
                case "Config": reader.ApplyConfig(); break;
                case "GpoHigh": reader.SetGpo(true); break;
                case "GpoLow": reader.SetGpo(false); break;
                default:
                    break;
            }
        }
    }
    //AnApi
    public class ImpinjReader
    {
        public void Connect() { }
        public void DisConnect() { }
        public void ApplyConfig() { }
        public void SetGpo(bool state) { }
        //。。。。一堆用不上的功能
    }
    //B1Api
    public class FHReader
    {
        public void Connect() { }
        public void DisConnect() { }
        public void ApplyConfig() { }
        //。。。。一堆用不上的功能
    }
    //B2Api
    public class FHGpo
    {
        public void SetGpo(bool state) { }
        //。。。。一堆用不上的功能
    }
}
