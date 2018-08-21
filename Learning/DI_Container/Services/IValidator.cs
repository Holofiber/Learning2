using System.Diagnostics;

namespace DI_Container
{
    public interface IValidator
    {
        bool Check();
    }

    public class EmailValidator : IValidator
    {
        public bool Check()
        {
            return false;
        }
    }
    public class DateValidator : IValidator
    {
        public DateValidator()
        {
            Debug.WriteLine("DateValidator Created");
        }
        public bool Check()
        {
            return true;
        }
    }
    public class PhoneNumberValidator : IValidator
    {
        public bool Check()
        {
            return true;
        }
    }


}