using OpenClose;

ShowSalaryMonthly(new List<Employee>() {
    new EmployeeFullTime("Pepito Pérez", 160),
    new EmployeePartTime("Manuel Lopera", 180),
    new EmployeeContractor("Manuel perez", 200)
});


void ShowSalaryMonthly(List<Employee> employees) 
{
    foreach (var employee in employees)
    {
     Console.WriteLine($"Empleado: {employee.Fullname}, Pago: {employee.CalculateSalaryMonthly():C1} ");
    }

}

/*
 SE CUMPLE EL PRINCIPIO DE RESPONSABILIDAD OPEN/CLOSED
LOGRANDO QUE LA CLASE PROGRAM.CS EN UN FUTURO SI SE AGREGAN NUEVAS CLASES QUE TENGAN QUE HEREDAR DE EMPLOYEE.CS AL CLASE PROGRAM
NO SE VERA AFECTADA YA QUE SIGUE EN FUNCIONALIDAD.
SE CUMPLE EL PRINCIPIO PORQUE EL COMPONTENTE ESTÁ ABIERTO A EXTENCIONES Y CERRADO A MODIFICACIONES.
 */