namespace Factory_Design_Pattern
{
    public interface IMobile
    {
        public string MobileName();
        public decimal MobilePrice();
        public int MobileRAM();
    }
    public class Samsung : IMobile
    {
        public string MobileName()
        {
            return "Samsung";
        }

        public decimal MobilePrice()
        {
            return 15000;
        }

        public int MobileRAM()
        {
            return 16;
        }
    }
    public class VIVO : IMobile
    {
        public string MobileName()
        {
            return "VIVO";
        }

        public decimal MobilePrice()
        {
            return 20000;
        }

        public int MobileRAM()
        {
            return 28;
        }
    }
    public class OOPO : IMobile
    {
        public string MobileName()
        {
            return "OOPO";
        }

        public decimal MobilePrice()
        {
            return 45000;
        }

        public int MobileRAM()
        {
            return 32;
        }
    }
    public class Factory
    {
        public IMobile GetMobilePhone(string mobile)
        {
            IMobile phone;
            if (mobile == "samsung")
            {
                phone = new Samsung();
            }
            else if (mobile == "vivo")
            {
                phone = new VIVO();
            }
            else
            {
                phone = new OOPO();
            }
            return phone;
        }
    }
    public class FactoryPattern   //Client Code
    {
      public static void Main()
        {
            Factory factory = new Factory();//Factory class is responsible for creating instance of selected mobile 
            IMobile phone=factory.GetMobilePhone("oopo");  
            Console.WriteLine($"Mobile Name:{phone.MobileName()}");
           Console.WriteLine($"Mobile Price:{phone.MobilePrice()}");
            Console.WriteLine($"Mobile RAM:{phone.MobileRAM()}");
        }
    }
}
