namespace Liskov
{
    public abstract class Employee
    {
        public string Fullname { get; set; }
        public int HoursWorked { get; set; }

        //public int ExtraHours {get;set;} NO DEBERÍA IR PORQUE EMPLOYEE CONTRACTOR NO LO USA

        public  Employee(string fullname, int hoursWorked)
        {
            Fullname = fullname;
            HoursWorked = hoursWorked;
        }

        public abstract decimal CalculateSalary();

        /*
        NO DEBE IR ACA PORQUE LA CLASE PADRE NO ES EL ENCARGADO DE REALIZAR ESTAS ACCIONES 
        public virtual decimal CalculateSalary (bool IsFullTime)
        {   
            decimal hourValue = IsFullTime ? 50 : 40;
            return hourValue * (HoursWorked + ExtraHours);
        } */
    }
}