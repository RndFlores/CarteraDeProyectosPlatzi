namespace InterfaceSegregation
{
    public class Tester : IWorkTeamActivities, ITestActivities
    {
        public Tester()
        {
        }

        public void Plan() 
        {
            throw new ArgumentException();
        }

        public void Comunicate() 
        {
            throw new ArgumentException();
        }

        //public void Design() 
        //{
        //    throw new ArgumentException();
        //}

        //public void Develop() 
        //{
        //    Console.WriteLine("I'm developing the functionalities required");
        //}

        public void Test() 
        {
            Console.WriteLine("I'm testing the application");
        }
    }
}