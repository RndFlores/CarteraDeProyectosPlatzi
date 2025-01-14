namespace InterfaceSegregation
{
//    public class Developer : IActivities//SE REEMPLAZO PORQUE HAY ROLES QUE UN DEVELOPER NO DEBE SER ENCARGADO
    public class Developer : IWorkTeamActivities, IDevelopActivities
    {
        public Developer()
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

        //NO ES NECESARIO PORQUE EL DEVELOPER NO SE ENCARGA DE ESTO
        //public void Design() 
        //{
        //    throw new ArgumentException();
        //}

        public void Develop() 
        {
            Console.WriteLine("I'm developing the functionalities required");
        }

    }
}